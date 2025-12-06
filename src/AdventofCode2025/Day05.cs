namespace AdventofCode2025;

public static partial class Day05
{
    private const string PuzzleInputFilePath = "assets/Input_Day5.txt";

    internal static string GetPart1Solution()
    {
        return CountFreshIngredients(File.ReadAllLines(PuzzleInputFilePath));
    }

    internal static string GetPart2Solution()
    {
        return string.Empty;
    }

    private static (string[] IngredientIdRanges, string[] IngredientIds) SplitOnBlankEntry(string[] lines)
    {
        ArgumentNullException.ThrowIfNull(lines);

        int sep = Array.FindIndex(lines, string.IsNullOrWhiteSpace);
        if (sep == -1)
        {
            return (lines, Array.Empty<string>());
        }

        int start = sep + 1;
        while (start < lines.Length && string.IsNullOrWhiteSpace(lines[start]))
        {
            start++;
        }

        var first = sep > 0 ? lines.Take(sep).ToArray() : [];
        var secondLen = lines.Length - start;
        var second = secondLen > 0 ? lines.Skip(start).ToArray() : [];

        return (first, second);
    }
}

