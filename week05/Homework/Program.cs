using System;

class Program
{
    static void Main(string[] args)
    {
        static void Main(string[] args)
        {
            // Base Assignment test
            Assignment a1 = new Assignment("Eduardo Lima", "Multiplication");
            Console.WriteLine(a1.GetSummary());
            Console.WriteLine();

            // Math Assignment test
            MathAssignment math = new MathAssignment(
                "Miguel Avalos",
                "Fractions",
                "7.3",
                "8-19"
            );

            Console.WriteLine(math.GetSummary());
            Console.WriteLine(math.GetHomeworkList());
            Console.WriteLine();

            // Writing Assignment test
            WritingAssignment writing = new WritingAssignment(
                "Benito Juarez",
                "European Economy",
                "The Causes of World War"
            );

            Console.WriteLine(writing.GetSummary());
            Console.WriteLine(writing.GetWritingInformation());
        }
    }
}