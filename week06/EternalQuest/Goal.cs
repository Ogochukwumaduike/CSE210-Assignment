public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public string Name => _name;
    public string Description => _description;
    public int Points => _points;

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract string GetDetailsString();

    public abstract int RecordEvent();

    public abstract string GetStringRepresentation();

    public abstract bool IsComplete();

}