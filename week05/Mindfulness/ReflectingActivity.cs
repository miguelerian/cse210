using System;
using System.Collections.Generic;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time you helped someone.",
        "Think of a time you did something difficult.",
        "Think of a time you showed courage."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this meaningful?",
        "How did you feel?",
        "What did you learn?",
        "What made it different?"
    };

    public ReflectingActivity()
    {
        _name = "Reflection Activity";
        _description = "Reflect on times you showed strength and resilience.";
    }

    public void Run()
    {
        DisplayStartingMessage();

        DisplayPrompt();

        Console.WriteLine("\nThink deeply...");
        ShowSpinner(4);

        DisplayQuestions();

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    public string GetRandomQuestion()
    {
        Random rand = new Random();
        return _questions[rand.Next(_questions.Count)];
    }

    public void DisplayPrompt()
    {
        Console.WriteLine($"\n{GetRandomPrompt()}");
    }

    public void DisplayQuestions()
    {
        int time = 0;

        while (time < _duration)
        {
            Console.WriteLine($"\n{GetRandomQuestion()}");
            ShowSpinner(4);
            time += 4;
        }
    }
}