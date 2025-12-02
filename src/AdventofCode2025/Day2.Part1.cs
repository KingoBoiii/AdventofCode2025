using System.Text.RegularExpressions;

namespace AdventofCode2025;

public static partial class Day2
{
    internal static string GetInvalidIdSum(string productIds)
    {
        var productIdsRange = productIds.Split(',', StringSplitOptions.RemoveEmptyEntries);

        var invalidProductIds = new List<string>();

        foreach (var range in productIdsRange)
        {
            var split = range.Split('-', StringSplitOptions.RemoveEmptyEntries);
            var firstId = long.Parse(split[0]);
            var lastId = long.Parse(split[1]);

            var ids = LongRange(firstId, lastId - firstId + 1);

            for (var id = firstId; id <= lastId; id++)
            {
                var idString = id.ToString();

                var repeatedIds = RepeatedDigitsRegex().Matches(idString).Select(m => long.Parse(m.Value));
                if (repeatedIds.Any())
                {
                    invalidProductIds.Add(idString);
                }
            }
        }

        return invalidProductIds.Select(long.Parse).Sum().ToString();
    }

    [GeneratedRegex(@"\b(\d+)\1\b")]
    private static partial Regex RepeatedDigitsRegex();
}

