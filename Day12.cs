namespace AdventOfCode;

sealed class Day12 : Day<long>
{
    protected override long CalculatePart1(string input)
    {
        var sections = input.Split($"{Environment.NewLine}{Environment.NewLine}");
        var shapes = sections.Take(6)
                             .Select(input => input.Split(Environment.NewLine)
                                                   .Skip(1)
                                                   .ToArray())
                             .Select(grid => (Grid: grid, AreaSize: grid.SelectMany(str => str)
                                                                        .Count(ch => ch == '#')))
                             .ToArray();

        var regions = sections.Last()
                              .Split(Environment.NewLine)
                              .Select(line => line.Split(':'))
                              .Select(parts => (Size: parts[0].Split('x')
                                                              .Select(int.Parse)
                                                              .ToArray(),
                                                Quantities: parts[1].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)
                                                                    .Select(int.Parse)
                                                                    .ToArray()))
                              .Select(e => (Size: (X: e.Size[0], Y: e.Size[1]), e.Quantities))
                              .ToArray();

        var count = 0L;
        foreach (var (size, quantities) in regions)
        {
            var requiredArea = 0;
            var availableArea = size.X * size.Y;
            for (var i = 0; i < quantities.Length; i++)
            {
                requiredArea += quantities[i] * shapes[i].AreaSize;
            }

            if (requiredArea < (availableArea - (size.X < 10 ? 15 : 0)))
            {
                count++;
            }
        }

        return count;
    }

    protected override long CalculatePart2(string input)
        => throw new NotSupportedException();
}
