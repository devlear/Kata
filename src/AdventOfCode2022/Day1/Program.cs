//Count all food on Elfs - done
//create a way to part file / string into int array - done
//Create elf and add food while parsing list
//Get elf with most TotalCalories

// See https://aka.ms/new-console-template for more information


using AdventOfCode2022.Day1;
using AdventOfCode2022.Day2;
using System.Runtime.CompilerServices;

var path = args[0];
var matches = new List<Match>();
var factory = new HandSignFactory();
using (var reader = new StreamReader(path))
{
    string? line;
    while(!string.IsNullOrEmpty(line = reader.ReadLine()))
    {
        matches.Add(
            new Match(
                factory.GetSign(line.First()),
                factory.GetSign(line.Skip(2).First())));
    }
}

var tourneyTotal = matches.Sum(match => match.Shoot());
Console.WriteLine($"total points is: {tourneyTotal}");