using System;

public class Cycling : Activity
{
    private double _speed;

    public Cycling(DateTime date, int minutes, double speed)
        : base(date, minutes)
    {
        if (speed <= 0)
        {
            throw new ArgumentException("Speed must be greater than zero.");
        }

        _speed = speed;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetDistance()
    {
        return (_speed / 60) * GetMinutes();
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }

}