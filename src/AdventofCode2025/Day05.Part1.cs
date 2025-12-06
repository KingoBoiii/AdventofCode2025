namespace AdventofCode2025;

public static partial class Day05
{
    internal static string CountFreshIngredients(string[] lines)
    {
        var (ingredientIdRanges, ingredientIds) = SplitOnBlankEntry(lines);

        var ranges = new List<(long Start, long End)>();
        foreach (var range in ingredientIdRanges)
        {
            if (string.IsNullOrWhiteSpace(range))
            {
                continue;
            }

            var parts = range.Split('-', StringSplitOptions.TrimEntries);
            if (parts.Length != 2)
            {
                continue;
            }

            if (!long.TryParse(parts[0].Trim(), out var a))
            {
                continue;
            }

            if (!long.TryParse(parts[1].Trim(), out var b))
            {
                continue;
            }

            // normalize so Start <= End
            if (a <= b)
            {
                ranges.Add((a, b));
            }
            else
            {
                ranges.Add((b, a));
            }
        }

        if (ranges.Count == 0)
        {
            return "0";
        }


        // count ingredient IDs that fall inside any range
        var freshCount = 0;
        foreach (var s in ingredientIds)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                continue;
            }

            if (!long.TryParse(s.Trim(), out var id))
            {
                continue;
            }

            // an ID is fresh if it's in any range
            foreach (var (Start, End) in ranges)
            {
                if (id >= Start && id <= End)
                {
                    freshCount++;
                    break;
                }
            }
        }

        return freshCount.ToString();
    }
}

