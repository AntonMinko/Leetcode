using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions.DynamicProgramming
{
    /*
    Write a function canSum(targetSum, numbers) that takes in a targetSum and an array of numbers as arguments.
    The function should return a boolean indicating whether or not it is possible to generate the targetSum using numbers from the array.
    You may use an element of the array as many times as needed.
    You may assume that all input numbers are non-negative.

    m - targetSum
    n - numbers.Length
    O(m*n) time
    O(m) space (due to the recursion)
    
    */
    public class CanSumMemoization
    {
        public bool CanSum(int targetSum, int[] numbers, IDictionary<int, bool> memo = null)
        {
            if (targetSum == 0) return true;
            if (targetSum < 0) return false;
            if (memo != null && memo.ContainsKey(targetSum)) return memo[targetSum];

            if (memo == null)
            {
                memo = new Dictionary<int, bool>();
            }

            foreach (int n in numbers)
            {
                int newSum = targetSum - n;
                if (CanSum(newSum, numbers, memo))
                {
                    memo[targetSum] = true;
                    return true;
                }
            }

            memo[targetSum] = false;
            return false;
        }
    }

}