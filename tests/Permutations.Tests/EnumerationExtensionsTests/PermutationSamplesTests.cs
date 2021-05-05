using FluentAssertions;
using System.Linq;
using Xunit;

namespace Permutations.Tests.EnumerationExtensionsTests
{
    public class PermutationSamplesTests
    {
        [Fact]
        public void transfigure_list_of_three_animals()
        {
            var zebra = new Animal("Zebra");
            var gorilla = new Animal("Gorilla");
            var anteater = new Animal("Anteater");
            var data = new[] {zebra, gorilla, anteater};

            var result = data.TransfigureLast()
                .ForEach(arraignment =>
                    string.Join(" ",
                        arraignment.Select(animal => animal.Type)));

            result.Should().ContainInOrder(
                "Zebra Gorilla Anteater",
                "Anteater Zebra Gorilla",
                "Gorilla Anteater Zebra");
        }

        [Fact]
        public void transfigure_list_of_5_letters()
        {
            var letters = new[] {"A", "B", "C", "D", "E"};

            var result = letters.TransfigureLast()
                .ForEach(arraignment =>
                    string.Join("",
                        arraignment.Select(letter => letter)));

            result.Should().ContainInOrder(
                "ABCDE",
                "EABCD",
                "DEABC",
                "CDEAB",
                "BCDEA");
        }
    }
}