public class Day1
{
    public Day1() {}

    public void Run()
    {
        var lines = File.ReadAllLines(@"inputs/day1.txt");

        // The key is a string[],
        // with index 0 being the string representation of the number used for searching
        // and the string @ index 1 being the string replacement, so we can
        //      1) replace all occurances of index 0 with index 1
        //      2) parse the new string for only ints
        //      3) and avoid any edge cases with "oneight" parsing to only 1 or only 8, since it will replace to o1eig8t (containg both 1 & 8)
        Dictionary<string[], int> nums = new Dictionary<string[], int>
        {
            { ["one", "o1e"], 1 },
            { ["two", "t2o"], 2 },
            { ["three", "thr3e"], 3 },
            { ["four", "fo4r"], 4 },
            { ["five", "f5ve"], 5 },
            { ["six", "s6x"], 6 },
            { ["seven", "sev7n"], 7 },
            { ["eight", "ei8ht"], 8 },
            { ["nine", "n9ne"], 9 }
        };

        int total = 0;

        foreach (var line in lines)
        {
            string newLine = line; // so we can mutate it

            int firstNum = 0;
            int lastNum = 0;
            int firstPos = 0;
            int lastPos = 0;


            Console.WriteLine($"Parsing: {line}");

            foreach (var key in nums.Keys)
            {
                var find = key[0];
                var replace = key[1];

                if (newLine.Contains(find))
                {
                    newLine = newLine.Replace(find, replace);
                }
             }

            Console.WriteLine($"Line after replacing num strings: {newLine}");

            // Now check for digits
            var numbers = newLine.ToCharArray()
                .Where(Char.IsDigit)
                .ToList();

            try
            {
                firstNum = int.Parse(numbers.First().ToString());
                lastNum = int.Parse(numbers.Last().ToString());

                firstPos = newLine.IndexOf(numbers.First());
                lastPos = newLine.IndexOf(numbers.Last());
            }
            catch (Exception)
            {
                Console.WriteLine("No int parsed out of string - even if there wasn't one before, the replace loop above should've added some!");
            }

            var combined = Convert.ToInt32(string.Format("{0}{1}", firstNum, lastNum));

            Console.WriteLine($"> First num: {firstNum}");
            Console.WriteLine($"> Last num: {lastNum}");
            Console.WriteLine($"> Combined: {combined}");

            total += combined;
        }

        Console.WriteLine($"Sum of all values: {total}");
    }
}