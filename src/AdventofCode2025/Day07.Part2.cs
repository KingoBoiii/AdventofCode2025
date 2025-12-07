

using System.Numerics;

namespace AdventofCode2025;

public static partial class Day07
{
    internal static string CountQuantumTachyonManifoldSplit(string tachyonManifold)
    {
        if (string.IsNullOrEmpty(tachyonManifold))
        {
            return "0";
        }

        // Normalize newlines and split into lines
        var lines = tachyonManifold.Replace("\r\n", "\n").Split('\n');
        var rows = lines.Length;
        var cols = lines.Max(l => l.Length);

        // Build a rectangular grid (pad shorter lines with '.')
        var grid = new char[rows][];
        for (var r = 0; r < rows; r++)
        {
            var line = lines[r].PadRight(cols, '.');
            grid[r] = line.ToCharArray();
        }

        // Locate the source 'S'
        var sr = -1;
        var sc = -1;
        for (var r = 0; r < rows; r++)
        {
            for (var c = 0; c < cols; c++)
            {
                if (grid[r][c] == 'S')
                {
                    sr = r;
                    sc = c;
                    break;
                }
            }

            if (sr != -1)
            {
                break;
            }
        }

        if (sr == -1)
        {
            // No source found
            return "0";
        }

        // dp[r,c] = number of timelines currently queued to start at cell (r,c)
        var dp = new BigInteger[rows, cols];

        // Beam enters at the location below S
        var startRow = sr + 1;
        if (startRow >= rows)
        {
            // Source is on the last row; the single timeline immediately completes
            return "1";
        }

        dp[startRow, sc] = 1;

        var completed = BigInteger.Zero;

        // Process rows top-down.
        // Important: splitters spawn beams on the same row; those must be processed until the row stabilizes.
        for (var r = startRow; r < rows; r++)
        {
            // Take current row counts and reset dp for this row.
            var rowCounts = new BigInteger[cols];
            for (var c = 0; c < cols; c++)
            {
                rowCounts[c] = dp[r, c];
                dp[r, c] = BigInteger.Zero;
            }

            // Queue columns that currently have timelines to process same-row propagation.
            var q = new Queue<int>();
            for (var c = 0; c < cols; c++)
            {
                if (!rowCounts[c].IsZero)
                {
                    q.Enqueue(c);
                }
            }

            while (q.Count > 0)
            {
                var c = q.Dequeue();
                var count = rowCounts[c];
                if (count.IsZero)
                {
                    continue; // already consumed and possibly requeued later
                }

                // consume current cell's timelines
                rowCounts[c] = BigInteger.Zero;

                var cell = grid[r][c];
                if (cell == '^')
                {
                    // spawn left and right on the same row
                    var left = c - 1;
                    var right = c + 1;
                    if (left >= 0)
                    {
                        var wasZero = rowCounts[left].IsZero;
                        rowCounts[left] += count;
                        if (wasZero)
                        {
                            q.Enqueue(left);
                        }
                    }

                    if (right < cols)
                    {
                        var wasZero = rowCounts[right].IsZero;
                        rowCounts[right] += count;
                        if (wasZero)
                        {
                            q.Enqueue(right);
                        }
                    }

                    // incoming timelines do not continue downward from a splitter
                }
                else
                {
                    // non-splitter: timelines continue downward (or complete if last row)
                    var down = r + 1;
                    if (down >= rows)
                    {
                        completed += count;
                    }
                    else
                    {
                        var wasZero = dp[down, c].IsZero;
                        dp[down, c] += count;
                        // No need to enqueue now; the next row will read dp[down,*] at its turn.
                        // This preserves top-down propagation semantics.
                    }
                }
            }

            // After stabilization, any remaining rowCounts should be zero (all consumed).
            // defensive: ensure nothing left (shouldn't be necessary)
            for (var c = 0; c < cols; c++)
            {
                if (!rowCounts[c].IsZero)
                {
                    // leftover counts should be forwarded downward (safety)
                    var down = r + 1;
                    if (down >= rows)
                    {
                        completed += rowCounts[c];
                    }
                    else
                    {
                        dp[down, c] += rowCounts[c];
                    }

                    rowCounts[c] = BigInteger.Zero;
                }
            }
        }

        return completed.ToString();
    }
}

