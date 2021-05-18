using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzExample
{
    public class FizzBuzz
    {
        private readonly FizzBuzzTester fizzBuzzTester;
        private readonly FizzRule rules;

        public FizzBuzz(FizzBuzzTester fizzBuzzTester)
        {
            this.fizzBuzzTester = fizzBuzzTester;
            rules = new FizzRule(new BuzzRule(new NoMatchRule()));
        }

        public IEnumerable<string> Run(int n)
        {
            return Enumerable.Range(1, n)
                .Select(i => $"[{i}] {rules.RunCheck(i)}");
                //.Select(i => $"[{i}] {fizzBuzzTester.TestNumber(i)}");
        }
    }

    public class BuzzRule : IRule
    {
        private readonly IRule nextRule;

        public BuzzRule(IRule nextRule)
        {
            this.nextRule = nextRule;
        }

        public string RunCheck(int number)
        {
            string value = "";
            if (number % 5 == 0)
                value += "Buzz";
            return value += nextRule.RunCheck(number);
        }
    }

    public class FizzRule : IRule
    {
        private readonly IRule nextRule;

        public FizzRule(IRule nextRule)
        {
            this.nextRule = nextRule;
        }

        public string RunCheck(int number)
        {
            string value = "";
            if (number % 3 == 0) 
                value += "Fizz";
            return value += nextRule.RunCheck(number);
        }
    }

    public class NoMatchRule : IRule
    {
        public NoMatchRule()
        {

        }

        public string RunCheck(int number)
        {
            return "";
        }
    }

    public interface IRule
    {
        string RunCheck(int number);
    }

    public class FizzBuzzTester
    {
        public string TestNumber(int number)
        {
            return TestForFizz(number)
                .TestForBuzz(number);
        }

        private string TestForFizz(int number)
        {
            if (number % 3 == 0)
                return "Fizz";
            return "";
        }
    }

    public static class FizzBuzzExtensions
    {
        public static string TestForBuzz(this string input, int number)
        {
            if (number % 5 == 0)
                return input + "Buzz";
            return input;
        }
    }
}