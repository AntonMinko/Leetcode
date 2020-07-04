using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    Contiguous Array

    Link: https://leetcode.com/problems/contiguous-array/
    
    Difficulty: Medium

    Given a binary array, find the maximum length of a contiguous subarray with equal number of 0 and 1.

Example 1:

Input: [0,1]
Output: 2
Explanation: [0, 1] is the longest contiguous subarray with equal number of 0 and 1.

Example 2:

Input: [0,1,0]
Output: 2
Explanation: [0, 1] (or [1, 0]) is a longest contiguous subarray with equal number of 0 and 1.

Note: The length of the given binary array will not exceed 50,000. 
    */
    public class ContiguousArray
    {
        public int FindMaxLength(int[] nums)
        {
            if (nums.Length < 2) return 0;

            var firstFounds = new Dictionary<int, int>();
            firstFounds.Add(0, -1);
            int maxLength = 0;
            int diff = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                diff += nums[i] == 1 ? 1 : -1;
                if (firstFounds.ContainsKey(diff))
                {
                    maxLength = Math.Max(maxLength, i - firstFounds[diff]);
                }
                else
                {
                    firstFounds[diff] = i;
                }
            }

            return maxLength;
        }
    }

}