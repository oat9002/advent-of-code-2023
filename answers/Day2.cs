using System.Linq.Expressions;

namespace advent_of_code_2023.Answers;

public static class Day2
{
    public static int Part1()
    {
        var input = InputHelper.GetInput(2, 1);
        var result = 0;


        foreach (var line in input)
        {
            var (id, bagSet) = GetBagSet(line);
            var valid = false;

            foreach (var bag in bagSet)
            {
                var things = bag.Split(",").Select(x => x.Trim()).Select(x => x.Split(" ")).Select(x => (int.Parse(x[0]), x[1])).ToArray();
                var cube = new Dictionary<string, int> {
                    { "red", 0 },
                    { "green", 0 },
                    { "blue", 0 }
                };

                foreach (var (count, color) in things)
                {
                    cube[color] += count;
                }

                var validRed = cube["red"] <= 12;
                var validGreen = cube["green"] <= 13;
                var validBlue = cube["blue"] <= 14;

                valid = validRed && validGreen && validBlue;

                if (!valid)
                {
                    break;
                }
            }

            result += valid ? id : 0;
        }

        return result;
    }

    public static int Part2()
    {
        var input = InputHelper.GetInput(2, 1);
        var result = 0;


        foreach (var line in input)
        {
            var (id, bagSet) = GetBagSet(line);
            var red = 0;
            var green = 0;
            var blue = 0;

            foreach (var bag in bagSet)
            {
                var things = bag.Split(",").Select(x => x.Trim()).Select(x => x.Split(" ")).Select(x => (int.Parse(x[0]), x[1])).ToArray();
                var cube = new Dictionary<string, int> {
                    { "red", 0 },
                    { "green", 0 },
                    { "blue", 0 }
                };

                foreach (var (count, color) in things)
                {
                    cube[color] += count;
                }

                red = Math.Max(red, cube["red"]);
                green = Math.Max(green, cube["green"]);
                blue = Math.Max(blue, cube["blue"]);
            }

            Console.WriteLine($"{id}: {red}, {green}, {blue}");

            result += red.ToMultiplier() * green.ToMultiplier() * blue.ToMultiplier();
        }

        return result;
    }

    private static (int, string[]) GetBagSet(string line)
    {
        var bagSet = line.Split(":")[1].Trim().Split(";").Select(x => x.Trim()).ToArray();
        var id = int.Parse(line.Split(":")[0].Split(" ")[1].Trim());

        return (id, bagSet);
    }
}

public static class Day2Helper
{
    public static int ToMultiplier(this int num)
    {
        return num == 0 ? 1 : num;
    }
}