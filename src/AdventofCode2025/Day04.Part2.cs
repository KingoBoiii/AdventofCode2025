namespace AdventofCode2025;

public static partial class Day04
{
    internal static string CountTotalAccessible(string[] lines)
    {
        int rows = lines.Length;
        int cols = lines[0].Length;
        char[][] grid = new char[rows][];
        for (int r = 0; r < rows; r++)
        {
            grid[r] = lines[r].ToCharArray();
        }

        int[] dr = { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] dc = { -1, 0, 1, -1, 1, -1, 0, 1 };
        int totalRemoved = 0;

        while (true)
        {
            var toRemove = new List<(int r, int c)>();

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (grid[r][c] != '@')
                    {
                        continue;
                    }

                    int neighbors = 0;
                    for (int k = 0; k < 8; k++)
                    {
                        int nr = r + dr[k], nc = c + dc[k];
                        if (nr < 0 || nr >= rows || nc < 0 || nc >= cols)
                        {
                            continue;
                        }

                        if (grid[nr][nc] == '@')
                        {
                            neighbors++;
                        }
                    }
                    if (neighbors < 4)
                    {
                        toRemove.Add((r, c));
                    }
                }
            }

            if (toRemove.Count == 0)
            {
                break;
            }

            totalRemoved += toRemove.Count;
            foreach (var (r, c) in toRemove)
            {
                grid[r][c] = '.';
            }
        }

        return totalRemoved.ToString();
    }
}

