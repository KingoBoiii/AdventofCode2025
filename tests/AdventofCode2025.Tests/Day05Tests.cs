namespace AdventofCode2025.Tests;

public sealed class Day05Tests
{
    public static IEnumerable<object[]> IngredientIds =>
    [
         [ new [] {
            "3-5",
            "10-14",
            "16-20",
            "12-18",
            "",
            "1",
            "5",
            "8",
            "11",
            "17",
            "32"
        } ]
    ];

    [Theory]
    [MemberData(nameof(IngredientIds))]
    public void Part1_CountFreshIngredients_ReturnsCorrectValue(string[] ingredientIds)
    {
        var solution = Day05.CountFreshIngredients(ingredientIds);

        Assert.Equal("3", solution);
    }

    [Theory]
    [MemberData(nameof(IngredientIds))]
    public void Part2_CountFreshIngredients_ReturnsCorrectValue(string[] ingredientIds)
    {
        var solution = Day05.CountFreshIngredientIds(ingredientIds);

        Assert.Equal("14", solution);
    }
}
