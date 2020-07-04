using System;
using System.Collections.Generic;

namespace Solutions
{
    /*
    Link: https://leetcode.com/problems/maximum-subarray/
    
    Difficulty: Easy

    Given an integer array nums, find the contiguous subarray (containing at least 
    one number) which has the largest sum and return its sum.

    Example:
    Input: [-2,1,-3,4,-1,2,1,-5,4],
    Output: 6
    Explanation: [4,-1,2,1] has the largest sum = 6.

    Follow up:
    If you have figured out the O(n) solution, try coding another solution 
    using the divide and conquer approach, which is more subtle.
    */
    public class MaximumSubArray
    {
        private enum Trend { Negative, Positive};
        public int MaxSubArray(int[] nums) {
            int max = nums[0];
            Trend trend = GetTrend(nums[0]);
            for (int i=1; i<nums.Length; i++)
            {
                max = Math.Max(nums[i], max);
                Trend currentValueTrend = GetTrend(nums[i]);
                if (trend == currentValueTrend)
                {
                    nums[i] += nums[i-1];
                    nums[i-1] = 0;
                }
                else
                {
                    trend = currentValueTrend;
                }
            }

            for(int i=0; i<nums.Length; i++)
            {
                if (nums[i] == 0) continue;

                int localMax = nums[i];
                int sum = nums[i];
                for(int j=i+1; j<nums.Length; j++)
                {
                    //if (nums[j] == 0) continue;
                    sum += nums[j];
                    localMax = Math.Max(sum, localMax);
                }

                max = Math.Max(localMax, max);
            }

            return max;
        }

        private Trend GetTrend(int num)
        {
            return num > 0 ? Trend.Positive : Trend.Negative;
        }

        // public int MaxSubArray(int[] nums) {
        //     int max = int.MinValue;
        //     for (int i=0; i<nums.Length; i++)
        //     {
        //         int localMax = nums[i];
        //         int sum = nums[i];
        //         for(int j=i+1; j<nums.Length; j++)
        //         {
        //             sum += nums[j];
        //             if (sum > localMax)
        //             {
        //                 localMax = sum;
        //             }
        //         }

        //         if (localMax > max)
        //         {
        //             max = localMax;
        //         }
        //     }

        //     return max;
        // }
    }
}