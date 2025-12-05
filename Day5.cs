namespace AdventOfCode;

sealed class Day5 : Day<long>
{
    protected override long CalculatePart1(string input)
    {
        var groups = input.Split($"{Environment.NewLine}{Environment.NewLine}");
        var ids = groups[1].Split(Environment.NewLine).Select(long.Parse);
        var freshIds = groups[0].Split(Environment.NewLine)
                                .Select(line => line.Split('-'))
                                .Select(parts => (From: long.Parse(parts[0]), To: long.Parse(parts[1])))
                                .OrderBy(e => e.From)
                                .ThenBy(e => e.To)
                                .ToArray();

        var count = 0L;
        foreach (var id in ids)
        {
            foreach (var (fromId, toId) in freshIds.SkipWhile(e => e.To < id))
            {
                if (id >= fromId && id <= toId)
                {
                    count++;
                    break;
                }
                else if (fromId > id)
                {
                    break;
                }
            }
        }

        return count;
    }

    protected override long CalculatePart2(string input)
    {
        var groups = input.Split($"{Environment.NewLine}{Environment.NewLine}");
        var freshIds = groups[0].Split(Environment.NewLine)
                                .Select(line => line.Split('-'))
                                .Select(parts => (From: long.Parse(parts[0]), To: long.Parse(parts[1])))
                                .OrderBy(e => e.From)
                                .ThenBy(e => e.To)
                                .ToArray();

        var merged = new List<(long From, long To)>();
        foreach (var (fromId, toId) in freshIds)
        {
            if (merged is { Count: 0 } || merged[^1].To < fromId - 1)
            {
                merged.Add((fromId, toId));
            }
            else
            {
                var (lastFrom, lastTo) = merged.Last();
                merged[^1] = (lastFrom, Math.Max(lastTo, toId));
            }
        }

        var total = merged.Sum(range => range.To - range.From + 1);
        return total;
    }
}
