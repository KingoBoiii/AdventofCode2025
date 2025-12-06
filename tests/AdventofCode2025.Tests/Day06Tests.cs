namespace AdventofCode2025.Tests;

public sealed class Day06Tests
{
    public static IEnumerable<object[]> Worksheet =>
    [
         [ "123 328  51 64 \r\n 45 64  387 23 \r\n  6 98  215 314\r\n*   +   *   +  \r\n" ]
    ];

    [Theory]
    [MemberData(nameof(Worksheet))]
    public void Part1_SumGrandTotal_ReturnsCorrectValue(string worksheet)
    {
        var solution = Day06.SumGrandTotal(worksheet);

        Assert.Equal("4277556", solution);
    }

    [Theory]
    [MemberData(nameof(Worksheet))]
    public void Part2_SumGrandTotal_ReturnsCorrectValue(string worksheet)
    {
        var solution = Day06.SumGrandTotalRightToLeft(worksheet);

        Assert.Equal("3263827", solution);
    }
}
