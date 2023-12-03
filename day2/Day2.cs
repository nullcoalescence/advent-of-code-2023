namespace advent_of_code_2023.day2
{
    public class Day2
    {
        public Day2() { }

        public void Run()
        {
            var lines = File.ReadAllLines(@"inputs/day2.txt");

            // Possible game scenarios
            int totalPossibleRed = 12;
            int totalPossibleGreen = 13;
            int totalPossibleBlue = 14;

            List<BagPull> pullList;

            int redInPull, greenInPull, blueInPull;

            int total = 0;

            bool pullGoodSoFar = true;

            // Example input
            // Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green

            foreach (var line in lines)
            {
                Console.WriteLine($"Line: {line}");

                pullGoodSoFar = true;

                // parse game id
                int gameId = int.Parse(line
                    .Split(":")[0]
                    .Split(" ")[1]);

                Console.WriteLine($"Game ID: {gameId}");

                // parse through pull subsets - semicolon delimited
                // ex. 3 blue, 4 red
                var pullSubsets = line
                    .Split(":")[1]
                    .Replace(" ", "")
                    .Split(";");

                foreach (var subset in pullSubsets)
                {
                    // parse through individual pulls - comma delimited
                    // ex. 3blue,
                    // add them to our list of BagPull's

                    redInPull = 0;
                    greenInPull = 0;
                    blueInPull = 0;

                    pullList = new List<BagPull>();

                    Console.WriteLine($"Subset: {subset}");

                    var pulls = subset.Split(",");
                    foreach (var pull in pulls)
                    {
                        //Console.WriteLine($"Pull: {pull}");
                        var num = int.Parse(string.Concat(pull.Where(Char.IsDigit)));
                        var color = pull.Replace(num.ToString(), "");

                        pullList.Add(new BagPull()
                        {
                            Num = num,
                            Color = color
                        });

                        Console.WriteLine($"Parsed BagPull: {pullList.Last()}");
                    }


                    // Now check if the subset is valid
                    var reds = pullList
                        .Where(p => p.Color.Equals("red"))
                        .Select(p => p.Num);
                    redInPull = reds.Sum();

                    Console.WriteLine($">>> {redInPull}");

                    var blues = pullList
                        .Where(p => p.Color.Equals("blue"))
                        .Select(p => p.Num);
                    blueInPull = blues.Sum();

                    var greens = pullList
                        .Where(p => p.Color.Equals("green"))
                        .Select(p => p.Num);
                    greenInPull = greens.Sum();

                    Console.WriteLine($"Total reds in pull: {redInPull}");
                    Console.WriteLine($"Total blues in pull: {blueInPull}");
                    Console.WriteLine($"Total greens in pull: {greenInPull}");

                    if (redInPull > totalPossibleRed
                    || blueInPull > totalPossibleBlue
                    || greenInPull > totalPossibleGreen)
                    {
                        pullGoodSoFar = false;
                        Console.WriteLine(">> Pull is not good!");
                    }
                    else
                    {
                        Console.WriteLine(">> Pull is good!");
                    }
                }

                if (pullGoodSoFar)
                {
                    Console.WriteLine($"Game ID {gameId} is possible!");
                    total += gameId;
                }
                else
                {
                    Console.WriteLine($"Game ID {gameId} is not possible");
                }

                Console.WriteLine("-------------------------------------------------");
            }

            Console.WriteLine($"Total: {total}");
        }

        class BagPull
        {
            public int Num { get; set; }
            public string? Color { get; set; }

            override
            public string ToString()
            {
                return ($"Num={Num}, Color={Color}");
            }
        }
    }

}