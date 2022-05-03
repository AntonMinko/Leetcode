using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    581. Shortest Unsorted Continuous Subarray

    Link: https://leetcode.com/problems/shortest-unsorted-continuous-subarray/
    
    Difficulty: Medium

Given an integer array nums, you need to find one continuous subarray that if you only sort this subarray in ascending order, 
then the whole array will be sorted in ascending order.
Return the shortest such subarray and output its length.

Example 1:
Input: nums = [2,6,4,8,10,9,15]
Output: 5
Explanation: You need to sort [6, 4, 8, 10, 9] in ascending order to make the whole array sorted in ascending order.

Example 2:
Input: nums = [1,2,3,4]
Output: 0

Example 3:
Input: nums = [1]
Output: 0

Constraints:
    1 <= nums.length <= 104
    -105 <= nums[i] <= 105

Follow up: Can you solve it in O(n) time complexity?
    
    Complexity:
        O(n) time complexity
        O(1) space complexity
    */
    
    public class ShortestUnsortedSubarray
    {
        public int FindUnsortedSubarray(int[] nums)
        {
            int N = nums.Length;

            // 1. Find the unsorted sub array [l,r)
            int l = 0;
            for (int i = 1; i < N; i++)
            {
                if (nums[i - 1] > nums[i])
                {
                    l = i;
                    break;
                }
            }

            if (l == 0) return 0;

            int r = N - 1;
            for (int i = N - 1; i > 0; i--)
            {
                if (nums[i - 1] > nums[i] || nums[i] == nums[l])
                {
                    r = i;
                    break;
                }
            }

            // 2. Extend the search scope to [l-1,r] and find min,max.
            // Scope extension required to cover cases like this: [1,5,2,3], [1,3,2,1,2,5], [1,5,3,3,4]
            int min = nums[l];
            int max = nums[r];
            for (int i = l - 1; i <= r; i++)
            {
                min = Math.Min(min, nums[i]);
                max = Math.Max(max, nums[i]);
            }

            // Find indexes where min/max value should be placed
            int sortFrom = l;
            for (int i = 0; i < l; i++)
            {
                if (nums[i] > min)
                {
                    sortFrom = i;
                    break;
                }
            }

            int sortTo = r;
            for (int i = N - 1; i >= r; i--)
            {
                if (nums[i] < max)
                {
                    sortTo = i;
                    break;
                }
            }

            return sortTo - sortFrom + 1;
        }
    }

}