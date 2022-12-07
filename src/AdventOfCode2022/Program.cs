//Count all food on Elfs - done
//create a way to part file / string into int array - done
//Create elf and add food while parsing list
//Get elf with most TotalCalories

// See https://aka.ms/new-console-template for more information


using AdventOfCode2022.Day3;

var path = args[0];
var ruckSacks = new List<Rucksack>();
using (var reader = new StreamReader(path))
{
    string? line;
    while (!string.IsNullOrWhiteSpace(line = reader.ReadLine()))
    {
        ruckSacks.Add(
            Rucksack.Create(line));
    }
}

var calc = new RucksackCalculator();
var totalPriority = ruckSacks.Select(r => calc.GetPoints(r.GetDuplicate()))
    .Sum();

Console.WriteLine($"Total Priority: {totalPriority}");
