using System.Collections.Concurrent;

namespace AdventOfCode;

abstract class Day<TResult>
{
    public async Task<TResult> Part(DayPart part, string resource)
    {
        var input = await LoadResource(resource);
        return part switch
        {
            DayPart.First => CalculatePart1(input),
            DayPart.Second => CalculatePart2(input),
            _ => throw new NotSupportedException()
        };
    }

    protected abstract TResult CalculatePart1(string input);
    protected abstract TResult CalculatePart2(string input);

    static readonly ConcurrentDictionary<string, Task<string>> Inputs = new(StringComparer.OrdinalIgnoreCase);
    static Task<string> LoadResource(string resource) => Inputs.GetOrAdd(resource, async _ =>
    {
        await using var stream = typeof(Tests).Assembly.GetManifestResourceStream($"AdventOfCode.Resources.{resource}")!;
        using var reader = new StreamReader(stream);
        return await reader.ReadToEndAsync();
    });
}
