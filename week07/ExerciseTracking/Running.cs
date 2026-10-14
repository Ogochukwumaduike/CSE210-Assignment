using System;

public class Running : Activity
{
    private double _distance;

    public Running(DateTime date, int minutes, double distance)
        : base(date, minutes)
    {
        if (distance <= 0)
        {
            throw new ArgumentException("Distance must be greater than zero.");
        }

        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (_distance / GetMinutes()) * 60;
    }

    public override double GetPace()
    {
        return GetMinutes() / _distance;
    }

}