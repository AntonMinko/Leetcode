using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    81. Search in Rotated Sorted Array II

    Link: https://leetcode.com/problems/search-in-rotated-sorted-array-ii/

    Difficulty: Medium

There is an integer array nums sorted in non-decreasing order (not necessarily with distinct values).

Before being passed to your function, nums is rotated at an unknown pivot index k (0 <= k < nums.length) 
such that the resulting array is [nums[k], nums[k+1], ..., nums[n-1], nums[0], nums[1], ..., nums[k-1]] (0-indexed). 
For example, [0,1,2,4,4,4,5,6,6,7] might be rotated at pivot index 5 and become [4,5,6,6,7,0,1,2,4,4].

Given the array nums after the rotation and an integer target, return true if target is in nums, or false if it is not in nums.

Example 1:
Input: nums = [2,5,6,0,0,1,2], target = 0
Output: true

Example 2:
Input: nums = [2,5,6,0,0,1,2], target = 3
Output: false

Constraints:
    1 <= nums.length <= 5000
    -104 <= nums[i] <= 104
    nums is guaranteed to be rotated at some pivot.
    -104 <= target <= 104
 
Follow up: This problem is the same as Search in Rotated Sorted Array, where nums may contain duplicates. 
Would this affect the runtime complexity? How and why?
    
    */
    public class SearchInRotatedSortedArrayII
    {
        public bool Search(int[] nums, int target)
        {
            int offset = FindOffset(nums);

            int Shift(int ind)
            {
                if (ind + offset >= nums.Length)
                {
                    return ind + offset - nums.Length;
                }
                else
                {
                    return ind + offset;
                }
            }

            int l = 0, r = nums.Length - 1;
            while (l < r)
            {
                int sl = Shift(l);
                int sr = Shift(r);

                while (l < r && nums[sl] == nums[sr])
                {
                    l++;
                    sl = Shift(l);
                }

                if (l == r)
                {
                    return nums[Shift(r)] == target;
                }

                int cur = (l + r) / 2;
                int sCur = Shift(cur);
                if (target > nums[sCur])
                {
                    l = cur + 1;
                }
                else
                {
                    r = cur;
                }
            }

            return nums[Shift(r)] == target;
        }


        private int FindOffset(int[] nums)
        {
            int l = 0;
            int r = nums.Length - 1;
            while (l == 0 || nums[l] >= nums[l - 1])
            {
                while (l < r && nums[l] == nums[r])
                {
                    l++;
                }

                if (l == r)
                {
                    return 0;
                }

                int cur = (l + r) / 2;
                if (cur > 0 && nums[cur - 1] > nums[cur])
                {
                    return cur;
                }
                if (nums[cur] >= nums[l])
                {
                    l = cur + 1;
                }
                else
                {
                    r = cur;
                }
            }

            return nums[l] < nums[l - 1] ? l : 0;
        }
    }

}