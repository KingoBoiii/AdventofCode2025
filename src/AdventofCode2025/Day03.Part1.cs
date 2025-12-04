namespace AdventofCode2025;

public static partial class Day03
{
    internal static string GetLargestSum(string[] joltageRatings)
    {
        var largestNumbers = joltageRatings.Select(s =>
        {
            if (string.IsNullOrEmpty(s))
            {
                return "0";
            }

            var digits = s.Where(char.IsDigit).Select(c => c - '0').ToArray();
            if (digits.Length < 2)
            {
                return digits.Length == 1 ? digits[0].ToString() : "0";
            }

            // Build suffix max array so we can quickly get the best following digit for any position.
            var n = digits.Length;
            var suffixMax = new int[n];
            suffixMax[n - 1] = digits[n - 1];
            for (var i = n - 2; i >= 0; i--)
            {
                suffixMax[i] = Math.Max(digits[i], suffixMax[i + 1]);
            }

            var best = int.MinValue;
            for (var i = 0; i < n - 1; i++)
            {
                var tens = digits[i];
                var maxFollowing = suffixMax[i + 1]; // best digit after position i
                var candidate = tens * 10 + maxFollowing;
                if (candidate > best)
                {
                    best = candidate;
                }
            }

            return best.ToString();
        });

        return largestNumbers.Sum(int.Parse).ToString();
    }
}

