using System;
using System.Collections.Concurrent;

namespace advent_of_code_2023.Answers
{
    public static class Day1
    {
        public static int Part1()
        {
            var input = InputHelper.GetInput(1, 1);
            var bag = new ConcurrentBag<int>();

            Parallel.ForEach(input, line =>
            {
                var first = -1;
                var last = -1;
                var length = line.Length;

                for (int i = 0; i < length; i++)
                {
                    var c = line[i];
                    try
                    {
                        var cToInt = int.Parse(c.ToString());

                        first = cToInt;
                        break;
                    }
                    catch
                    {
                        continue;
                    }
                }
                for (int i = length - 1; i >= 0; i--)
                {
                    var c = line[i];
                    try
                    {
                        var cToInt = int.Parse(c.ToString());

                        last = cToInt;
                        break;
                    }
                    catch
                    {
                        continue;
                    }
                }

                var numberToAdd = int.Parse($"{first}{last}");

                bag.Add(numberToAdd);
            });

            return bag.Sum();
        }

        public static int Part2()
        {
            var input = InputHelper.GetInput(1, 2);
            var bag = new ConcurrentBag<int>();
            var digitDict = new Dictionary<string, int>()
            {
                {"one", 1},
                {"two", 2},
                {"three", 3},
                {"four", 4},
                {"five", 5},
                {"six", 6},
                {"seven", 7},
                {"eight", 8},
                {"nine", 9}
            };

            Parallel.ForEach(input, line =>
            {
                var first = -1;
                var last = -1;
                var modLine = line;

                foreach (var (key, value) in digitDict)
                {
                    modLine = modLine.Replace(key, value.ToString());
                }

                var length = modLine.Length;

                for (int i = 0; i < length; i++)
                {
                    var c = modLine[i];
                    try
                    {
                        var cToInt = int.Parse(c.ToString());

                        first = cToInt;
                        break;
                    }
                    catch
                    {
                        continue;
                    }
                }
                for (int i = length - 1; i >= 0; i--)
                {
                    var c = modLine[i];
                    try
                    {
                        var cToInt = int.Parse(c.ToString());

                        last = cToInt;
                        break;
                    }
                    catch
                    {
                        continue;
                    }
                }

                var numberToAdd = int.Parse($"{first}{last}");

                bag.Add(numberToAdd);
            });

            return bag.Sum();
        }
    }
}
