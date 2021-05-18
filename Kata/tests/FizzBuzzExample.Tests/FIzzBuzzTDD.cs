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
        private readonly FizzBuzzTddActual fizzBuzz;

        public FizzBuzzTDD()
        {
            fizzBuzz = new FizzBuzzTddActual();
        }

        [Fact]
        public void when_n_is_1_result_should_be()
        {
            var result = fizzBuzz.Test(1);

            result.Should().BeEmpty();
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(12)]
        public void when_n_is_factor_of_3_result_should_be(int number)
        {
            var result = fizzBuzz.Test(number);

            result.Should().Be("Fizz");
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public void when_n_is_factor_of_5_result_should_be(int number)
        {
            var result = fizzBuzz.Test(number);

            result.Should().Be("Buzz");
        }
    }

    public class FizzBuzzTddActual
    {
        private readonly BuzzRuleTdd buzz;

        public FizzBuzzTddActual()
        {
            var nullRull = new DefaultRuleTdd();
            var fizz = new FizzRuleTdd(nullRull);
            buzz = new BuzzRuleTdd(fizz);
        }

        public string Test(int number)
        {
            return buzz.Test(number);
        }
    }

    public class FizzRuleTdd : IRuleTdd
    {
        private readonly IRuleTdd next;

        public FizzRuleTdd(IRuleTdd next)
        {
            this.next = next;
        }

        public string Test(int number)
        {
            if (number % 3 == 0)
                return "Fizz";
            return next.Test(number);
        }
    }

    public class BuzzRuleTdd : IRuleTdd
    {
        private readonly IRuleTdd next;

        public BuzzRuleTdd(IRuleTdd next)
        {
            this.next = next;
        }

        public string Test(int number)
        {
            if (number % 5 == 0)
                return "Buzz";
            return next.Test(number);
        }
    }

    public class DefaultRuleTdd : IRuleTdd
    {
        public string Test(int number)
        {
            return string.Empty;
        }
    }

    public interface IRuleTdd
    {
        string Test(int number);
    }
}