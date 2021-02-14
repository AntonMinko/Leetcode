using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    154. Find Minimum in Rotated Sorted Array II

    Link: https://leetcode.com/problems/find-minimum-in-rotated-sorted-array-ii/
    
    Difficulty: Hard

Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
(i.e.,  [0,1,2,4,5,6,7] might become  [4,5,6,7,0,1,2]).

Find the minimum element.

The array may contain duplicates.

Example 1:
Input: [1,3,5]
Output: 1

Example 2:
Input: [2,2,2,0,1]
Output: 0

Note:
    This is a follow up problem to Find Minimum in Rotated Sorted Array.
    Would allow duplicates affect the run-time complexity? How and why?

Constraints:
    n == nums.length
    1 <= n <= 5000
    -5000 <= nums[i] <= 5000
    All the integers of nums are unique.
    nums is sorted and rotated between 1 and n times.
    
Complexity:
O(n) time complexity
O(1) space complexity

    */
    public class MinimumInSortedRotatedArrayII
    {
        public int FindMin(int[] nums)
        {
            int l = 0;
            int r = nums.Length - 1;
            int cur = 0;
            while (l < r)
            {
                cur = (l + r) / 2;
                if (nums[r] < nums[cur])
                {
                    l = cur + 1;
                }
                else if (nums[r] > nums[cur])
                {
                    r = cur;
                }
                else
                {
                    // nums[l] == nums[r] => move r one item to the left
                    --r;
                }
            }

            return nums[l];
        }
    }

}