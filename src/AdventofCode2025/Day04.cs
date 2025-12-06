namespace AdventofCode2025;

public static partial class Day04
{
    private const string PuzzleInputFilePath = "assets/Input_Day04.txt";

    internal static string GetPart1Solution()
    {
        return CountAccessible(File.ReadAllLines(PuzzleInputFilePath));
    }

    internal static string GetPart2Solution()
    {
        return CountTotalAccessible(File.ReadAllLines(PuzzleInputFilePath));
    }
}

