using System;

public class BadHabitGoal : Goal
{
    public BadHabitGoal(string name, string desc, int penalty)
        : base(name, desc, -Math.Abs(penalty)) { }

    public override void RecordEvent(GoalManager manager)
    {
        manager.AddScore(Points);
        Console.WriteLine($"⚠️ Recorded bad habit '{Name}'. -{Math.Abs(Points)} pts.");
    }

    public override bool IsComplete() => false;

    public override string GetStringRepresentation()
    {
        return $"BadHabitGoal|{Name}|{Points}";
    }
}
