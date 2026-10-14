using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        bool running = true;

        while (running)
        {
            Console.WriteLine("\nEternal Quest");
            Console.WriteLine($"You have {manager.Score} points.\n");

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Show Goals");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal(manager);
                    break;

                case "2":
                    RecordGoal(manager);
                    break;

                case "3":
                    manager.DisplayGoals();
                    break;

                case "4":
                    manager.SaveGoals("goals.txt");
                    break;

                case "5":
                    manager.LoadGoals("goals.txt");
                    break;

                case "6":
                    running = false;
                    Console.WriteLine("Thank you for playing Eternal Quest!");
                    break;

                default:
                    Console.WriteLine(
                        "Invalid choice. Please select a number from 1 to 6.");
                    break;
            }

            if (manager.Score >= 1000)
            {
                Console.WriteLine(
                    "Achievement unlocked: Eternal Quest Champion!");
            }
        }
    }

    static void CreateGoal(GoalManager manager)
    {
        Console.WriteLine("\nThe types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string type = Console.ReadLine();

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        int points = ReadNonNegativeInt(
            "How many points should this goal be worth? ");

        Goal goal;

        switch (type)
        {
            case "1":
                goal = new SimpleGoal(name, description, points);
                break;

            case "2":
                goal = new EternalGoal(name, description, points);
                break;

            case "3":
                int target = ReadPositiveInt(
                    "How many times must this goal be completed? ");

                int bonus = ReadNonNegativeInt(
                    "What is the bonus for completing it? ");

                goal = new ChecklistGoal(
                    name,
                    description,
                    points,
                    target,
                    bonus);
                break;

            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        manager.AddGoal(goal);

        Console.WriteLine("Goal created successfully!");
    }

    static void RecordGoal(GoalManager manager)
    {
        manager.DisplayGoals();

        Console.Write(
            "\nWhich goal did you accomplish? Enter its number: ");

        if (!int.TryParse(Console.ReadLine(), out int goalNumber))
        {
            Console.WriteLine("Please enter a valid number.");
            return;
        }

        manager.RecordEvent(goalNumber - 1);
    }

    static int ReadNonNegativeInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            if (int.TryParse(Console.ReadLine(), out int value) &&
                value >= 0)
            {
                return value;
            }

            Console.WriteLine(
                "Please enter a whole number greater than or equal to zero.");
        }
    }

    static int ReadPositiveInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            if (int.TryParse(Console.ReadLine(), out int value) &&
                value > 0)
            {
                return value;
            }

            Console.WriteLine(
                "Please enter a whole number greater than zero.");
        }
    }

}