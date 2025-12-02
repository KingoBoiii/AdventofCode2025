namespace AdventofCode2025.Tests;

public sealed class Day1Tests
{
    public static IEnumerable<object[]> ExampleLines => new List<object[]>
    {
        new object[] { new[] {
            "L68",
            "L30",
            "R48",
            "L5",
            "R60",
            "L55",
            "L1",
            "L99",
            "R14",
            "L82" } 
        }
    };

    [Theory]
    [MemberData(nameof(ExampleLines))]
    public void Day1_Part1_Example_Password_ReturnsCorrectValue(string[] lines)
    {
        var examplePassword = Day1.GetPart1Password(lines);

        Assert.Equal("3", examplePassword);
    }

    [Theory]
    [MemberData(nameof(ExampleLines))]
    public void Day1_Part2_Example_Password_ReturnsCorrectValue(string[] lines)
    {
        var examplePassword = Day1.GetPart2Password(lines);

        Assert.Equal("6", examplePassword);
    }
}
