namespace AdventofCode2025;

public static partial class Day03
{
    private const string PuzzleInputFilePath = "assets/Input_Day3.txt";

    internal static string GetPart1Solution()
    {
        return GetLargestSum(File.ReadAllLines(PuzzleInputFilePath));
    }

    internal static string GetPart2Solution()
    {
        return string.Empty;
    }
}

