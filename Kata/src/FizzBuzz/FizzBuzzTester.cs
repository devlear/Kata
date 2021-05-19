using System;
using System.Collections.Generic;
using System.Linq;

namespace FizzBuzzExample
{
    public class FizzBuzz
    {
        public IEnumerable<string> Run(int n)
        {
            var rules = new FizzRule(new BuzzRule(new JazzRule(new NoMatchRule())));
            return Enumerable.Range(1, n)
                .Select(i => rules.RunCheck("", i))
                .ToList();
                //.Select(i => $"[{i}] {fizzBuzzTester.TestNumber(i)}");
        }

        private class JazzRule : IRule
        {
            private readonly IRule next;

            public JazzRule(IRule next)
            {
                this.next = next;
            }

            public string RunCheck(string current, int number)
            {
                if (number % 7 == 0)
                    current += "Jazz";
                return next.RunCheck(current, number);
            }
        }

        private class BuzzRule : IRule
        {
            private readonly IRule nextRule;

            public BuzzRule(IRule nextRule)
            {
                this.nextRule = nextRule;
            }

            public string RunCheck(string current, int number)
            {
                if (number % 5 == 0)
                    current += "Buzz";
                return nextRule.RunCheck(current, number);
            }
        }

        private class FizzRule : IRule
        {
            private readonly IRule nextRule;

            public FizzRule(IRule nextRule)
            {
                this.nextRule = nextRule;
            }

            public string RunCheck(string current, int number)
            {
                if (number % 3 == 0)
                    current += "Fizz";
                return nextRule.RunCheck(current, number);
            }
        }

        private class NoMatchRule : IRule
        {
            public string RunCheck(string current, int number)
            {
                if (string.IsNullOrEmpty(current))
                    return $"{number}";
                return current;
            }
        }

        public interface IRule
        {
            string RunCheck(string current, int number);
        }
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