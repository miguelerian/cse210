using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine("\n=== Eternal Quest ===");
            Console.WriteLine($"Score: {_score}");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Quit");
            Console.Write("Select: ");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoals(); break;
                case 3: RecordEvent(); break;
                case 4: SaveGoals(); break;
                case 5: LoadGoals(); break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Progress Goal");
        Console.WriteLine("5. Negative Goal");

        int type = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == 1)
            _goals.Add(new SimpleGoal(name, desc, points));

        else if (type == 2)
            _goals.Add(new EternalGoal(name, desc, points));

        else if (type == 3)
        {
            Console.Write("Target: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }

        else if (type == 4)
        {
            Console.Write("Target amount: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ProgressGoal(name, desc, points, target, bonus));
        }

        else if (type == 5)
        {
            _goals.Add(new NegativeGoal(name, desc, points));
        }
    }

    private void ListGoals()
    {
        Console.WriteLine("\nGoals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    private void RecordEvent()
    {
        ListGoals();
        Console.Write("Select goal: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        Goal goal = _goals[index];
        goal.RecordEvent();

        if (goal is NegativeGoal)
        {
            _score -= goal.GetPoints();
            Console.WriteLine($"Lost {goal.GetPoints()} points 💀");
        }
        else
        {
            _score += goal.GetPoints();
            Console.WriteLine($"Gained {goal.GetPoints()} points 🎉");
        }

        if (goal is ChecklistGoal cg && cg.IsComplete())
        {
            _score += cg.GetBonus();
            Console.WriteLine("Checklist bonus! 🎁");
        }

        if (goal is ProgressGoal pg && pg.IsComplete())
        {
            _score += pg.GetBonus();
            Console.WriteLine("Big goal completed! 🏆");
        }
    }

    private void SaveGoals()
    {
        Console.Write("Filename: ");
        string file = Console.ReadLine();

        using (StreamWriter output = new StreamWriter(file))
        {
            output.WriteLine(_score);

            foreach (Goal g in _goals)
            {
                output.WriteLine(g.GetStringRepresentation());
            }
        }
    }

    private void LoadGoals()
    {
        Console.Write("Filename: ");
        string file = Console.ReadLine();

        string[] lines = File.ReadAllLines(file);

        _goals.Clear();
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] p = lines[i].Split("|");

            switch (p[0])
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(p[1], p[2], int.Parse(p[3])));
                    break;

                case "EternalGoal":
                    _goals.Add(new EternalGoal(p[1], p[2], int.Parse(p[3])));
                    break;

                case "ChecklistGoal":
                    ChecklistGoal cg = new ChecklistGoal(p[1], p[2],
                        int.Parse(p[3]), int.Parse(p[4]), int.Parse(p[5]));

                    for (int j = 0; j < int.Parse(p[6]); j++)
                        cg.RecordEvent();

                    _goals.Add(cg);
                    break;

                case "ProgressGoal":
                    ProgressGoal pg = new ProgressGoal(p[1], p[2],
                        int.Parse(p[3]), int.Parse(p[4]), int.Parse(p[5]));

                    for (int j = 0; j < int.Parse(p[6]); j++)
                        pg.RecordEvent();

                    _goals.Add(pg);
                    break;

                case "NegativeGoal":
                    _goals.Add(new NegativeGoal(p[1], p[2], int.Parse(p[3])));
                    break;
            }
        }
    }
}