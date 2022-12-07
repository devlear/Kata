using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day3
{
    public static class ElfExtensions
    {
        public static IEnumerable<T[]> GroupByThree<T>(this IEnumerable<T> selector)
        {
            return selector.Chunk(3);
        }

        public static IEnumerable<char> GetElvesIntersections(this IEnumerable<Rucksack[]> elfGroups)
        {
            foreach (var elfGroup in elfGroups)
            {
                var contents = elfGroup.Select(x => x.TotalContents);
                var contentsOne = contents.First();
                var contentsTwo = contents.Skip(1).First();
                var contentsThree = contents.Skip(2).First();
                var intersection = Enumerable.Intersect(contentsOne, contentsTwo);
                yield return intersection.Intersect(contentsThree).First();
            }
        }
    }
}
