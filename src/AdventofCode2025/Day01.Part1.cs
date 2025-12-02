namespace AdventofCode2025;

public static partial class Day01
{
    private static string GetPart1PasswordFromFile(string input)
    {
        return GetPart1Password(File.ReadLines(input));
    }

    internal static string GetPart1Password(IEnumerable<string> lines)
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

