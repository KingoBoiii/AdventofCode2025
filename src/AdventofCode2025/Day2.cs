namespace AdventofCode2025;

public static partial class Day2
{
    private const string PuzzleInputFilePath = "assets/Input_Day2.txt";

    internal static string GetPart1Solution()
    {
        return GetInvalidIdSum(File.ReadAllText(PuzzleInputFilePath));
    }

    internal static string GetPart2Solution()
    {
        return GetInvalidIdSum2(File.ReadAllText(PuzzleInputFilePath));
    }

    private static IEnumerable<long> LongRange(long start, long endInclusive)
    {
        if (endInclusive < start)
        {
            yield break;
        }

        for (var current = start; current <= endInclusive; current++)
        {
            yield return current;
        }
    }
}

