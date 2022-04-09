using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    347. Top K Frequent Elements

    Link: https://leetcode.com/problems/top-k-frequent-elements/
    
    Difficulty: Medium

 Given an integer array nums and an integer k, return the k most frequent elements. 
 You may return the answer in any order.

Example 1:
Input: nums = [1,1,1,2,2,3], k = 2
Output: [1,2]

Example 2:
Input: nums = [1], k = 1
Output: [1]

Constraints:
    1 <= nums.length <= 105
    k is in the range [1, the number of unique elements in the array].
    It is guaranteed that the answer is unique.

Follow up: Your algorithm's time complexity must be better than O(n log n), where n is the array's size.
   
    Complexity:
        O(nlogn) time complexity
        O(?) space complexity
    */
    public class TopKFrequentElements
    {
        public int[] TopKFrequent(int[] nums, int k)
        {
            return nums
                .GroupBy(n => n)
                .Select(gr => (n: gr.Key, count: gr.Count()))
                .OrderByDescending(tuple => tuple.count)
                .Select(tuple => tuple.n)
                .Take(k)
                .ToArray();
        }
    }
}