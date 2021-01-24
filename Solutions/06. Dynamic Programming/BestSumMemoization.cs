using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions.DynamicProgramming
{
    /*
    Write a function BestSum(targetSum, numbers) that takes in a targetSum and an array of numbers as arguments.
    The function should return an array containing the shortest combination of elements that add up to exactly the targetSum.
    If there is a tie for the shortest combination, you may return any one of the shortest.
    You may use an element of the array as many times as needed.
    You may assume that all input numbers are non-negative.

    m - targetSum
    n - numbers.Length
    O(m*n) time
    O(m*n) space
    
    */
    public class BestSumMemoization
    {
        public int[] BestSum(int targetSum, int[] numbers)
        {
            numbers = numbers.OrderByDescending(n => n).ToArray();
            return BestSum(targetSum, numbers, new Dictionary<int, int[]>())?.ToArray();
        }

        private List<int> BestSum(int targetSum, int[] numbers, Dictionary<int, int[]> memo)
        {
            if (targetSum == 0) return new List<int>();
            if (targetSum < 0) return null;
            if (memo.ContainsKey(targetSum)) return memo[targetSum] != null ? memo[targetSum].ToList() : null;

            List<int> shortestSum = null;
            foreach (int n in numbers)
            {
                var candidateSum = BestSum(targetSum - n, numbers, memo);
                if (candidateSum == null) continue;

                if (shortestSum == null || shortestSum.Count > candidateSum.Count + 1)
                {
                    candidateSum.Insert(0, n);
                    shortestSum = candidateSum;
                }
            }

            memo[targetSum] = shortestSum?.ToArray();
            return shortestSum;
        }
    }

}