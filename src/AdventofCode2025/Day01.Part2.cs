namespace AdventofCode2025;

public static partial class Day01
{
    private static string GetPart2PasswordFromFile(string input)
    {
        return GetPart2Password(File.ReadLines(input));
    }

    internal static string GetPart2Password(IEnumerable<string> lines)
    {
        var dial = 50;
        var centered = 0;

        foreach (var line in lines)
        {
            var direction = line[0]; // L or R
            var steps = int.Parse(line[1..]);

            // Simple, correct simulation: move one step at a time and count each arrival at 0.
            var delta = direction == 'L' ? -1 : 1;
            for (var i = 0; i < steps; i++)
            {
                dial = (dial + delta + 100) % 100;
                if (dial == 0)
                {
                    centered++;
                }
            }
        }

        return centered.ToString();
    }
}

