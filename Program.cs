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
                break;
            default:
                Console.WriteLine("Invalid day");
                break;
        }
    }
}