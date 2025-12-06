namespace AdventOfCode;

sealed class Day6 : Day<ulong>
{
    protected override ulong CalculatePart1(string input)
    {
        var lines = input.Split(Environment.NewLine).Select(line => line.Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries)).ToArray();
        var matrix = lines[..^1];

        var operands = Enumerable.Range(0, matrix[0].Length).Select(col => matrix.Select(row => ulong.Parse(row[col])).ToArray()).ToArray();
        var operators = lines[^1];

        var total = 0UL;
        foreach (var (values, index) in operands.Select((v, i) => (v, i)))
        {
            var accValue = values[0];
            foreach (var value in values.Skip(1))
            {
                if (operators[index] == "*")
                {
                    accValue *= value;
                }
                else
                {
                    accValue += value;
                }
            }

            total += accValue;
        }

        return total;
    }

    protected override ulong CalculatePart2(string input)
    {
        var lines = input.Split(Environment.NewLine);
        var operators = lines[^1].Where(ch => ch != ' ').ToArray();
        var matrix = lines[..^1];

        var position = 0;
        var lastPosition = 0;
        var allValues = new List<List<ulong>>();
        while (position <= matrix[0].Length)
        {
            if (position == matrix[0].Length || matrix.All(line => line[position] == ' '))
            {
                var values = new List<ulong>();
                for (var i = position - 1; i >= lastPosition; i--)
                {
                    var strValue = new string([.. matrix.Select(line => line[i])]);
                    var value = strValue.All(ch => ch == ' ') ? 0UL : ulong.Parse(strValue);
                    values.Add(value);
                }

                allValues.Add(values);
                position++;

                lastPosition = position;
            }
            position++;
        }

        var total = 0UL;
        foreach (var (values, index) in allValues.Select((v, i) => (v, i)))
        {
            var accValue = values[0];
            foreach (var value in values.Skip(1))
            {
                if (operators[index] == '*')
                {
                    accValue *= value;
                }
                else
                {
                    accValue += value;
                }
            }

            total += accValue;
        }

        return total;
    }
}
