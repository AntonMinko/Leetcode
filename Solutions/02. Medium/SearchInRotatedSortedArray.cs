using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    33. Search in Rotated Sorted Array

    Link: https://leetcode.com/problems/search-in-rotated-sorted-array/

    Difficulty: Medium

Suppose an array sorted in ascending order is rotated at some pivot unknown to you beforehand.
(i.e., [0,1,2,4,5,6,7] might become [4,5,6,7,0,1,2]).

You are given a target value to search. If found in the array return its index, otherwise return -1.
You may assume no duplicate exists in the array.
Your algorithm's runtime complexity must be in the order of O(log n).

Example 1:
Input: nums = [4,5,6,7,0,1,2], target = 0
Output: 4

Example 2:
Input: nums = [4,5,6,7,0,1,2], target = 3
Output: -1
    
    */
    public class SearchInRotatedSortedArray
    {
        public int Search(int[] nums, int target)
        {
            int length = nums.Length;
            if (nums.Length == 0) return -1;
            if (nums.Length == 1) return nums[0] == target ? 0 : -1;
            
            int shift = FindShift(nums);
            int lo = 0, hi = length-1;
            while(lo <= hi)
            {
                int mid = (hi + lo) / 2;
                int shiftedMid = GetShiftedIndex(mid, shift, length);
                if (nums[shiftedMid] == target)
                {
                    return shiftedMid;
                }
                if (nums[shiftedMid] > target)
                {
                    hi = mid-1;
                }
                else
                {
                    lo = mid+1;
                }
            }
            return -1;
        }

        private int GetShiftedIndex(int ind, int shift, int length)
        {
            int shiftedInd = ind - shift;
            if (shiftedInd < 0)
            {
                return shiftedInd + length;
            }
            if (shiftedInd >= length)
            {
                return shiftedInd - length;
            }
            return shiftedInd;
        }

        private int FindShift(int[] nums)
        {
            int length = nums.Length;
            if (nums[0] < nums[length-1]) return 0;
            if (length == 2) return 1;

            int lo = 0, hi = length-1;
            while(lo <= hi)
            {
                int mid = (hi + lo) / 2;
                if (nums[mid] > nums[mid+1])
                {
                    return length - mid - 1;
                }
                if (nums[mid] < nums[0])
                {
                    hi = mid-1;
                }
                else
                {
                    lo = mid+1;
                }
            }
            return -1;
        }
    }

}