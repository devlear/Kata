﻿//Count all food on Elfs - done
//create a way to part file / string into int array - done
//Create elf and add food while parsing list
//Get elf with most TotalCalories

// See https://aka.ms/new-console-template for more information


using AdventOfCode2022.Day1;

var path = args[0];
var elfList = new List<Elf>();
using (var reader = new StreamReader(path))
{
    var foodReader = new FoodReader(reader);
    int[] foodValues;
    while ((foodValues = foodReader.Next()).Length != 0)
    {
        var food = foodValues.Select(calorie => new Food { Calories = calorie })
            .ToArray();
        var elf = Elf.Create();
        Array.ForEach(food, elf.AddFood);
        elfList.Add(elf);
    }
}

var sortedElves = elfList.OrderByDescending(elf => elf.TotalCalories);

var maxCalorie = sortedElves.Take(1).First().TotalCalories;

Console.WriteLine($"Biggest Calorie count is: {maxCalorie}");

var topX = 3;
var topXTotal = sortedElves.Take(topX).Sum(elf => elf.TotalCalories);

Console.WriteLine($"Top {topX} count is: {topXTotal}");