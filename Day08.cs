namespace AdventOfCode;

sealed class Day08 : Day<long>
{
    protected override long CalculatePart1(string input)
    {
        var boxes = input.Split(Environment.NewLine)
                         .Select(line => line.Split(','))
                         .Select(parts => (X: int.Parse(parts[0]), Y: int.Parse(parts[1]), Z: int.Parse(parts[2])))
                         .ToArray();

        var connections = boxes.ToDictionary(box => box, box => new HashSet<(int X, int Y, int Z)>([box]));
        foreach (var (first, second, _) in boxes.SelectMany(_ => boxes, (f, s) => (First: f, Second: s))
                                                .Where(e => e.First.CompareTo(e.Second) < 0)
                                                .Select(e => (e.First, e.Second, Distance: DistanceSquared(e.First, e.Second)))
                                                .OrderBy(e => e.Distance)
                                                .Take(boxes.Length == 20 ? 10 : 1000))
        {
            if (connections[first] != connections[second])
            {
                connections[first].UnionWith(connections[second]);
                foreach (var p in connections[second])
                {
                    connections[p] = connections[first];
                }
            }
        }

        var chosenConnections = connections.Values.Distinct().OrderByDescending(set => set.Count).Take(3);
        return chosenConnections.Aggregate(1, (a, b) => a * b.Count);

        static int DistanceSquared((int X, int Y, int Z) first, (int X, int Y, int Z) second)
        {
            var dx = first.X - second.X;
            var dy = first.Y - second.Y;
            var dz = first.Z - second.Z;
            return dx * dx + dy * dy + dz * dz;
        }
    }

    protected override long CalculatePart2(string input)
    {
        var boxes = input.Split(Environment.NewLine)
                         .Select(line => line.Split(','))
                         .Select(parts => (X: long.Parse(parts[0]), Y: long.Parse(parts[1]), Z: long.Parse(parts[2])))
                         .ToArray();

        var total = 0L;
        var componentCount = boxes.Length;
        var connections = boxes.ToDictionary(box => box, box => new HashSet<(long X, long Y, long Z)>([box]));
        foreach (var (first, second, _) in boxes.SelectMany(_ => boxes, (f, s) => (First: f, Second: s))
                                                .Where(e => e.First.CompareTo(e.Second) < 0)
                                                .Select(e => (e.First, e.Second, Distance: DistanceSquared(e.First, e.Second)))
                                                .OrderBy(e => e.Distance)
                                                .TakeWhile(_ => componentCount > 1))
        {
            if (connections[first] != connections[second])
            {
                connections[first].UnionWith(connections[second]);
                foreach (var p in connections[second])
                {
                    connections[p] = connections[first];
                }

                total = first.X * second.X;
                componentCount--;
            }
        }

        return total;

        static long DistanceSquared((long X, long Y, long Z) first, (long X, long Y, long Z) second)
        {
            var dx = first.X - second.X;
            var dy = first.Y - second.Y;
            var dz = first.Z - second.Z;
            return dx * dx + dy * dy + dz * dz;
        }
    }
}
