namespace AdventofCode2025;

public static partial class Day06
{
    private const string PuzzleInputFilePath = "assets/Input_Day06.txt";

    internal static string GetPart1Solution()
    {
        return SumGrandTotal(File.ReadAllText(PuzzleInputFilePath));
    }

    internal static string GetPart2Solution()
    {
        return SumGrandTotalRightToLeft(File.ReadAllText(PuzzleInputFilePath));
    }
}

