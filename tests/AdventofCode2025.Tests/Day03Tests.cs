namespace AdventofCode2025.Tests;

public sealed class Day03Tests
{
    public static IEnumerable<object[]> JoltageRatings => new List<object[]>
    {
        new object[] { new [] {
            "987654321111111",
            "811111111111119",
            "234234234234278",
            "818181911112111"
        } }
    };

    [Theory]
    [MemberData(nameof(JoltageRatings))]
    public void Part1_SumJoltageRatings_ReturnsCorrectValue(string[] joltageRatings)
    {
        var solution = Day03.GetLargestSum(joltageRatings);

        Assert.Equal("357", solution);
    }
}
