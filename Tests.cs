namespace AdventOfCode;

sealed class Tests
{
    [TestCase("Day1.txt", DayPart.First, 1123)]
    [TestCase("Day1.txt", DayPart.Second, 6695)]
    [TestCase("Day1Example.txt", DayPart.First, 3)]
    [TestCase("Day1Example.txt", DayPart.Second, 6)]
    public async Task Day1(string resource, DayPart part, int result)
        => Assert.That(await new Day1().Part(part, resource), Is.EqualTo(result));

    [TestCase("Day2.txt", DayPart.First, 29940924880)]
    [TestCase("Day2.txt", DayPart.Second, 48631958998)]
    [TestCase("Day2Example.txt", DayPart.First, 1227775554)]
    [TestCase("Day2Example.txt", DayPart.Second, 4174379265)]
    public async Task Day2(string resource, DayPart part, long result)
        => Assert.That(await new Day2().Part(part, resource), Is.EqualTo(result));

    [TestCase("Day3.txt", DayPart.First, 17613)]
    [TestCase("Day3.txt", DayPart.Second, 175304218462560)]
    [TestCase("Day3Example.txt", DayPart.First, 357)]
    [TestCase("Day3Example.txt", DayPart.Second, 3121910778619)]
    public async Task Day3(string resource, DayPart part, long result)
        => Assert.That(await new Day3().Part(part, resource), Is.EqualTo(result));

    [TestCase("Day4.txt", DayPart.First, 1502)]
    [TestCase("Day4.txt", DayPart.Second, 9083)]
    [TestCase("Day4Example.txt", DayPart.First, 13)]
    [TestCase("Day4Example.txt", DayPart.Second, 43)]
    public async Task Day4(string resource, DayPart part, int result)
        => Assert.That(await new Day4().Part(part, resource), Is.EqualTo(result));

    [TestCase("Day5.txt", DayPart.First, 640)]
    [TestCase("Day5.txt", DayPart.Second, 365804144481581)]
    [TestCase("Day5Example.txt", DayPart.First, 3)]
    [TestCase("Day5Example.txt", DayPart.Second, 14)]
    public async Task Day5(string resource, DayPart part, long result)
        => Assert.That(await new Day5().Part(part, resource), Is.EqualTo(result));

    [TestCase("Day6.txt", DayPart.First, 4878670269096UL)]
    [TestCase("Day6.txt", DayPart.Second, 8674740488592UL)]
    [TestCase("Day6Example.txt", DayPart.First, 4277556UL)]
    [TestCase("Day6Example.txt", DayPart.Second, 3263827UL)]
    public async Task Day6(string resource, DayPart part, ulong result)
        => Assert.That(await new Day6().Part(part, resource), Is.EqualTo(result));

    [TestCase("Day7.txt", DayPart.First, 1649)]
    [TestCase("Day7.txt", DayPart.Second, 16937871060075)]
    [TestCase("Day7Example.txt", DayPart.First, 21)]
    [TestCase("Day7Example.txt", DayPart.Second, 40)]
    public async Task Day7(string resource, DayPart part, long result)
        => Assert.That(await new Day7().Part(part, resource), Is.EqualTo(result));

    [TestCase("Day8.txt", DayPart.First, 13024)]
    [TestCase("Day8.txt", DayPart.Second, 9271575747)]
    [TestCase("Day8Example.txt", DayPart.First, 40)]
    [TestCase("Day8Example.txt", DayPart.Second, 25272)]
    public async Task Day8(string resource, DayPart part, long result)
        => Assert.That(await new Day8().Part(part, resource), Is.EqualTo(result));

    [TestCase("Day9.txt", DayPart.First, 4735222687)]
    [TestCase("Day9.txt", DayPart.Second, 1569262188)]
    [TestCase("Day9Example.txt", DayPart.First, 50)]
    [TestCase("Day9Example.txt", DayPart.Second, 24)]
    public async Task Day9(string resource, DayPart part, long result)
        => Assert.That(await new Day9().Part(part, resource), Is.EqualTo(result));
}
