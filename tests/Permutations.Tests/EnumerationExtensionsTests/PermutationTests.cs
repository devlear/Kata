using FluentAssertions;
using System.Linq;
using Xunit;

namespace Permutations.Tests.EnumerationExtensionsTests
{
    public class PermutationTests
    {
        [Fact]
        public void permutations_of_length_one()
        {
            object[] data = {new Animal("Zebra")};

            var result = data.TransfigureLast().ToArray();

            result.Length.Should().Be(data.Length);
            result.First().Should().ContainInOrder(data);
        }

        [Fact]
        public void permutations_of_length_two()
        {
            var zebra = new Animal("Zebra");
            var gorilla = new Animal("Gorilla");
            object[] data = {zebra, gorilla};

            var result = data.TransfigureLast().ToArray();

            result.Length.Should().Be(data.Length);
            result[0].Should().ContainInOrder(zebra, gorilla);
            result[1].Should().ContainInOrder(gorilla, zebra);
        }

        [Fact]
        public void permutations_of_length_three()
        {
            var zebra = new Animal("Zebra");
            var gorilla = new Animal("Gorilla");
            var anteater = new Animal("Anteater");
            object[] data = { zebra, gorilla, anteater };

            var result = data.TransfigureLast().ToArray();

            result.Length.Should().Be(data.Length);
            result[0].Should().ContainInOrder(zebra, gorilla, anteater);
            result[1].Should().ContainInOrder(anteater, zebra, gorilla);
            result[2].Should().ContainInOrder(gorilla, anteater, zebra);
        }
    }
}