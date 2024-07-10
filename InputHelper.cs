namespace advent_of_code_2023
{
    public static class InputHelper
    {
        public static string[] GetInput(int day, int part)
        {
            var input = File.ReadAllLines($"inputs/Day{day}_{part}.txt");

            return input.Select(x => x.Trim()).ToArray();
        }
    }
}