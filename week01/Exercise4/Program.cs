using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished");

        List<int> numbers = new List<int>();

        int number = -1;
        while (number != 0)

        {
            Console.Write("Enter a number: ");
            string user = Console.ReadLine();
            number = int.Parse(user);

            if (number != 0)
            {
                numbers.Add(number);
            }

        }

        int sum = 0;
        foreach (int i in numbers)
        {
            sum += i;
        }
        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is {average}");

        int max = numbers[0];

        foreach (int i in numbers)
        {
            if (i > max)
            {
                max = i;
            }
        }

        Console.WriteLine($"The max is {max}");
    }
}