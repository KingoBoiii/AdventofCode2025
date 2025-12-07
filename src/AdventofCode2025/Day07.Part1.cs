namespace AdventofCode2025;

public static partial class Day07
{
    internal static string CountTachyonManifoldSplit(string tachyonManifold)
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

        // BFS/queue of beam positions to process. Each position is where a beam currently is.
        var queue = new Queue<(int r, int c)>();
        // Beam enters at the location below S
        queue.Enqueue((sr + 1, sc));

        // Track positions we've already processed to avoid infinite loops
        var visited = new HashSet<(int r, int c)>();
        // Track unique splitters (^) that were hit by any beam
        var activatedSplitters = new HashSet<(int r, int c)>();

        while (queue.Count > 0)
        {
            var (r, c) = queue.Dequeue();

            if (r < 0 || r >= rows || c < 0 || c >= cols)
            {
                continue;
            }

            if (!visited.Add((r, c)))
            {
                // Already processed this beam position
                continue;
            }

            var cell = grid[r][c];

            if (cell == '^')
            {
                // Beam hits a splitter: count it (once) and spawn beams immediately to left/right on the same row
                activatedSplitters.Add((r, c));

                var left = c - 1;
                var right = c + 1;
                if (left >= 0)
                {
                    queue.Enqueue((r, left));
                }
                if (right < cols)
                {
                    queue.Enqueue((r, right));
                }

                // The incoming beam stops at the splitter (no downward propagation)
                continue;
            }

            // For any other cell ('.', '|', 'S', etc.) the beam continues downward
            queue.Enqueue((r + 1, c));
        }

        return activatedSplitters.Count.ToString();
    }
}

