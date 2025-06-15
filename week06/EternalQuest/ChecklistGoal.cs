using System;

public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string desc, int points, int target, int bonus)
        : base(name, desc, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent(GoalManager manager)
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            manager.AddScore(Points);
            Console.WriteLine($"✔️ Progress '{Name}': {_amountCompleted}/{_target}, +{Points} pts.");

            if (_amountCompleted == _target)
            {
                manager.AddScore(_bonus);
                Console.WriteLine($"🎉 Completed checklist! Bonus +{_bonus} pts.");
            }

            manager.CheckLevelUp();
        }
        else
        {
            Console.WriteLine("Checklist already complete.");
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"{Name}: {_amountCompleted}/{_target} completed ({"pts each: "} {Points}, bonus: { _bonus})";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{Name}|{Points}|{_amountCompleted}|{_target}|{_bonus}";
    }
}
