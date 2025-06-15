using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private int _level = 1;
    private const int LevelUpThreshold = 1000;

    public void AddScore(int pts)
    {
        _score += pts;
    }

    public void CheckLevelUp()
    {
        int newLevel = _score / LevelUpThreshold + 1;
        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"🎉 Level up! Now level {_level}.");
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Score: {_score} pts | Level: {_level}");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nGoals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            var g = _goals[i];
            string status = g.IsComplete() ? "[X]" : "[ ]";
            Console.WriteLine($"{i+1}. {status} {g.GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.Write("Choose type (1=Simple, 2=Eternal, 3=Checklist, 4=BadHabit): ");
        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points (neg for penalty): ");
        int pts = int.Parse(Console.ReadLine());

        Goal goal = null;

        if (type == "1")
            goal = new SimpleGoal(name, desc, pts);
        else if (type == "2")
            goal = new EternalGoal(name, desc, pts);
        else if (type == "3")
        {
            Console.Write("Target count: ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());
            goal = new ChecklistGoal(name, desc, pts, target, bonus);
        }
        else if (type == "4")
            goal = new BadHabitGoal(name, desc, pts);
        else
            Console.WriteLine("Invalid type selected.");

        if (goal != null)
        {
            _goals.Add(goal);
            Console.WriteLine($"✅ Added goal '{goal.Name}'.");
        }
    }

    public void RecordEvent()
    {
        ListGoalDetails();
        Console.Write("\nGoal number to record: ");
        if (int.TryParse(Console.ReadLine(), out int idx)
            && idx >= 1 && idx <= _goals.Count)
        {
            _goals[idx - 1].RecordEvent(this);
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void SaveGoals(string filename)
    {
        using var w = new StreamWriter(filename);
        w.WriteLine(_score);
        w.WriteLine(_level);
        foreach (var g in _goals)
            w.WriteLine(g.GetStringRepresentation());
    }

    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename)) return;

        _goals.Clear();

        using var r = new StreamReader(filename);
        _score = int.Parse(r.ReadLine());
        _level = int.Parse(r.ReadLine());

        while (!r.EndOfStream)
        {
            var parts = r.ReadLine().Split('|');
            Goal g = null;
            string type = parts[0];

            if (type == "SimpleGoal")
                g = new SimpleGoal(parts[1], "", int.Parse(parts[2]));
            else if (type == "EternalGoal")
                g = new EternalGoal(parts[1], "", int.Parse(parts[2]));
            else if (type == "ChecklistGoal")
                g = new ChecklistGoal(parts[1], "", int.Parse(parts[2]),
                                      int.Parse(parts[4]), int.Parse(parts[5]));
            else if (type == "BadHabitGoal")
                g = new BadHabitGoal(parts[1], "", int.Parse(parts[2]));

            if (g != null) _goals.Add(g);
        }
    }

    public void Start()
    {
        const string SAVE_FILE = "goals.txt";
        LoadGoals(SAVE_FILE);

        while (true)
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1) Create goal");
            Console.WriteLine("2) List goals");
            Console.WriteLine("3) Record event");
            Console.WriteLine("4) Show score/level");
            Console.WriteLine("5) Save and continue");
            Console.WriteLine("6) Save and quit");
            Console.Write("Choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoalDetails(); break;
                case "3": RecordEvent(); break;
                case "4": DisplayPlayerInfo(); break;
                case "5": SaveGoals(SAVE_FILE); break;
                case "6":
                    SaveGoals(SAVE_FILE);
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}
