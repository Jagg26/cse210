using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string desc, int points)
        : base(name, desc, points)
    {
    }

    public override void RecordEvent(GoalManager manager)
    {
        manager.AddScore(Points);
        Console.WriteLine($"➕ Recorded '{Name}', +{Points} pts.");
        manager.CheckLevelUp();
    }

    public override bool IsComplete() => false;

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{Name}|{Points}";
    }
}
