using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    Search in Sorted Array

Suppose an you have an array sorted in ascending order (i.e., [0,1,2,4,5,6,7]).

You are given a target value to search. If found in the array return its index, otherwise return -1.
You may assume no duplicate exists in the array.
Your algorithm's runtime complexity must be in the order of O(log n).
    
    */
    public class SearchInSortedArray
    {
        public int Search(int[] nums, int target)
        {
            if (nums.Length == 0) return -1;
            
            int lo = 0, hi = nums.Length-1;
            while(lo <= hi)
            {
                int mid = (hi + lo) / 2;
                if (nums[mid] == target)
                {
                    return mid;
                }
                if (nums[mid] > target)
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