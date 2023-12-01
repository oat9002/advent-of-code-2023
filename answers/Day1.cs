using System;

namespace advent_of_code_2023.Answers
{
    public static class Day1
    {
        public static int Part1()
        {
            var input = InputHelper.GetInput(1, 1);
            var first = -1;
            var last = -1;
            var sum = 0;

            foreach (var line in input)
            {
                foreach (var c in line)
                {
                    try
                    {
                        var cToInt = int.Parse(c.ToString());

                        first = first == -1 ? cToInt : first;
                        last = cToInt;
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }

                var numberToAdd = int.Parse($"{first}{last}");

                sum += numberToAdd;
            }

            return sum;
        }
    }
}
