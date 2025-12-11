namespace AdventOfCode;

sealed class Day11 : Day<long>
{
    protected override long CalculatePart1(string input)
    {
        var outputs = input.Split(Environment.NewLine)
                           .Select((line, index) => (Parts: line.Split(':', StringSplitOptions.TrimEntries), Index: index))
                           .Select(e => (Id: e.Parts[0], Outputs: e.Parts[1].Split(' ', StringSplitOptions.TrimEntries)))
                           .ToDictionary(e => e.Id, e => e.Outputs);

        return Move("you");

        int Move(string id)
        {
            if (id == "out")
            {
                return 1;
            }

            return outputs[id].Sum(output => Move(output));
        }
    }

    protected override long CalculatePart2(string input)
    {
        var outputs = input.Split(Environment.NewLine)
                           .Select((line, index) => (Parts: line.Split(':', StringSplitOptions.TrimEntries), Index: index))
                           .Select(e => (Id: e.Parts[0], Outputs: e.Parts[1].Split(' ', StringSplitOptions.TrimEntries)))
                           .ToDictionary(e => e.Id, e => e.Outputs);

        var store = new Dictionary<(string, string), long>();
        var countFFTFirst = CountRoutes("svr", "fft") * CountRoutes("fft", "dac") * CountRoutes("dac", "out");
        var orderDACFirst = CountRoutes("svr", "dac") * CountRoutes("dac", "fft") * CountRoutes("fft", "out");
        return countFFTFirst + orderDACFirst;

        long CountRoutes(string origin, string destination)
        {
            if (store.TryGetValue((origin, destination), out var result))
            {
                return result;
            }

            return store[(origin, destination)] = (origin, destination) switch
            {
                _ when origin == destination => 1,
                _ when outputs.TryGetValue(origin, out var outputsForOrigin) => outputsForOrigin.Sum(output => CountRoutes(output, destination)),
                _ => 0
            };
        }
    }
}
