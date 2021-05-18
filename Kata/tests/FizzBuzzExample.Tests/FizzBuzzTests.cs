using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FizzBuzzExample.Tests
{
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(5)]
        public void RunTest(int number)
        {
            var fizzBuzzTester = new FizzBuzzTester();
            var fizzBuzz = new FizzBuzz(fizzBuzzTester);

            var actual = fizzBuzz.Run(number);

            actual.Should().ContainInOrder(expected);
        }

        private IEnumerable<string> expected = new[] { "[1] ", "[2] ", "[3] Fizz", "[4] ", "[5] Buzz" };
    }
}