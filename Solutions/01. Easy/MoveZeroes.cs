using System;
using System.Collections.Generic;

namespace Solutions
{
    /*
    Link: https://leetcode.com/problems/move-zeroes/
    
    Difficulty: Easy

    Given an array nums, write a function to move all 0's to the end of it 
    while maintaining the relative order of the non-zero elements.

    Example:
    Input: [0,1,0,3,12]
    Output: [1,3,12,0,0]

    Note:
        You must do this in-place without making a copy of the array.
        Minimize the total number of operations.

    */
    public class MoveZeroesSolution
    {
        public void MoveZeroes(int[] nums)
        {
            if (nums.Length < 2) return;

            int nonZeroIndex = 0;
            for (int i=0; i<nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    continue;
                }

                //Non-zero element:
                if (i == nonZeroIndex)
                {
                    ++nonZeroIndex;
                    continue;
                }

                nums[nonZeroIndex] = nums[i];
                ++nonZeroIndex;
            }

            for (int i=nonZeroIndex; i<nums.Length; i++)
            {
                nums[i] = 0;
            }
        }
    }

}