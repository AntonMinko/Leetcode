using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    494. Target Sum

    Link: https://leetcode.com/problems/target-sum/
    
    Difficulty: Medium

    Tags: DP, memoization, recursion

You are given a list of non-negative integers, a1, a2, ..., an, and a target, S. Now you have 2 symbols + and -. For each integer, you should choose one from + and - as its new symbol.

Find out how many ways to assign symbols to make sum of integers equal to target S.

Example 1:
Input: nums is [1, 1, 1, 1, 1], S is 3. 
Output: 5
Explanation: 
-1+1+1+1+1 = 3
+1-1+1+1+1 = 3
+1+1-1+1+1 = 3
+1+1+1-1+1 = 3
+1+1+1+1-1 = 3

There are 5 ways to assign symbols to make the sum of nums be target 3.

Constraints:
    The length of the given array is positive and will not exceed 20.
    The sum of elements in the given array will not exceed 1000.
    Your output answer is guaranteed to be fitted in a 32-bit integer.
    
    */
    public class TargetSum
    {
        public int FindTargetSumWays(int[] nums, int S)
        {
            return FindWays(nums, S, 0, new Dictionary<string, int>());
        }

        private int FindWays(int[] nums, int sum, int ind, Dictionary<string, int> memo)
        {
            if (ind == nums.Length)
            {
                return sum == 0 ? 1 : 0;
            }

            string key = $"{sum}_{ind}";
            if (memo.ContainsKey(key))
            {
                return memo[key];
            }

            int ways = FindWays(nums, sum + nums[ind], ind + 1, memo) +
                       FindWays(nums, sum - nums[ind], ind + 1, memo);
            memo[key] = ways;

            return ways;
        }
    }

}