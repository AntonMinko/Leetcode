using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    4. Median of Two Sorted Arrays

    Link: https://leetcode.com/problems/median-of-two-sorted-arrays/
    
    Difficulty: Hard

Given two sorted arrays nums1 and nums2 of size m and n respectively, return the median of the two sorted arrays.
Follow up: The overall run time complexity should be O(log (m+n)).

Example 1:
Input: nums1 = [1,3], nums2 = [2]
Output: 2.00000
Explanation: merged array = [1,2,3] and median is 2.

Example 2:
Input: nums1 = [1,2], nums2 = [3,4]
Output: 2.50000
Explanation: merged array = [1,2,3,4] and median is (2 + 3) / 2 = 2.5.

Example 3:
Input: nums1 = [0,0], nums2 = [0,0]
Output: 0.00000

Example 4:
Input: nums1 = [], nums2 = [1]
Output: 1.00000

Example 5:
Input: nums1 = [2], nums2 = []
Output: 2.00000
 
Constraints:
nums1.length == m
nums2.length == n
0 <= m <= 1000
0 <= n <= 1000
1 <= m + n <= 2000
-106 <= nums1[i], nums2[i] <= 106
    */

    public class MedianOfTwoSortedArrays
    {
        public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        
            return nums1.Length <= nums2.Length 
                ? FindMedian(nums1, nums2)
                : FindMedian(nums2, nums1);

    }
    
        private double FindMedian(int[] nums1, int[] nums2)
        {
            int N = nums1.Length;
            int M = nums2.Length;
            int l = 0;
            int r = N;

            while(true)
            {
                int c1 = (l+r) / 2;
                int c2 = (N + M + 1)/2 - c1;

                int l1 = c1 > 0 ? nums1[c1-1] : int.MinValue;
                int l2 = c2 > 0 ? nums2[c2-1] : int.MinValue;
                int r1 = c1 < N ? nums1[c1] : int.MaxValue;
                int r2 = c2 < M ? nums2[c2] : int.MaxValue;

                if (l1 <= r2 && l2 <= r1)
                {
                    return (N + M) % 2 == 0 
                        ? (Math.Max(l1, l2) + Math.Min(r1, r2)) / 2.0
                        : Math.Max(l1, l2);
                }
                else if (r1 < l2)
                {
                    l = c1 + 1;
                }
                else
                {
                    r = c1 - 1;
                }
            }
        }
    }

}