namespace AdventOfCode;

sealed class Day12 : Day<int>
{
    protected override int CalculatePart1(string input)
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

        return regions.Count(region => region.Quantities.Select((quantity, index) => quantity * shapes[index].AreaSize).Sum() < region.Size.X * region.Size.Y);
    }

    protected override int CalculatePart2(string input)
        => throw new NotSupportedException();
}
