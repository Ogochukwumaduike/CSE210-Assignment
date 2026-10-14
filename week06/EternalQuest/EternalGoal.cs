public class EternalGoal : Goal
{
    public EternalGoal(
    string name,
    string description,
    int points)
    : base(name, description, points)
    {
    }

    public override string GetDetailsString()
    {
        return $"[ ] {Name} ({Description})";
    }

    public override int RecordEvent()
    {
        return Points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal|{Name}|{Description}|{Points}";
    }

}