namespace AdventOfCode;

sealed class Day11 : Day<int>
{
    protected override int CalculatePart1(string input)
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

    protected override int CalculatePart2(string input)
    {
        var outputs = input.Split(Environment.NewLine)
                                   .Select((line, index) => (Parts: line.Split(':', StringSplitOptions.TrimEntries), Index: index))
                                   .Select(e => (Id: e.Parts[0], Outputs: e.Parts[1].Split(' ', StringSplitOptions.TrimEntries)))
                                   .ToDictionary(e => e.Id, e => e.Outputs);

        return Move("svr", containsDAC: false, containsFFT: false);

        int Move(string id, bool containsDAC, bool containsFFT)
        {
            if (id == "out")
            {
                return containsDAC && containsFFT ? 1 : 0;
            }

            containsDAC |= id == "dac";
            containsFFT |= id == "fft";
            return outputs[id].Sum(output => Move(output, containsDAC, containsFFT));
        }
    }
}
