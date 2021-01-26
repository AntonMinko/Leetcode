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

    */
    public class TrapRainWater
    {
        public int Trap(int[] height)
        {
            if (height.Length <= 2) return 0;

            int sum = 0;
            int leftSide = height[0];
            int min = leftSide;
            for (int i = 1; i < height.Length; i++)
            {
                int curSide = height[i];
                if (curSide < min)
                {
                    min = curSide;
                }
                if (curSide > min && leftSide > min)
                {
                    int level = Math.Min(leftSide, curSide);
                    int pos = i - 1;
                    while (height[pos] < level)
                    {
                        sum += level - height[pos];
                        height[pos] = level;
                        pos--;
                    }
                }
                if (curSide >= leftSide)
                {
                    leftSide = curSide;
                    min = leftSide;
                }
            }

            return sum;
        }
    }
}