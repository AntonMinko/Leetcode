using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    42. Trapping Rain Water

    Link: https://leetcode.com/problems/trapping-rain-water/
    
    Difficulty: Hard

Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it can trap after raining.

Example 1:
Input: height = [0,1,0,2,1,0,1,3,2,1,2,1]
Output: 6
Explanation: The above elevation map (black section) is represented by array [0,1,0,2,1,0,1,3,2,1,2,1]. In this case, 6 units of rain water (blue section) are being trapped.

Example 2:
Input: height = [4,2,0,3,2,5]
Output: 9

Constraints:
    n == height.length
    0 <= n <= 3 * 104
    0 <= height[i] <= 105

O(n) time
O(n) space
    */
    public class TrapRainWater2
    {
        public int Trap(int[] height)
        {
            if (height.Length <= 2) return 0;

            int[] left = new int[height.Length];
            int[] right = new int[height.Length];

            int max = 0;
            for (int i = 0; i < height.Length; i++)
            {
                if (height[i] > max)
                {
                    max = height[i];
                }

                left[i] = max;
            }

            max = 0;
            for (int i = height.Length - 1; i >= 0; i--)
            {
                if (height[i] > max)
                {
                    max = height[i];
                }

                right[i] = max;
            }

            int sum = 0;
            for (int i = 0; i < height.Length; i++)
            {
                sum += Math.Min(left[i], right[i]) - height[i];
            }

            return sum;
        }
    }
}