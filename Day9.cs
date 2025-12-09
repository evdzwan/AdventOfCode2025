namespace AdventOfCode;

sealed class Day9 : Day<long>
{
    protected override long CalculatePart1(string input)
    {
        var redTiles = input.Split(Environment.NewLine)
                            .Select(line => line.Split(','))
                            .Select(parts => (X: long.Parse(parts[0]), Y: long.Parse(parts[1])))
                            .ToArray();

        var largestSize = 0L;
        for (var i = 0; i < redTiles.Length - 1; i++)
        {
            for (var j = i + 1; j < redTiles.Length; j++)
            {
                var size = (Math.Abs(redTiles[j].X - redTiles[i].X) + 1) * (Math.Abs(redTiles[j].Y - redTiles[i].Y) + 1);
                if (size > largestSize)
                {
                    largestSize = size;
                }
            }
        }

        return largestSize;
    }

    protected override long CalculatePart2(string input)
    {
        var redTiles = input.Split(Environment.NewLine)
                            .Select(line => line.Split(','))
                            .Select(parts => (X: long.Parse(parts[0]), Y: long.Parse(parts[1])))
                            .ToArray();

        var lines = redTiles.Select((tile, index) => (redTiles[(redTiles.Length + index - 1) % redTiles.Length], tile))
                            .ToArray();

        var largestSize = 0L;
        for (var i = 0; i < redTiles.Length - 1; i++)
        {
            for (var j = i + 1; j < redTiles.Length; j++)
            {
                var size = (Math.Abs(redTiles[j].X - redTiles[i].X) + 1) * (Math.Abs(redTiles[j].Y - redTiles[i].Y) + 1);
                if (size > largestSize)
                {
                    var startX = Math.Min(redTiles[i].X, redTiles[j].X);
                    var startY = Math.Min(redTiles[i].Y, redTiles[j].Y);
                    var endX = Math.Max(redTiles[i].X, redTiles[j].X);
                    var endY = Math.Max(redTiles[i].Y, redTiles[j].Y);

                    var empty = true;
                    foreach (var line in lines)
                    {
                        if (Intersects(startX, startY, endX, endY, line))
                        {
                            empty = false;
                            break;
                        }
                    }

                    if (empty)
                    {
                        largestSize = size;
                    }
                }
            }
        }

        return largestSize;

        static bool Intersects(long startX, long startY, long endX, long endY, ((long, long) Start, (long, long) End) line)
        {
            var (lineStartX, lineStartY) = line.Start;
            var (lineEndX, lineEndY) = line.End;

            if (lineStartX == lineEndX)
            {
                return lineStartX > startX && lineStartX < endX && Math.Max(lineStartY, lineEndY) > startY && Math.Min(lineStartY, lineEndY) < endY;
            }

            if (lineStartY == lineEndY)
            {
                return lineStartY > startY && lineStartY < endY && Math.Max(lineStartX, lineEndX) > startX && Math.Min(lineStartX, lineEndX) < endX;
            }

            return true;
        }

    }
}
