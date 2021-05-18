using System;
using System.Collections.Generic;

namespace Permutations
{
    public class SimplePermutation
    {
        public const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static IEnumerable<string> PermutationOfString(int numberOfLetters)
        {
            if (numberOfLetters < 1)
                throw new ArgumentOutOfRangeException(nameof(numberOfLetters), "Must be a number between 1 and 26");
            if (numberOfLetters > 26)
                throw new ArgumentOutOfRangeException(nameof(numberOfLetters), "Must be a number between 1 and 26");
            var letters = Letters.Substring(0, numberOfLetters);
            List<string> arraignments = new List<string> {letters};
            for (int i = 0; i < numberOfLetters; i++)
            {
                letters = letters.Substring(numberOfLetters-1, 1) + letters.Substring(0, numberOfLetters - 1);
                arraignments.Add(letters);
            }

            return arraignments;
        }
    }
}