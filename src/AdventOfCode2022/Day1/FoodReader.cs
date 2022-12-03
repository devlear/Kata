namespace AdventOfCode2022.Day1
{
    public class FoodReader
    {
        private readonly TextReader _reader;

        public FoodReader(TextReader reader)
        {
            _reader = reader;
        }

        public int[] Next()
        {
            return _reader.NextBatch()
                .Select(int.Parse)
                .ToArray();
        }
    }

    public static class FoodReaderExtensions
    {
        public static IEnumerable<string> NextBatch(this TextReader reader)
        {
            string? line;
            while (!string.IsNullOrWhiteSpace(line = reader.ReadLine()))
            {
                yield return line;
            }
        }
    }
}
