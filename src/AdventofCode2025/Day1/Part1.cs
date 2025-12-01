#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace Day1;
#pragma warning restore IDE0130 // Namespace does not match folder structure

internal static class Part1
{
    internal const string PuzzleInputFilePath = "assets/Input_Day1.txt";
    internal static string[] ExampleLines = [
        "L68",
        "L30",
        "R48",
        "L5",
        "R60",
        "L55",
        "L1",
        "L99",
        "R14",
        "L82"
    ];

    internal static string GetSolution()
    {
        return GetPasswordFromFile(PuzzleInputFilePath);
    }

    internal static string GetExampleSolution()
    {
        return GetPassword(ExampleLines);
    }

    private static string GetPasswordFromFile(string input)
    {
        return GetPassword(File.ReadLines(input));
    }

    private static string GetPassword(IEnumerable<string> lines)
    {
        var dial = 50;
        var centered = 0;

        foreach (var line in lines)
        {
            var direction = line[0]; // L or R
            var steps = int.Parse(line[1..]);

            dial += (direction == 'L' ? -steps : steps);

            do
            {
                if (dial < 0)
                {
                    dial += 100;
                }

                if (dial >= 100)
                {
                    dial -= 100;
                }
            }
            while (dial < 0 || dial >= 100);

            if (dial == 0)
            {
                centered++;
            }
        }

        return centered.ToString();
    }
}
