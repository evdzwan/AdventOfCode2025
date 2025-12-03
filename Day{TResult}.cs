namespace AdventOfCode;

abstract class Day<TResult>
{
    protected abstract TResult CalculatePart1(string input);
    public async Task<TResult> Part1(string resource)
    {
        var input = await LoadResource(resource);
        return CalculatePart1(input);
    }

    protected abstract TResult CalculatePart2(string input);
    public async Task<TResult> Part2(string resource)
    {
        var input = await LoadResource(resource);
        return CalculatePart2(input);
    }

    private static async Task<string> LoadResource(string resource)
    {
        await using var stream = typeof(Tests).Assembly.GetManifestResourceStream($"AdventOfCode.Resources.{resource}")!;
        using var reader = new StreamReader(stream);
        return await reader.ReadToEndAsync();
    }
}
