namespace AdventofCode2025.Tests;

public sealed class Day07Tests
{
    public static IEnumerable<object[]> TachyonManifold =>
    [
         [".......S.......\r\n...............\r\n.......^.......\r\n...............\r\n......^.^......\r\n...............\r\n.....^.^.^.....\r\n...............\r\n....^.^...^....\r\n...............\r\n...^.^...^.^...\r\n...............\r\n..^...^.....^..\r\n...............\r\n.^.^.^.^.^...^.\r\n..............."]
    ];

    [Theory]
    [MemberData(nameof(TachyonManifold))]
    public void Part1_CountSplitOfTachyonManifold_ReturnsCorrectValue(string tachyonManifold)
    {
        var solution = Day07.CountTachyonManifoldSplit(tachyonManifold);

        Assert.Equal("21", solution);
    }

    [Theory]
    [MemberData(nameof(TachyonManifold))]
    public void Part2_CountSplitOfTachyonManifold_ReturnsCorrectValue(string tachyonManifold)
    {
        var solution = Day07.CountQuantumTachyonManifoldSplit(tachyonManifold);

        Assert.Equal("40", solution);
    }
}
