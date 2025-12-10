namespace AdventOfCode;

sealed class Tests
{
    [TestCase("Day01.txt", DayPart.First, 1123)]
    [TestCase("Day01.txt", DayPart.Second, 6695)]
    [TestCase("Day01Example.txt", DayPart.First, 3)]
    [TestCase("Day01Example.txt", DayPart.Second, 6)]
    public async Task Day01(string resource, DayPart part, int result)
        => Assert.That(await new Day01().Part(part, resource), Is.EqualTo(result));

    [TestCase("Day02.txt", DayPart.First, 29940924880)]
    [TestCase("Day02.txt", DayPart.Second, 48631958998)]
    [TestCase("Day02Example.txt", DayPart.First, 1227775554)]
    [TestCase("Day02Example.txt", DayPart.Second, 4174379265)]
    public async Task Day02(string resource, DayPart part, long result)
        => Assert.That(await new Day02().Part(part, resource), Is.EqualTo(result));

    [TestCase("Day03.txt", DayPart.First, 17613)]
    [TestCase("Day03.txt", DayPart.Second, 175304218462560)]
    [TestCase("Day03Example.txt", DayPart.First, 357)]
    [TestCase("Day03Example.txt", DayPart.Second, 3121910778619)]
    public async Task Day03(string resource, DayPart part, long result)
        => Assert.That(await new Day03().Part(part, resource), Is.EqualTo(result));

    [TestCase("Day04.txt", DayPart.First, 1502)]
    [TestCase("Day04.txt", DayPart.Second, 9083)]
    [TestCase("Day04Example.txt", DayPart.First, 13)]
    [TestCase("Day04Example.txt", DayPart.Second, 43)]
    public async Task Day04(string resource, DayPart part, int result)
        => Assert.That(await new Day04().Part(part, resource), Is.EqualTo(result));

    [TestCase("Day05.txt", DayPart.First, 640)]
    [TestCase("Day05.txt", DayPart.Second, 365804144481581)]
    [TestCase("Day05Example.txt", DayPart.First, 3)]
    [TestCase("Day05Example.txt", DayPart.Second, 14)]
    public async Task Day05(string resource, DayPart part, long result)
        => Assert.That(await new Day05().Part(part, resource), Is.EqualTo(result));

    [TestCase("Day06.txt", DayPart.First, 4878670269096UL)]
    [TestCase("Day06.txt", DayPart.Second, 8674740488592UL)]
    [TestCase("Day06Example.txt", DayPart.First, 4277556UL)]
    [TestCase("Day06Example.txt", DayPart.Second, 3263827UL)]
    public async Task Day06(string resource, DayPart part, ulong result)
        => Assert.That(await new Day06().Part(part, resource), Is.EqualTo(result));

    [TestCase("Day07.txt", DayPart.First, 1649)]
    [TestCase("Day07.txt", DayPart.Second, 16937871060075)]
    [TestCase("Day07Example.txt", DayPart.First, 21)]
    [TestCase("Day07Example.txt", DayPart.Second, 40)]
    public async Task Day07(string resource, DayPart part, long result)
        => Assert.That(await new Day07().Part(part, resource), Is.EqualTo(result));

    [TestCase("Day08.txt", DayPart.First, 13024)]
    [TestCase("Day08.txt", DayPart.Second, 9271575747)]
    [TestCase("Day08Example.txt", DayPart.First, 40)]
    [TestCase("Day08Example.txt", DayPart.Second, 25272)]
    public async Task Day08(string resource, DayPart part, long result)
        => Assert.That(await new Day08().Part(part, resource), Is.EqualTo(result));

    [TestCase("Day09.txt", DayPart.First, 4735222687)]
    [TestCase("Day09.txt", DayPart.Second, 1569262188)]
    [TestCase("Day09Example.txt", DayPart.First, 50)]
    [TestCase("Day09Example.txt", DayPart.Second, 24)]
    public async Task Day09(string resource, DayPart part, long result)
        => Assert.That(await new Day09().Part(part, resource), Is.EqualTo(result));

    [TestCase("Day10.txt", DayPart.First, 449)]
    [TestCase("Day10.txt", DayPart.Second, 17848)]
    [TestCase("Day10Example.txt", DayPart.First, 7)]
    [TestCase("Day10Example.txt", DayPart.Second, 33)]
    public async Task Day10(string resource, DayPart part, int result)
        => Assert.That(await new Day10().Part(part, resource), Is.EqualTo(result));
}
