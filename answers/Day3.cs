namespace advent_of_code_2023.Answers;

public static class Day3
{
    public static int Part1()
    {
        var input = InputHelper.GetInput(3, 1);
        var result = 0;

        for (var i = 0; i < input.Length; i++)
        {
            var tempNum = string.Empty;
            var isAdjacentToSymbol = false;
            for (var j = 0; j < input[i].Length; j++)
            {
                var c = input[i][j];

                if (c >= '0' && c <= '9')
                {
                    tempNum += c;
                    isAdjacentToSymbol = isAdjacentToSymbol || IsAdjacentToSymbol(input, i, j);
                }

                if (c == '.' || j == input[i].Length - 1 || IsSymbol(c))
                {
                    if (string.IsNullOrEmpty(tempNum))
                    {
                        continue;
                    }

                    var parsedNum = int.Parse(tempNum);

                    if (isAdjacentToSymbol)
                    {
                        result += parsedNum;
                    }

                    tempNum = string.Empty;
                    isAdjacentToSymbol = false;
                }
            }
        }

        return result;
    }

    private static bool IsSymbol(char c)
    {
        if (c == '.' || int.TryParse(c.ToString(), out _))
        {
            return false;
        }

        return true;
    }

    private static bool IsAdjacentToSymbol(string[] input, int currentRow, int currentCol)
    {
        var maxCol = input[0].Length - 1;
        var maxRow = input.Length - 1;

        if (IsSymbol(input[Math.Max(currentRow - 1, 0)][Math.Max(currentCol - 1, 0)])
        || IsSymbol(input[Math.Max(currentRow - 1, 0)][currentCol])
        || IsSymbol(input[Math.Max(currentRow - 1, 0)][Math.Min(currentCol + 1, maxCol)])
        || IsSymbol(input[currentRow][Math.Max(currentCol - 1, 0)])
        || IsSymbol(input[currentRow][Math.Min(currentCol + 1, maxCol)])
        || IsSymbol(input[Math.Min(currentRow + 1, maxRow)][Math.Max(currentCol - 1, 0)])
        || IsSymbol(input[Math.Min(currentRow + 1, maxRow)][currentCol])
        || IsSymbol(input[Math.Min(currentRow + 1, maxRow)][Math.Min(currentCol + 1, maxCol)]))
        {
            return true;
        }

        return false;
    }
}