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
        [InlineData(7)]
        public void RunTest(int number)
        {
            var fizzBuzz = new FizzBuzz();

            var actual = fizzBuzz.Run(number);

            actual.Should().ContainInOrder(expected);
        }

        private IEnumerable<string> expected = new[] { "1", "2", "Fizz", "4", "Buzz", "Fizz", "Jazz" };
    }
}