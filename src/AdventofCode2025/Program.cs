using AdventofCode2025;

Console.WriteLine();
Console.WriteLine("===================================");
Console.WriteLine();

Console.WriteLine("Advent of Code 2025 - Day 1");

var password = Day01.GetPart1Solution();
var part2Password = Day01.GetPart2Solution();

Console.WriteLine($"Password: {password}");
Console.WriteLine($"Password (method 0x434C49434B): {part2Password}");

Console.WriteLine();
Console.WriteLine("===================================");
Console.WriteLine();

Console.WriteLine("Advent of Code 2025 - Day 2");

var invalidIdSum = Day02.GetPart1Solution();
var invalidIdSum2 = Day02.GetPart2Solution();

Console.WriteLine($"Invalid Product Id Sum: {invalidIdSum}");
Console.WriteLine($"Invalid Product Id Sum (2): {invalidIdSum2}");

Console.WriteLine();
Console.WriteLine("===================================");
Console.WriteLine();

Console.WriteLine("Advent of Code 2025 - Day 3");

var day03Part1Solution = Day03.GetPart1Solution();
var day03Part2Solution = Day03.GetPart2Solution();

Console.WriteLine($"Largest Joltage Rating: {day03Part1Solution}");
Console.WriteLine($"Largest Joltage Rating (Override): {day03Part2Solution}");

Console.WriteLine();
Console.WriteLine("===================================");
Console.WriteLine();

Console.WriteLine("Advent of Code 2025 - Day 4");

var day04Part1Solution = Day04.GetPart1Solution();
var day04Part2Solution = Day04.GetPart2Solution();

Console.WriteLine($"Part 1 Solution: {day04Part1Solution}");
Console.WriteLine($"Part 2 Solution: {day04Part2Solution}");

Console.WriteLine();
Console.WriteLine("===================================");
Console.WriteLine();


