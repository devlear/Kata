//Count all food on Elfs - done
//create a way to part file / string into int array - done
//Create elf and add food while parsing list
//Get elf with most TotalCalories

// See https://aka.ms/new-console-template for more information


using AdventOfCode2022.Day4;

var path = args[0];
int more = 0;
using (var reader = new StreamReader(path))
{
    string? line;
    while (!string.IsNullOrWhiteSpace(line = reader.ReadLine()))
    {
        var twoParts = line.Split(',');
        var elfPair = twoParts.Select(x =>
        {
            int[] two = x.Split('-').Select(x => int.Parse(x)).ToArray();
            var elf = new Elf();
            elf.SetAssignments(two[0], two[1]);
            return elf;
        }).ToArray();

        if (CompareThings.Overlapping(elfPair[0], elfPair[1]))
        {
            more++;
        }
    }
}


Console.WriteLine($"Total Priority: {more}");
