namespace AdventOfCode;

sealed class Tests
{
    [TestCase("Day1.txt", 1123, 6695)]
    [TestCase("Day1Example.txt", 3, 6)]
    public async Task Day1(string resource, int part1Result, int part2Result)
    {
        var day = new Day1();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(await day.Part1(resource), Is.EqualTo(part1Result));
            Assert.That(await day.Part2(resource), Is.EqualTo(part2Result));
        }
    }

    [TestCase("Day2.txt", 29940924880, 48631958998)]
    [TestCase("Day2Example.txt", 1227775554, 4174379265)]
    public async Task Day2(string resource, long part1Result, long part2Result)
    {
        var day = new Day2();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(await day.Part1(resource), Is.EqualTo(part1Result));
            Assert.That(await day.Part2(resource), Is.EqualTo(part2Result));
        }
    }

    [TestCase("Day3.txt", 17613, 175304218462560)]
    [TestCase("Day3Example.txt", 357, 3121910778619)]
    public async Task Day3(string resource, long part1Result, long part2Result)
    {
        var day = new Day3();
        using (Assert.EnterMultipleScope())
        {
            Assert.That(await day.Part1(resource), Is.EqualTo(part1Result));
            Assert.That(await day.Part2(resource), Is.EqualTo(part2Result));
        }
    }
}
