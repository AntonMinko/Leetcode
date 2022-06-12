using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    1695. Maximum Erasure Value

    Link: https://leetcode.com/problems/maximum-erasure-value/
    
    Difficulty: Medium

You are given an array of positive integers nums and want to erase a subarray containing unique elements. 
The score you get by erasing the subarray is equal to the sum of its elements.

Return the maximum score you can get by erasing exactly one subarray.

An array b is called to be a subarray of a if it forms a contiguous subsequence of a, 
that is, if it is equal to a[l],a[l+1],...,a[r] for some (l,r).

Example 1:
Input: nums = [4,2,4,5,6]
Output: 17
Explanation: The optimal subarray here is [2,4,5,6].

Example 2:
Input: nums = [5,2,1,2,5,2,1,2,5]
Output: 8
Explanation: The optimal subarray here is [5,2,1] or [1,2,5].

Constraints:
    1 <= nums.length <= 105
    1 <= nums[i] <= 104
    
    Complexity:
        O(n) time complexity
        O(n) space complexity
    */
    public class MaxErasureValue
    {
        public int MaximumUniqueSubarray(int[] nums)
        {
            int n = nums.Length;
            var seenAt = new int[n];
            var prefixSum = new int[n];

            var prevMap = new Dictionary<int, int>();
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                seenAt[i] = prevMap.ContainsKey(nums[i]) ? prevMap[nums[i]] : -1;
                prevMap[nums[i]] = i;

                sum += nums[i];
                prefixSum[i] = sum;
            }

            int max = nums.Max();
            int curSum = nums[0];

            int l = 0;
            for (int r = 1; r < n; r++)
            {
                if (seenAt[r] < l)
                {
                    // increase subarray
                    curSum += nums[r];
                    max = Math.Max(max, curSum);
                }
                else
                {
                    // reduce the curSum by the subarray sum up to a first duplicate
                    if (l == 0)
                    {
                        curSum -= prefixSum[seenAt[r]];
                    }
                    else
                    {
                        curSum -= prefixSum[seenAt[r]] - prefixSum[l - 1];
                    }
                    curSum += nums[r];

                    // reduce subarray from left to make it unique again
                    l = seenAt[r] + 1;
                }
            }

            return max;
        }
    }
}