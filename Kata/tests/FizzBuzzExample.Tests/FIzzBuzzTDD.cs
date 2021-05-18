using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FizzBuzzExample.Tests
{
    public class FizzBuzzTDD
    {
        //For a set of numbers, 1 through N
        //If n is divisible by 3, print Fizz
        //If n is divisible by 5, print Buzz
        [Fact]
        public void when_n_is_1_result_should_be()
        {
            var fizzBuzz = new FizzBuzzTddActual();

            var result = fizzBuzz.Test(1);

            result.Should().BeEmpty();
        }
    }

    public class FizzBuzzTddActual
    {
        public string Test(int number)
        {
            return "";
        }
    }
}
