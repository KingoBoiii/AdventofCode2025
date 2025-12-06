namespace AdventofCode2025.Tests;

public sealed class Day04Tests
{
    public static IEnumerable<object[]> PaperRollsGrid => new List<object[]>
    {
        new object[] { new [] {
            "..@@.@@@@.",
            "@@@.@.@.@@",
            "@@@@@.@.@@",
            "@.@@@@..@.",
            "@@.@@@@.@@",
            ".@@@@@@@.@",
            ".@.@.@.@@@",
            "@.@@@.@@@@",
            ".@@@@@@@@.",
            "@.@.@@@.@.",
        } }
    };

    [Theory]
    [MemberData(nameof(PaperRollsGrid))]
    public void Part1_SumJoltageRatings_ReturnsCorrectValue(string[] paperRollsGrid)
    {
        var solution = Day04.CountAccessible(paperRollsGrid);

        Assert.Equal("13", solution);
    }

    [Theory]
    [MemberData(nameof(PaperRollsGrid))]
    public void Part2_SumJoltageRatings_ReturnsCorrectValue(string[] paperRollsGrid)
    {
        var solution = Day04.CountTotalAccessible(paperRollsGrid);

        Assert.Equal("43", solution);
    }
}
