using AdventOfCode2022.Day3;
using FluentAssertions;

namespace AdventOfCode2022.Tests.Day3
{
    public class Test3
    {
        [Fact]
        public void given_a_string_then_it_should_be_split_in_half()
        {
            var input = "vJrwpWtwJgWrhcsFMMfFFhFp";

            var result = Rucksack.Create(input);

            result.CompartmentOne.Count().Should().Be(
                result.CompartmentTwo.Count());
        }

        [Fact]
        public void given_two_compartments_find_duplicate_character()
        {
            var sut = new Rucksack();
            sut.CompartmentOne = "vJrwpWtwJgWr".ToCharArray();
            sut.CompartmentTwo = "hcsFMMfFFhFp".ToCharArray();

            var result = sut.GetDuplicate();

            result.Should().Be('p');
        }

        [Theory]
        [InlineData('a', 1)]
        [InlineData('c', 3)]
        [InlineData('z', 26)]
        [InlineData('A', 27)]
        [InlineData('Z', 52)]
        public void given_letters_values_should_be(char item, int points)
        {
            var sut = new RucksackCalculator();

            var result = sut.GetPoints(item);

            result.Should().Be(points);
        }

        [Fact]
        public void test_whole_thing()
        {
            var input = "vJrwpWtwJgWrhcsFMMfFFhFp";
            var sut = Rucksack.Create(input);
            var calc = new RucksackCalculator();

            var result = calc.GetPoints(sut.GetDuplicate());

            result.Should().Be(16);
        }
    }
}
