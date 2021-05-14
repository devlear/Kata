using FluentAssertions;
using TwoSum;
using Xunit;

namespace TwoSumTests
{
    public class TwoSumSplitTests
    {
        [Fact]
        public void nums_only_contains_two_numbers()
        {
            var numberList = new[] { 10, 12 };
            var target = 22;

            var result = Solution.TwoSumSplit(numberList, target);

            result.Should().ContainInOrder(new[] { 0, 1 });
        }

        [Theory]
        [InlineData(3, 0, 1, 1, 2, 3, 4)]
        [InlineData(7, 2, 3, 1, 2, 3, 4)]
        [InlineData(5, 0, 3, 1, 2, 5, 4)]
        [InlineData(6, 1, 2, 1, 3, 3, 4)]
        [InlineData(6, 0, 2, 3, 2, 3)]
        public void array_target_contains(int target, int firstPosition, int secondPosition, params int[] nums)
        {
            var result = Solution.TwoSumSplit(nums, target);

            result.Should().Contain(new[] { firstPosition, secondPosition });
        }

        [Fact]
        public void test_runtime()
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            Solution.TwoSumSplit(Mother.LargeNumberList, 3);
            Solution.TwoSumSplit(Mother.LargeNumberList, 101);
            Solution.TwoSumSplit(Mother.LargeNumberList, 199);

            watch.Stop();

            watch.ElapsedTicks.Should().Be(100);
        }
    }
}