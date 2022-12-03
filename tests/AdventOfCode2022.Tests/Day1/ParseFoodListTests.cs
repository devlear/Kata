using AdventOfCode2022.Day1;
using FluentAssertions;

namespace AdventOfCode2022.Tests.Day1
{
    public class ParseFoodListTests
    {
        [Fact]
        public void given_new_line_number_string_then_list_of_int_should_be_create()
        {
            var stream = _TestHelpers.GetTextReaderStreamFromString(test1);
            var sut = new FoodReader(stream);

            int[] result = sut.Next();

            result.Length.Should().Be(5);
        }

        [Fact]
        public void given_food_list_has_empty_entries_then_split()
        {
            var stream = _TestHelpers.GetTextReaderStreamFromString(test2);
            var sut = new FoodReader(stream);

            int[] result1 = sut.Next();
            int[] result2 = sut.Next();
            int[] result3 = sut.Next();
            int[] result4 = sut.Next();

            result1.Length.Should().Be(2);
            result2.Length.Should().Be(1);
            result3.Length.Should().Be(3);
            result4.Length.Should().Be(0);
        }

        private string test1 =
@"1000
2000
3000
4000
5000";

        private string test2 =
@"1000
2000

3000

4000
5000
6000";
    }

}
