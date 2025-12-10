namespace AdventOfCode;

sealed class Day03 : Day<long>
{
    protected override long CalculatePart1(string input)
    {
        var total = 0L;
        foreach (var bank in input.Split(Environment.NewLine))
        {
            var maxJoltage = 0L;
            for (var i1 = 0; i1 < bank.Length - 1; i1++)
            {
                for (var i2 = i1 + 1; i2 < bank.Length; i2++)
                {
                    var joltage = long.Parse($"{bank[i1]}{bank[i2]}");
                    maxJoltage = Math.Max(maxJoltage, joltage);
                }
            }

            total += maxJoltage;
        }

        return total;
    }

    protected override long CalculatePart2(string input)
    {
        var total = 0L;
        var batteryLength = 12;
        foreach (var bank in input.Split(Environment.NewLine))
        {
            var battery = new List<char>();
            int amount = bank.Length - batteryLength;
            foreach (var ch in bank)
            {
                while (battery.Count > 0 && amount > 0 && battery[^1] < ch)
                {
                    battery.RemoveAt(battery.Count - 1);
                    amount--;
                }

                battery.Add(ch);
            }

            var chosenBattery = battery.Take(batteryLength).ToArray();
            var joltage = long.Parse(new(chosenBattery));
            total += joltage;
        }

        return total;
    }
}
