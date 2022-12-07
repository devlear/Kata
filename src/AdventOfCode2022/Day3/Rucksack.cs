namespace AdventOfCode2022.Day3
{
    public class Rucksack
    {
        public Rucksack()
        {
        }

        public static Rucksack Create(string contents)
        {
            var chunks = contents.Chunk(contents.Length / 2);
            return new Rucksack()
            {
                TotalContents = contents.ToCharArray(),
                CompartmentOne = chunks.First(),
                CompartmentTwo = chunks.Skip(1).First()
            };
        }


        public char[] TotalContents { get; set; }
        public char[] CompartmentOne { get; set; }
        public char[] CompartmentTwo { get; set; }

        public char GetDuplicate()
        {
            return CompartmentOne.Intersect(CompartmentTwo)
                .First();
        }
    }

    public class RucksackCalculator
    {
        public int GetPoints(char item)
        {
            return _points.IndexOf(item)+1;
        }

        private string _points = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    }
}
