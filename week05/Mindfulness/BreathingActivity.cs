using System;

public class BreathingActivity : Activity
{
    public BreathingActivity()
        : base(
            "Breathing Activity",
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        StartActivity();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());

        bool breathingIn = true;

        while (DateTime.Now < endTime)
        {
            int remainingSeconds =
                (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);

            int breathSeconds = Math.Min(4, remainingSeconds);

            if (breathingIn)
            {
                Console.WriteLine("Breathe in...");
            }
            else
            {
                Console.WriteLine("Breathe out...");
            }

            ShowCountDown(breathSeconds);

            breathingIn = !breathingIn;
        }

        EndActivity();
    }
}