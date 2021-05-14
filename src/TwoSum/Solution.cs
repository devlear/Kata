using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace TwoSum
{
    /// <summary>
    /// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
    ///You may assume that each input would have exactly one solution, and you may not use the same element twice.
    ///You can return the answer in any order.
    /// 
    ///Constraints:
    /// 2 <= nums.length <= 1000
    ///-1000000000 <= nums[i] <= 1000000000
    /// -1000000000 <= target <= 1000000000
    ///Only one valid answer exists.
    ///
    /// https://leetcode.com/problems/two-sum/
    /// </summary>
    /// <example>
    ///Input: nums = [2,7,11,15], target = 9
    ///Output: [0,1]
    ///Output: Because nums[0] + nums[1] == 9, we return [0, 1].
    /// </example>
    [SuppressMessage("ReSharper", "InvalidXmlDocComment")]
    public static class Solution
    {
        public static int[] TwoSumBruteForce(int[] nums, int target)
        {
            int[] answer = new[] {0, 1};
            if (nums.Length == 2)
                return answer;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        answer = new[] {i, j};
                        break;
                    }
                }
            }

            return answer;
        }

        public static int[] TwoSumSplit(int[] nums, int target)
        {
            if (nums.Length == 2)
                return new[] {0, 1};

            HashSet<NumberLocation> numbersHash = new HashSet<NumberLocation>();
            for (var i = 0; i < nums.Length; i++)
            {
                numbersHash.Add(new NumberLocation(nums[i], i));
            }

            int addendsCount = target / 2;
            HashSet<int> addendHash = new HashSet<int>(Enumerable.Range(1, addendsCount));
            if (nums.Length/2 > addendsCount)
            {
                return TwoSumAddends(target, numbersHash, addendHash);
            }
            else
            {
                return TwoSumNumberHash(nums, target, numbersHash, addendHash);
            }
        }

        public static int[] TwoSumNumberHash(int[] numbers, int target,
            HashSet<NumberLocation> numberHash, HashSet<int> addendHash)
        {
            int[] answer = new[] {0, 1};
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                var findNumber = target - numbers[i];
                if (findNumber > 0)
                {
                    if (addendHash.Contains(numbers[i]))
                    {
                        if (numberHash.TryGetValue(new NumberLocation(findNumber, 0), out NumberLocation results)
                        && i != results.Index)
                        {
                            //get index of number and hashedNumber
                            answer = new[] {i, results.Index};
                            break;
                        }
                    }
                }
            }

            return answer;
        }

        public static int[] TwoSumAddends(int target,
            HashSet<NumberLocation> numberHash, HashSet<int> addendHash)
        {
            int[] answer = new[] { 0, 1 };
            foreach (var addend in addendHash)
            {
                if (numberHash.TryGetValue(new NumberLocation(addend, 0), out NumberLocation firstNumber))
                {
                    var findNumber = target - addend;
                    if (numberHash.TryGetValue(new NumberLocation(findNumber, 0), out NumberLocation secondNumber)
                    && secondNumber.Index != firstNumber.Index)
                    {
                        //get index of number and hashedNumber
                        answer = new[] {firstNumber.Index, secondNumber.Index};
                        break;
                    }
                }
            }

            return answer;
        }
    }

    public class NumberLocation : IEquatable<NumberLocation>
    {
        public NumberLocation(int value, int index)
        {
            Value = value;
            Index = index;
        }

        public int Value { get; }
        public int Index { get; }

        public override int GetHashCode()
        {
            return Value;
        }

        public bool Equals(NumberLocation other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Value == other.Value;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NumberLocation) obj);
        }

        public static bool operator ==(NumberLocation left, NumberLocation right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(NumberLocation left, NumberLocation right)
        {
            return !Equals(left, right);
        }
    }
}