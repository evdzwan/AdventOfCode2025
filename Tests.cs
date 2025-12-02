namespace AdventOfCode;

sealed class Tests
{
    [TestCase("Day1.txt", 1123)]
    [TestCase("Day1Example.txt", 3)]
    public async Task Day1Part1(string resource, int result)
    {
        await using var stream = typeof(Tests).Assembly.GetManifestResourceStream($"AdventOfCode.Resources.{resource}")!;
        using var reader = new StreamReader(stream);
        var input = await reader.ReadToEndAsync();

        var password = 0;
        var dialPosition = 50;
        foreach (var (direction, amount) in input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                                                 .Select(line => (line[0], int.Parse(line[1..]))))
        {
            var value = direction is 'R' ? amount : -amount;
            dialPosition = (dialPosition + value) % 100;
            if (dialPosition == 0)
            {
                password++;
            }
        }

        Assert.That(password, Is.EqualTo(result));
    }

    [TestCase("Day1.txt", 6695)]
    [TestCase("Day1Example.txt", 6)]
    public async Task Day1Part2(string resource, int result)
    {
        await using var stream = typeof(Tests).Assembly.GetManifestResourceStream($"AdventOfCode.Resources.{resource}")!;
        using var reader = new StreamReader(stream);
        var input = await reader.ReadToEndAsync();

        var password = 0;
        var dialPosition = 50;
        foreach (var (direction, amount) in input.Split(Environment.NewLine)
                                                 .Select(line => (line[0], int.Parse(line[1..]))))
        {
            var value = direction is 'R' ? amount : -amount;
            var newDialPosition = dialPosition + value;

            for (var i = dialPosition; i != newDialPosition; i += Math.Sign(value))
            {
                if ((i + Math.Sign(value)) % 100 == 0)
                {
                    password++;
                }
            }

            dialPosition = newDialPosition % 100;
        }

        Assert.That(password, Is.EqualTo(result));
    }

    [TestCase("Day2.txt", 29940924880)]
    [TestCase("Day2Example.txt", 1227775554)]
    public async Task Day2Part1(string resource, long result)
    {
        await using var stream = typeof(Tests).Assembly.GetManifestResourceStream($"AdventOfCode.Resources.{resource}")!;
        using var reader = new StreamReader(stream);
        var input = await reader.ReadToEndAsync();

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

        Assert.That(total, Is.EqualTo(result));
    }

    [TestCase("Day2.txt", 48631958998)]
    [TestCase("Day2Example.txt", 4174379265)]
    public async Task Day2Part2(string resource, long result)
    {
        await using var stream = typeof(Tests).Assembly.GetManifestResourceStream($"AdventOfCode.Resources.{resource}")!;
        using var reader = new StreamReader(stream);
        var input = await reader.ReadToEndAsync();

        var total = 0L;
        foreach (var (from, to) in input.Split(',')
                                        .Select(range => range.Split('-'))
                                        .Select(range => (long.Parse(range[0]), long.Parse(range[1]))))
        {
            for (var value = from; value <= to; value++)
            {
                var pattern = value.ToString();
                for (var length = 1; length <= pattern.Length / 2; length++)
                {
                    if (pattern.Length % length == 0)
                    {
                        var firstPart = pattern[..length];
                        var parts = Enumerable.Range(1, (pattern.Length / length) - 1).Select(n => pattern.Substring(n * length, length));
                        if (parts.All(part => part == firstPart))
                        {
                            total += value;
                            break;
                        }
                    }
                }
            }
        }

        Assert.That(total, Is.EqualTo(result));
    }
}
