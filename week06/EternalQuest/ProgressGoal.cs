using System;

public class ProgressGoal : Goal
{
    private int _currentProgress;
    private int _target;
    private int _bonus;

    public ProgressGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _currentProgress = 0;
    }

    public override void RecordEvent()
    {
        Console.Write("Progress made: ");
        int amount = int.Parse(Console.ReadLine());

        _currentProgress += amount;

        if (_currentProgress > _target)
            _currentProgress = _target;
    }

    public override bool IsComplete() => _currentProgress >= _target;

    public int GetBonus() => _bonus;

    public override string GetDetailsString()
    {
        return $"{(IsComplete() ? "[X]" : "[ ]")} {_shortName} ({_description}) -- Progress {_currentProgress}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ProgressGoal|{_shortName}|{_description}|{_points}|{_target}|{_bonus}|{_currentProgress}";
    }
}