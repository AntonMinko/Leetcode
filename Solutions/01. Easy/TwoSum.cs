using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*

    1. Two Sum

    Link: https://leetcode.com/problems/two-sum/
    
    Difficulty: Easy

Given an array of integers nums and and integer target, return the indices of the two numbers such that they add up to target.
You may assume that each input would have exactly one solution, and you may not use the same element twice.
You can return the answer in any order.

Example 1:
Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Output: Because nums[0] + nums[1] == 9, we return [0, 1]

Example 2:
Input: nums = [3,2,4], target = 6
Output: [1,2]

Example 3:
Input: nums = [3,3], target = 6
Output: [0,1]

Constraints:
    1 <= nums.length <= 105
    -109 <= nums[i] <= 109
    -109 <= target <= 109
    Only one valid answer exists.
    
    */
    public class TwoSumSolution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>(nums.Length);

            for(int i=0; i< nums.Length; i++)
            {
                if (!numbers.ContainsKey(nums[i]))
                {
                    numbers.Add(nums[i], i);
                }
            }

            for(int i=0; i<nums.Length; i++)
            {
                int compNum = target - nums[i];
                if (numbers.ContainsKey(compNum) && numbers[compNum] != i)
                {
                    return new int[] { Math.Min(i, numbers[compNum]), Math.Max(i, numbers[compNum])};
                }
            }

            throw new Exception("something went wrong");
        }
    }

}