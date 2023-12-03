namespace advent_of_code_2023.Answers;

public static class Day3
{
    public static int Part1()
    {
        var input = InputHelper.GetInput(3, 1);
        var numbers = new Dictionary<int, List<(int, int)>>();
        var symbols = new List<(int, int)>();
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

                        if (numbers.ContainsKey(parsedNum))
                        {
                            numbers[parsedNum].AddRange(tempIndex);
                        }
                        else
                        {
                            numbers.Add(parsedNum, tempIndex);
                        }
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

        foreach (var symbol in symbols)
        {
            foreach (var (value, idx) in numbers)
            {
                var adjacent = IsAdjacent(idx, symbol);
                if (adjacent)
                {
                    result += value;
                }
            }
        }

        return result;
    }

    private static bool IsAdjacent(List<(int Row, int Col)> numberIdxs, (int Row, int Col) symbolIdx)
    {
        foreach (var (row, col) in numberIdxs)
        {
            if (row == symbolIdx.Row && col == symbolIdx.Col)
            {
                continue;
            }

            if (row == symbolIdx.Row)
            {
                if (col == symbolIdx.Col - 1 || col == symbolIdx.Col + 1)
                {
                    return true;
                }
            }
            else if (col == symbolIdx.Col)
            {
                if (row == symbolIdx.Row - 1 || row == symbolIdx.Row + 1)
                {
                    return true;
                }
            }
            else
            {
                if (row == symbolIdx.Row - 1 && col == symbolIdx.Col - 1)
                {
                    return true;
                }
                else if (row == symbolIdx.Row - 1 && col == symbolIdx.Col + 1)
                {
                    return true;
                }
                else if (row == symbolIdx.Row + 1 && col == symbolIdx.Col - 1)
                {
                    return true;
                }
                else if (row == symbolIdx.Row + 1 && col == symbolIdx.Col + 1)
                {
                    return true;
                }
            }
        }

        return false;
    }

}