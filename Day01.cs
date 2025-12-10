namespace AdventOfCode;

sealed class Day01 : Day<int>
{
    protected override int CalculatePart1(string input)
    {
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

        return password;
    }

    protected override int CalculatePart2(string input)
    {
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

        return password;
    }
}
