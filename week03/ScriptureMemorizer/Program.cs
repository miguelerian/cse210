using System;
using System.Collections.Generic;

/*
EXCEEDING REQUIREMENTS:
- Program uses multiple scriptures
- Randomly selects one
- Only hides words that are not already hidden
*/

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> list = new List<Scripture>()
        {
            new Scripture(new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son"),

            new Scripture(new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding"),

            new Scripture(new Reference("Psalm", 23, 1),
                "The Lord is my shepherd I shall not want")
        };

        Random random = new Random();
        Scripture s = list[random.Next(list.Count)];

        while (true)
        {
            Console.Clear();
            Console.WriteLine(s.GetDisplayText());

            if (s.IsCompletelyHidden()) break;

            Console.WriteLine("\nPress Enter or type 'quit': ");
            if (Console.ReadLine() == "quit") break;

            s.HideRandomWords(3);
        }
    }
}