using System;

public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string Name => _name;
    public int Points => _points;

    public abstract void RecordEvent(GoalManager manager);

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        return $"{Name} ({_description}): {Points} pts";
    }
    public abstract string GetStringRepresentation();
}
