namespace AdventOfCode;

sealed class Day7 : Day<long>
{
    protected override long CalculatePart1(string input)
    {
        var matrix = input.Split(Environment.NewLine).Select(line => line.ToCharArray()).ToArray();
        var routes = 0L;

        Move(matrix[0].IndexOf('S'), y: 1);
        return routes;

        void Move(int x, int y)
        {
            if (y >= matrix.Length)
            {
                return;
            }

            if (x < 0 || x >= matrix[y].Length)
            {
                return;
            }

            if (matrix[y][x] == '.')
            {
                matrix[y][x] = '|';
                Move(x, y + 1);
            }
            else if (matrix[y][x] == '^' && y < matrix.Length - 1)
            {
                if (x > 0 && matrix[y][x - 1] == '.')
                {
                    Move(x - 1, y);
                }

                if (x < matrix[y].Length - 1 && matrix[y][x + 1] == '.')
                {
                    routes++;
                    Move(x + 1, y);
                }
            }
        }
    }

    protected override long CalculatePart2(string input)
    {
        var matrix = input.Split(Environment.NewLine).Select(line => line.ToCharArray()).ToArray();
        var cache = new Dictionary<(int, int), long>();

        var routes = Move(matrix[0].IndexOf('S'), y: 1);
        return routes;

        long Move(int x, int y)
        {
            if (y >= matrix.Length || x < 0 || x >= matrix[y].Length)
            {
                return 0;
            }

            if (cache.TryGetValue((x, y), out var cached))
            {
                return cached;
            }

            var result = 0L;
            if (matrix[y][x] == '.')
            {
                result = Move(x, y + 1);
            }
            else if (matrix[y][x] == '^' && y < matrix.Length - 1)
            {
                if (x > 0 && matrix[y][x - 1] == '.')
                {
                    result += Move(x - 1, y);
                }

                if (x < matrix[y].Length - 1 && matrix[y][x + 1] == '.')
                {
                    result += Move(x + 1, y);
                }
            }

            if (y == matrix.Length - 1)
            {
                result++;
            }

            cache[(x, y)] = result;
            return result;
        }
    }
}
