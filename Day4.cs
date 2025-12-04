namespace AdventOfCode;

sealed class Day4 : Day<int>
{
    protected override int CalculatePart1(string input)
    {
        var grid = input.Split(Environment.NewLine);

        var total = 0;
        for (var y = 0; y < grid.Length; y++)
        {
            for (var x = 0; x < grid.Length; x++)
            {
                if (grid[y][x] == '@')
                {
                    var count = 0;
                    for (var cy = Math.Max(y - 1, 0); cy <= Math.Min(y + 1, grid.Length - 1); cy++)
                    {
                        for (var cx = Math.Max(x - 1, 0); cx <= Math.Min(x + 1, grid.Length - 1); cx++)
                        {
                            if (grid[cy][cx] == '@')
                            {
                                count++;
                            }
                        }
                    }

                    if (count <= 4)
                    {
                        total++;
                    }
                }
            }
        }

        return total;
    }

    protected override int CalculatePart2(string input)
    {
        var grid = input.Split(Environment.NewLine).Select(line => line.ToCharArray()).ToArray();

        var total = 0;
        while (true)
        {
            var changed = false;
            for (var y = 0; y < grid.Length; y++)
            {
                for (var x = 0; x < grid.Length; x++)
                {
                    if (grid[y][x] == '@')
                    {
                        var count = 0;
                        for (var cy = Math.Max(y - 1, 0); cy <= Math.Min(y + 1, grid.Length - 1); cy++)
                        {
                            for (var cx = Math.Max(x - 1, 0); cx <= Math.Min(x + 1, grid.Length - 1); cx++)
                            {
                                if (grid[cy][cx] == '@')
                                {
                                    count++;
                                }
                            }
                        }

                        if (count <= 4)
                        {
                            grid[y][x] = 'x';
                            changed = true;
                            total++;
                        }
                    }
                }
            }

            if (!changed)
            {
                break;
            }
        }

        return total;
    }
}
