namespace AdventOfCode;

sealed class Day2 : Day<long>
{
    protected override long CalculatePart1(string input)
    {
        var total = 0L;
        foreach (var (from, to) in input.Split(',')
                                        .Select(range => range.Split('-'))
                                        .Select(range => (long.Parse(range[0]), long.Parse(range[1]))))
        {
            for (var value = from; value <= to; value++)
            {
                var pattern = value.ToString();
                if (pattern.Length % 2 == 0 && pattern[..(pattern.Length / 2)] == pattern[(pattern.Length / 2)..])
                {
                    total += value;
                }
            }
        }

        return total;
    }

    protected override long CalculatePart2(string input)
    {
        var total = 0L;
        foreach (var (from, to) in input.Split(',')
                                        .Select(range => range.Split('-'))
                                        .Select(range => (long.Parse(range[0]), long.Parse(range[1]))))
        {
            for (var value = from; value <= to; value++)
            {
                var stringValue = value.ToString();
                var doubledStringValue = stringValue + stringValue;
                if (doubledStringValue[1..^1].Contains(stringValue))
                {
                    total += value;
                }
            }
        }

        return total;
    }
}
