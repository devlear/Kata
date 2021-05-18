using FluentAssertions;
using Xunit;

namespace Permutations.Tests
{
    public class LeastCodePermutationTests
    {
        [Fact]
        public void transfigure_list_of_5_letters()
        {
            var result = SimplePermutation.PermutationOfString(5);

            result.Should().ContainInOrder(
                "ABCDE",
                "EABCD",
                "DEABC",
                "CDEAB",
                "BCDEA");
        }
    }
}