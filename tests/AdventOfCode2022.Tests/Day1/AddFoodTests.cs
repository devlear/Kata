using AdventOfCode2022.Day1;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;

namespace AdventOfCode2022.Tests.Day1
{
    /// <summary>
    /// Ensure counting of food works
    /// </summary>
    public class AddFoodTests
    {
        public readonly Fixture _fixture;

        public AddFoodTests()
        {
            _fixture = new Fixture();
        }

        [Theory]
        [AutoData]
        public void given_food_is_added_then_calories_should_match(Food food)
        {
            var sut = Elf.Create();

            sut.AddFood(food);

            sut.TotalCalories.Should().Be(food.Calories);
        }

        [Theory]
        [AutoData]
        public void given_multiple_food_items_are_added_then_calories_should_be_total(Food[] food)
        {
            var sut = Elf.Create();

            Array.ForEach(food, sut.AddFood);

            sut.TotalCalories.Should().Be(food.Sum(food => food.Calories));
        }
    }
}