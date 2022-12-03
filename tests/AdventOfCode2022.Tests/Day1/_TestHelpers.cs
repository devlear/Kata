using System.Text;

namespace AdventOfCode2022.Tests.Day1
{
    public  class _TestHelpers
    {
        public static TextReader GetTextReaderStreamFromString(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            var stream = new MemoryStream(bytes);
            return new StreamReader(stream);
        }
    }
}
