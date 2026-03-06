using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        int gradePercentage = int.Parse(Console.ReadLine());
        string letter = "";

        if (gradePercentage >= 90)
        {
            letter = "A";
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        Console.Write($"Your letter grade is: {letter}. ");
        
        if (gradePercentage >= 70)
        {
            Console.Write("Congratulations! You passed the class!");
        }
        else
        {
            Console.Write("Be diligent and you will get it the next time!");
        }

    }
}