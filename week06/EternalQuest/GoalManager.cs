using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public int Score => _score;

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int index)
    {
        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal goal = _goals[index];

        if (goal.IsComplete())
        {
            Console.WriteLine("This goal is already complete.");
            return;
        }

        int earnedPoints = goal.RecordEvent();

        _score += earnedPoints;

        Console.WriteLine(
            $"Congratulations! You earned {earnedPoints} points.");

        Console.WriteLine($"Your new score is {_score} points.");
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\nYour Goals:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("You have not created any goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void SaveGoals(string filename)
    {
        try
        {
            using StreamWriter writer = new StreamWriter(filename);

            writer.WriteLine(_score);

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }

            Console.WriteLine("Goals saved successfully.");
        }
        catch (IOException)
        {
            Console.WriteLine("An error occurred while saving the file.");
        }
    }

    public void LoadGoals(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("The save file does not exist.");
                return;
            }

            string[] lines = File.ReadAllLines(filename);

            if (lines.Length == 0 ||
                !int.TryParse(lines[0], out int loadedScore) ||
                loadedScore < 0)
            {
                Console.WriteLine("The save file is invalid.");
                return;
            }

            List<Goal> loadedGoals = new List<Goal>();

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i]))
                {
                    continue;
                }

                string[] parts = lines[i].Split('|');

                if (parts.Length < 4 ||
                    !int.TryParse(parts[3], out int points) ||
                    points < 0)
                {
                    Console.WriteLine(
                        $"Invalid goal data on line {i + 1}.");
                    return;
                }

                Goal goal;

                switch (parts[0])
                {
                    case "SimpleGoal":
                        if (parts.Length != 5 ||
                            !bool.TryParse(parts[4], out bool isComplete))
                        {
                            Console.WriteLine(
                                $"Invalid simple goal on line {i + 1}.");
                            return;
                        }

                        goal = new SimpleGoal(
                            parts[1],
                            parts[2],
                            points,
                            isComplete);
                        break;

                    case "EternalGoal":
                        if (parts.Length != 4)
                        {
                            Console.WriteLine(
                                $"Invalid eternal goal on line {i + 1}.");
                            return;
                        }

                        goal = new EternalGoal(
                            parts[1],
                            parts[2],
                            points);
                        break;

                    case "ChecklistGoal":
                        if (parts.Length != 7 ||
                            !int.TryParse(parts[4], out int target) ||
                            !int.TryParse(parts[5], out int bonus) ||
                            !int.TryParse(parts[6], out int completed))
                        {
                            Console.WriteLine(
                                $"Invalid checklist goal on line {i + 1}.");
                            return;
                        }

                        goal = new ChecklistGoal(
                            parts[1],
                            parts[2],
                            points,
                            target,
                            bonus,
                            completed);
                        break;

                    default:
                        Console.WriteLine(
                            $"Unknown goal type on line {i + 1}.");
                        return;
                }

                loadedGoals.Add(goal);
            }

            _goals = loadedGoals;
            _score = loadedScore;

            Console.WriteLine("Goals loaded successfully.");
            Console.WriteLine($"Your score is {_score} points.");
        }
        catch (IOException)
        {
            Console.WriteLine("An error occurred while loading the file.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("The save file contains invalid goal data.");
        }
    }

}