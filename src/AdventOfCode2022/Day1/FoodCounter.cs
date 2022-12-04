using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day1
{
    public static class FoodCounter
    {
        public static IEnumerable<Elf> CountFood(string path)
        {
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
            return elfList.AsEnumerable();
        }

        public static int CountCaloriesForTopX(this IEnumerable<Elf> elves, int topX)
        {
            var sortedElves = elves.OrderByDescending(elf => elf.TotalCalories);
            return sortedElves.Take(topX)
                .First()
                .TotalCalories;
        }
    }
}
