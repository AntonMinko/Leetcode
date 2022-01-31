using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    78. Subsets

    Link: https://leetcode.com/problems/subsets/
    
    Difficulty: Medium

Given an integer array nums of unique elements, return all possible subsets (the power set).
The solution set must not contain duplicate subsets. Return the solution in any order.

Example 1:
Input: nums = [1,2,3]
Output: [[],[1],[2],[1,2],[3],[1,3],[2,3],[1,2,3]]

Example 2:
Input: nums = [0]
Output: [[],[0]]

Constraints:
    1 <= nums.length <= 10
    -10 <= nums[i] <= 10
    All the numbers of nums are unique.
    
    Complexity:
        O() time complexity
        O() space complexity
    */
    public class AllSubsets
    {
        public IList<IList<int>> Subsets_Bitmask(int[] nums)
        {
            var subsets = new List<IList<int>>();

            int n = nums.Length;
            var masks = new int[n];
            int mask = 1;
            for (int i = n - 1; i >= 0; i--)
            {
                masks[i] = mask;
                mask *= 2;
            }

            int max = mask; // 2^(n+1)
            for (int i = 0; i < max; i++)
            {
                var subset = new List<int>();
                for (int j = 0; j < n; j++)
                {
                    if ((i & masks[j]) != 0)
                    {
                        subset.Add(nums[j]);
                    }
                }
                subsets.Add(subset);
            }

            return subsets;
        }

        public IList<IList<int>> Subsets_Backtracking(int[] nums)
        {
            var result = new List<IList<int>>();

            void Backtrack(IList<int> curSubset, HashSet<int> options)
            {
                if (!options.Any()) return;

                var remainingOptions = new HashSet<int>(options);
                foreach (int option in options)
                {
                    var newSubset = new List<int>(curSubset);
                    newSubset.Add(option);
                    result.Add(newSubset);

                    remainingOptions.Remove(option);

                    Backtrack(newSubset, remainingOptions);
                }
            }

            var subset = new List<int>(0);
            result.Add(subset);
            var options = new HashSet<int>(nums);

            Backtrack(subset, options);
            return result;
        }
    }
}