namespace AdventofCode2025;

public static partial class Day04
{
    internal static string CountAccessible(string[] lines)
    {
        int rows = lines.Length;
        int cols = lines[0].Length;
        int[] dr = { -1, -1, -1, 0, 0, 1, 1, 1 };
        int[] dc = { -1, 0, 1, -1, 1, -1, 0, 1 };
        int accessible = 0;

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (lines[r][c] != '@')
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

                    if (lines[nr][nc] == '@')
                    {
                        neighbors++;
                    }
                }
                if (neighbors < 4)
                {
                    accessible++;
                }
            }
        }

        return accessible.ToString();
    }
}

