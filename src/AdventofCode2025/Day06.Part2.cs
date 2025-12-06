namespace AdventofCode2025;

public static partial class Day06
{
    internal static string SumGrandTotalRightToLeft(string worksheet)
    {
        if (string.IsNullOrWhiteSpace(worksheet))
        {
            return "0";
        }

        // Normalize line endings and build a rectangular grid (pad with spaces).
        var lines = worksheet.Replace("\r\n", "\n").Split('\n');
        var maxLen = 0;
        foreach (var l in lines)
        {
            if (l.Length > maxLen)
            {
                maxLen = l.Length;
            }
        }

        for (var i = 0; i < lines.Length; i++)
        {
            if (lines[i].Length < maxLen)
            {
                lines[i] = lines[i].PadRight(maxLen, ' ');
            }
        }

        // Identify columns that are entirely spaces; problems are separated by at least one such column.
        var colHasContent = new bool[maxLen];
        for (var c = 0; c < maxLen; c++)
        {
            for (var r = 0; r < lines.Length; r++)
            {
                if (lines[r][c] != ' ')
                {
                    colHasContent[c] = true;
                    break;
                }
            }
        }

        var grandTotal = 0L;
        var cIndex = 0;
        while (cIndex < maxLen)
        {
            // Skip full-empty columns (separators)
            while (cIndex < maxLen && !colHasContent[cIndex]) cIndex++;
            if (cIndex >= maxLen)
            {
                break;
            }

            // Find contiguous block of columns for this problem
            var start = cIndex;
            while (cIndex < maxLen && colHasContent[cIndex])
            {
                cIndex++;
            }

            var end = cIndex - 1;

            // Determine the operator row: the lowest row in this block that contains any non-space char
            var operatorRow = -1;
            for (var r = lines.Length - 1; r >= 0; r--)
            {
                var slice = lines[r].Substring(start, end - start + 1);
                if (slice.Trim().Length > 0)
                {
                    operatorRow = r;
                    break;
                }
            }

            if (operatorRow < 0)
            {
                // No content in this block (shouldn't happen because colHasContent was true), skip defensively.
                continue;
            }

            var opSlice = lines[operatorRow].Substring(start, end - start + 1).Trim();
            if (string.IsNullOrEmpty(opSlice))
            {
                // No operator found, skip
                continue;
            }

            var opChar = opSlice[0];

            // Cephalopod numbers are vertical: each column within the block is a number,
            // with most significant digit at the top and least significant digit just above the operator row.
            // Problems are read right-to-left, so iterate columns from end to start.
            var numbers = new System.Collections.Generic.List<long>();
            for (var col = end; col >= start; col--)
            {
                var sb = new System.Text.StringBuilder();
                for (var r = 0; r < operatorRow; r++)
                {
                    var ch = lines[r][col];
                    if (ch != ' ')
                    {
                        sb.Append(ch);
                    }
                }

                if (sb.Length == 0)
                {
                    continue;
                }

                var numStr = sb.ToString().Trim();
                if (long.TryParse(numStr, out var n))
                {
                    numbers.Add(n);
                }
                else
                {
                    // If parsing fails, ignore that column (keeps behavior forgiving)
                    continue;
                }
            }

            long problemResult = 0;
            if (opChar == '+')
            {
                long s = 0;
                foreach (var v in numbers)
                {
                    s += v;
                }

                problemResult = s;
            }
            else if (opChar == '*')
            {
                long p = numbers.Count == 0 ? 0 : 1;
                foreach (var v in numbers) p *= v;
                problemResult = p;
            }
            else
            {
                // Unknown operator: ignore this problem (could throw if stricter behavior desired)
                continue;
            }

            grandTotal += problemResult;
        }

        return grandTotal.ToString();
    }
}

