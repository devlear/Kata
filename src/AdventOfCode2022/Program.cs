//Count all food on Elfs - done
//create a way to part file / string into int array - done
//Create elf and add food while parsing list
//Get elf with most TotalCalories

// See https://aka.ms/new-console-template for more information


using AdventOfCode2022.Day1;

var path = args[0];

var elfList = FoodCounter.CountFood(path);
var maxCalorie = elfList.CountCaloriesForTopX(1);
Console.WriteLine($"Biggest Calorie count is: {maxCalorie}");

var topX = 3;
var topXTotal = elfList.CountCaloriesForTopX(topX);

Console.WriteLine($"Top {topX} count is: {topXTotal}");
