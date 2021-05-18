using FluentAssertions;
using Xunit;

namespace FizzBuzzExample.Tests
{
    public class TestNumberTests
    {
        private readonly FizzBuzzTester tester;

        public TestNumberTests()
        {
            tester = new FizzBuzzTester();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        public void reply_with_Empty(int testNumber)
        {
            var result = tester.TestNumber(testNumber);

            result.Should().BeEmpty();
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        public void reply_with_Fizz(int testNumber)
        {
            var result = tester.TestNumber(testNumber);

            result.Should().Be("Fizz");
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public void reply_with_Buzz(int testNumber)
        {
            var result = tester.TestNumber(testNumber);

            result.Should().Be("Buzz");
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        public void reply_with_FizzBuzz(int testNumber)
        {
            var result = tester.TestNumber(testNumber);

            result.Should().Be("FizzBuzz");
        }
    }
}