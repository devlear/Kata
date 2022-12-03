using AdventOfCode2022.Day1;
using AutoFixture;
using FluentAssertions;

namespace AdventOfCode2022
{
    public class AddFoodTests
    {
        public readonly Fixture _fixture;

        public AddFoodTests()
        {
            _fixture = new Fixture();
        }

        [Fact]
        public void when_adding_food_calorie_total_should_be()
        {
            var elf = Elf.Create();
            var food = _fixture.Build<Food>()
                .With(p => p.Calories, _ = _fixture.Create<int>())
                .Create();

            elf.AddFood(food);

            elf.TotalCalories.Should().Be(food.Calories);
        }
    }
}