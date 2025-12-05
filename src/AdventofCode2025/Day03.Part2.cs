namespace AdventofCode2025;

public static partial class Day03
{
    internal static string GetLargestSumOverride(string[] joltageRatings)
    {
        const int K = 12;

        if (joltageRatings == null || joltageRatings.Length == 0)
        {
            return "0";
        }

        long sum = 0;

        foreach (var s in joltageRatings)
        {
            if (string.IsNullOrEmpty(s))
            {
                continue;
            }

            var digits = s.Where(char.IsDigit).Select(c => c - '0').ToArray();
            if (digits.Length == 0)
            {
                continue;
            }

            var n = digits.Length;
            var take = Math.Min(K, n);

            // Greedy: for each next digit we pick the largest possible digit such that
            // there remain enough digits to complete the selection.
            var resultDigits = new int[take];
            var start = 0;
            for (var t = 0; t < take; t++)
            {
                // last allowed index for this choice
                var lastIndex = n - (take - t);
                var bestDigit = -1;
                var bestPos = start;
                for (var p = start; p <= lastIndex; p++)
                {
                    var d = digits[p];
                    if (d > bestDigit)
                    {
                        bestDigit = d;
                        bestPos = p;
                        if (bestDigit == 9)
                        {
                            break; // can't do better than 9
                        }
                    }
                }

                resultDigits[t] = bestDigit;
                start = bestPos + 1;
            }

            // Build numeric value from selected digits (fits in long for up to 12 digits).
            long value = 0;
            foreach (var d in resultDigits)
            {
                value = value * 10 + d;
            }

            sum += value;
        }

        return sum.ToString();
    }
}

