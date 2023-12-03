using advent_of_code_2023.day1;
using advent_of_code_2023.day2;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Advent of Code 2023");

        // parse day
        int day;

        if (args.Length > 0)
        {
            day = int.Parse(args[0]);
        }
        else
        {
            Console.WriteLine("Enter day");
            day = int.Parse(Console.ReadLine());
        }

        Console.WriteLine($"Press [ENTER] to run day #{day}");
        Console.ReadLine();

        // run day
        switch (day)
        {
            case 1:
                new Day1().Run();
                break;
            case 2:
                new Day2().Run();
                break;
            default:
                Console.WriteLine("Invalid day");
                break;
        }
    }
}