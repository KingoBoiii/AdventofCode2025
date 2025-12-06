namespace AdventofCode2025;

public static partial class Day05
{
    internal static string CountFreshIngredientIds(string[] lines)
    {
        var (ingredientIdRanges, _) = SplitOnBlankEntry(lines);

        // Parse ranges, normalize endpoints, sort, then merge overlapping/contiguous intervals
        var intervals = ingredientIdRanges
            .Select(x =>
            {
                var parts = x.Split('-').Select(long.Parse).ToArray();
                var a = Math.Min(parts[0], parts[1]);
                var b = Math.Max(parts[0], parts[1]);
                return (Start: a, End: b);
            })
            .OrderBy(t => t.Start)
            .ToArray();

        if (intervals.Length == 0)
        {
            return "0";
        }

        long total = 0;
        long curStart = intervals[0].Start;
        long curEnd = intervals[0].End;

        foreach (var (Start, End) in intervals.Skip(1))
        {
            // merge if overlapping or contiguous
            if (Start <= curEnd + 1)
            {
                curEnd = Math.Max(curEnd, End);
            }
            else
            {
                total += curEnd - curStart + 1; // inclusive count
                curStart = Start;
                curEnd = End;
            }
        }

        total += curEnd - curStart + 1;
        return total.ToString();
    }
}

