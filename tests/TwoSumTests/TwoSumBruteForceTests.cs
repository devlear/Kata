using FluentAssertions;
using TwoSum;
using Xunit;

namespace TwoSumTests
{
    public class TwoSumBruteForceTests
    {
        [Fact]
        public void nums_only_contains_two_numbers()
        {
            var numberList = new[] {10, 12};
            var target = 22;

            var result = Solution.TwoSumBruteForce(numberList, target);

            result.Should().ContainInOrder(new[] {0, 1});
        }

        [Theory]
        [InlineData(3, 0, 1, 1, 2, 3, 4)]
        [InlineData(7, 2, 3, 1, 2, 3, 4)]
        [InlineData(5, 1, 2, 1, 2, 3, 5)]
        public void array_target_contains(int target, int firstPosition, int secondPosition, params int[] nums)
        {
            var result = Solution.TwoSumBruteForce(nums, target);

            result.Should().ContainInOrder(new[] {firstPosition, secondPosition});
        }

        [Fact]
        public void test_runtime()
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();

            Solution.TwoSumBruteForce(Mother.LargeNumberList, 3);
            Solution.TwoSumBruteForce(Mother.LargeNumberList, 101);
            Solution.TwoSumBruteForce(Mother.LargeNumberList, 199);

            watch.Stop();

            watch.ElapsedTicks.Should().Be(100);
        }
        /*
         * Thoughts:
         * If Target is 3 possible numbers that can add up to that are:
         * 1, 2
         * If Target is 5 possible numbers that can add up to that are:
         * [1, 4], [2, 3]
         * If Target is 7 possible numbers that can add up to that are:
         * [1, 6], [2, 5], [3, 4]
         * If Target is 8 possible numbers that can add up to that are:
         * [1, 7], [2, 6], [3, 5], [4, 4]
         *
         * If N^2 brute force, can use hash to reduce size of set, but still N^2
         * If 
         */
    }
}