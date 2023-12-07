namespace advent_of_code_2023.Answers;

public static class Day3
{
    public static int Part1()
    {
        var input = InputHelper.GetInput(3, 1);
        var numbers = new List<(int Value, List<(int Row, int Col)> Coordinate)>();
        var symbols = new List<(int Row, int Col)>();
        var result = 0;

        for (var i = 0; i < input.Length; i++)
        {
            var tempNum = string.Empty;
            var tempIndex = new List<(int, int)>();
            for (var j = 0; j < input[i].Length; j++)
            {
                var c = input[i][j];


                if (c >= '0' && c <= '9')
                {
                    tempNum += c;
                    tempIndex.Add((i, j));
                }
                else if (c == '.')
                {
                    if (string.IsNullOrEmpty(tempNum))
                    {
                        continue;
                    }
                    else
                    {
                        var parsedNum = int.Parse(tempNum);

                        numbers.Add((parsedNum, tempIndex));
                        tempNum = string.Empty;
                        tempIndex = new List<(int, int)>();
                    }
                }
                else
                {
                    symbols.Add((i, j));
                }
            }
        }

        var adjacentNum = new List<int>();

        foreach (var symbol in symbols)
        {
            for (var i = 0; i < numbers.Count; i++)
            {
                var (value, idxs) = numbers[i];
                var adjacent = IsAdjacent(idxs, symbol);

                if (value == 688 && adjacent)
                {
                    Console.WriteLine($"{value} {adjacent} {string.Join(", ", idxs)}, {string.Join(", ", symbols)}");
                }

                if (adjacent)
                {
                    result += value;
                    numbers[i] = (0, idxs);
                    if (value != 0)
                    {
                        adjacentNum.Add(value);
                    }
                }
            }
        }

        return result;
    }

    private static bool IsAdjacent(List<(int Row, int Col)> numberIdxs, (int Row, int Col) symbolIdx)
    {
        foreach (var (row, col) in numberIdxs)
        {
            var diffRow = Math.Abs(row - symbolIdx.Row);
            var diffCol = Math.Abs(col - symbolIdx.Col);

            if (diffRow == 1 && diffCol == 1 ||
                diffRow == 1 && diffCol == 0 ||
                diffRow == 0 && diffCol == 1)
            {
                return true;
            }
        }

        return false;
    }

}