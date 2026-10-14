using System;

public class ChecklistGoal : Goal
{
    private int _target;
    private int _bonus;
    private int _completed;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int target,
        int bonus,
        int completed = 0)
        : base(name, description, points)
    {
        if (target <= 0)
        {
            throw new ArgumentException(
                "The target must be greater than zero.");
        }

        if (bonus < 0)
        {
            throw new ArgumentException(
                "The bonus cannot be negative.");
        }

        if (completed < 0 || completed > target)
        {
            throw new ArgumentException(
                "Completed progress must be between zero and the target.");
        }

        _target = target;
        _bonus = bonus;
        _completed = completed;
    }

    public override string GetDetailsString()
    {
        string status = IsComplete() ? "X" : " ";

        return $"[{status}] {Name} ({Description}) -- " +
               $"Completed {_completed}/{_target} times";
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            return 0;
        }

        _completed++;

        int earnedPoints = Points;

        if (_completed == _target)
        {
            earnedPoints += _bonus;
        }

        return earnedPoints;
    }

    public override bool IsComplete()
    {
        return _completed >= _target;
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{Name}|{Description}|{Points}|" +
               $"{_target}|{_bonus}|{_completed}";
    }

}