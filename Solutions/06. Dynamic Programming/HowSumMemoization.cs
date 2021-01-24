using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions.DynamicProgramming
{
    /*
    Write a function HowSum(targetSum, numbers) that takes in a targetSum and an array of numbers as arguments.
    The function should return an array containing any combination of elements that add up to exactly the targetSum.
    If there are multiple combinations possible, you may return any single one.
    You may use an element of the array as many times as needed.
    You may assume that all input numbers are non-negative.

    m - targetSum
    n - numbers.Length
    O(m*n) time
    O(m) space
    
    */
    public class HowSumMemoization
    {
        public int[] HowSum(int targetSum, int[] numbers)
        {
            return HowSum(targetSum, numbers, new HashSet<int>())?.ToArray();
        }

        private IList<int> HowSum(int targetSum, int[] numbers, HashSet<int> failedAttempts)
        {
            if (targetSum == 0) return new List<int>();
            if (targetSum < 0) return null;
            if (failedAttempts.Contains(targetSum)) return null;

            foreach (int n in numbers)
            {
                int newSum = targetSum - n;
                var suffixList = HowSum(newSum, numbers, failedAttempts);
                if (suffixList != null)
                {
                    suffixList.Add(n);
                    return suffixList;
                }
            }

            failedAttempts.Add(targetSum);
            return null;
        }
    }

}