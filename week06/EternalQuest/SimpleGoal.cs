using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string desc, int points)
        : base(name, desc, points)
    {
        _isComplete = false;
    }

    public override void RecordEvent(GoalManager manager)
    {
        if (!_isComplete)
        {
            _isComplete = true;
            manager.AddScore(Points);
            Console.WriteLine($"✅ Completed '{Name}'! +{Points} pts.");
            manager.CheckLevelUp();
        }
        else
        {
            Console.WriteLine("Goal already completed.");
        }
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal|{Name}|{Points}|{(_isComplete ? 1 : 0)}";
    }
}
