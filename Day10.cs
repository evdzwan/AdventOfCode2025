using Microsoft.Z3;

namespace AdventOfCode;

sealed class Day10 : Day<int>
{
    protected override int CalculatePart1(string input)
    {
        var machines = input.Split(Environment.NewLine)
                            .Select(line => line.Split(' '))
                            .Select(parts => (LightPattern: parts[0][1..^1].ToCharArray(),
                                              Buttons: parts[1..^1].Select(w => w[1..^1].Split(',').Select(int.Parse).ToArray()).ToArray(),
                                              JoltageRequirement: parts[^1][1..^1].Split(',').Select(int.Parse).ToArray()))
                            .Select(machine => Machine.FromParts(machine.LightPattern, machine.Buttons, machine.JoltageRequirement))
                            .ToArray();

        return machines.Select(m => m.CalculateMinimalButtonPresses()).Sum();
    }

    protected override int CalculatePart2(string input)
    {
        var machines = input.Split(Environment.NewLine)
                            .Select(line => line.Split(' '))
                            .Select(parts => (LightPattern: parts[0][1..^1].ToCharArray(),
                                              Buttons: parts[1..^1].Select(w => w[1..^1].Split(',').Select(int.Parse).ToArray()).ToArray(),
                                              JoltageRequirement: parts[^1][1..^1].Split(',').Select(int.Parse).ToArray()))
                            .Select(machine => Machine.FromParts(machine.LightPattern, machine.Buttons, machine.JoltageRequirement))
                            .ToArray();

        return machines.AsParallel().Select(m => m.CalculateMinimalButtonPressesForJoltageRequirement()).Sum();
    }

    sealed class Machine(int[] lightIndexes, int[][] buttons, int[] joltageRequirements)
    {
        public int CalculateMinimalButtonPresses()
            => CountOnes(Enumerable.Range(0, 1 << buttons.Length)
                                   .Where(pattern => PressButton(GetPressedButtonIndexes(pattern)).SequenceEqual(lightIndexes))
                                   .OrderBy(CountOnes)
                                   .First());

        public int CalculateMinimalButtonPressesForJoltageRequirement()
        {
            using var ctx = new Context();
            var optimize = ctx.MkOptimize();

            var buttonExpressions = buttons.Select((pattern, index) => ctx.MkIntConst($"b{index}")).ToArray();
            foreach (var expression in buttonExpressions)
            {
                optimize.Assert(ctx.MkGe(expression, ctx.MkInt(0)));
            }

            for (var bit = 0; bit < joltageRequirements.Length; bit++)
            {
                var target = joltageRequirements[bit];
                var terms = new List<ArithExpr>();

                for (var i = 0; i < buttons.Length; i++)
                {
                    if (buttons[i].Contains(bit))
                    {
                        terms.Add(buttonExpressions[i]);
                    }
                }

                if (terms.Count > 0)
                {
                    var sum = ctx.MkAdd([.. terms]);
                    optimize.Assert(ctx.MkEq(sum, ctx.MkInt(target)));
                }
            }

            var total = ctx.MkAdd(buttonExpressions);
            optimize.MkMinimize(total);
            optimize.Check();

            var model = optimize.Model;
            var value = model.Evaluate(total);
            return ((IntNum)value).Int;
        }

        static int CountOnes(int value)
            => System.Numerics.BitOperations.PopCount((uint)value);

        static List<int> GetPressedButtonIndexes(int pattern)
        {
            var indexes = new List<int>();
            for (var i = 0; pattern > 0; i++, pattern >>= 1)
            {
                if ((pattern & 1) != 0)
                {
                    indexes.Add(i);
                }
            }

            return indexes;
        }

        IOrderedEnumerable<int> PressButton(List<int> pressedButtonIndexes)
        {
            var activeIndices = new HashSet<int>();
            foreach (var index in pressedButtonIndexes)
            {
                foreach (var lightIndex in buttons[index])
                {
                    if (!activeIndices.Add(lightIndex))
                    {
                        activeIndices.Remove(lightIndex);
                    }
                }
            }

            return activeIndices.Order();
        }

        public static Machine FromParts(char[] lightPattern, int[][] buttons, int[] joltageRequirements)
            => new([.. lightPattern.Select((c, i) => (c, i)).Where(x => x.c == '#').Select(x => x.i)], buttons, joltageRequirements);
    }
}
