namespace AdventofCode2025;

public static partial class Day07
{
    private const string PuzzleInputFilePath = "assets/Input_Day07.txt";

    internal static string GetPart1Solution()
    {
        return CountTachyonManifoldSplit(File.ReadAllText(PuzzleInputFilePath));
    }

    internal static string GetPart2Solution()
    {
        return CountQuantumTachyonManifoldSplit(File.ReadAllText(PuzzleInputFilePath));
    }
}

