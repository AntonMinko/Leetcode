using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    75. Sort Colors

    Link: https://leetcode.com/problems/sort-colors/
    
    Difficulty: Medium

Given an array nums with n objects colored red, white, or blue, sort them in-place so that objects of the same color are adjacent, with the colors in the order red, white, and blue.
We will use the integers 0, 1, and 2 to represent the color red, white, and blue, respectively.

Example 1:
Input: nums = [2,0,2,1,1,0]
Output: [0,0,1,1,2,2]

Example 2:
Input: nums = [2,0,1]
Output: [0,1,2]

Example 3:
Input: nums = [0]
Output: [0]

Example 4:
Input: nums = [1]
Output: [1]
    
    Complexity:
        O(n) time complexity
        O(1) space complexity
    */
    public class SortColorsInArray
    {
        public void SortColors(int[] nums)
        {
            int red = 0;
            int cur = 0;
            int blue = nums.Length - 1;

            while (cur <= blue)  // blue is pointing to the next possible blue position, so analyze this color
            {
                if (nums[cur] == 0)
                {
                    if (cur != red)
                    {
                        nums[red] = 0;
                        nums[cur] = 1;
                    }
                    cur++;
                    red++;
                }
                else if (nums[cur] == 2)
                {
                    nums[cur] = nums[blue];
                    nums[blue] = 2;
                    blue--;
                    //cur++; - do not increment cur as color on nums[blue] could have been red so we still need to swap it
                }
                else
                {
                    cur++;
                }
            }
        }
    }

}