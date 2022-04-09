using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    31. Next Permutation

    Link: https://leetcode.com/problems/next-permutation/
    
    Difficulty: Medium

A permutation of an array of integers is an arrangement of its members into a sequence or linear order.
    For example, for arr = [1,2,3], the following are considered permutations of arr: [1,2,3], [1,3,2], [3,1,2], [2,3,1].
The next permutation of an array of integers is the next lexicographically greater permutation of its integer. More formally, 
if all the permutations of the array are sorted in one container according to their lexicographical order, then 
the next permutation of that array is the permutation that follows it in the sorted container. If such arrangement 
is not possible, the array must be rearranged as the lowest possible order (i.e., sorted in ascending order).
    For example, the next permutation of arr = [1,2,3] is [1,3,2].
    Similarly, the next permutation of arr = [2,3,1] is [3,1,2].
    While the next permutation of arr = [3,2,1] is [1,2,3] because [3,2,1] does not have a lexicographical larger rearrangement.
Given an array of integers nums, find the next permutation of nums.
The replacement must be in place and use only constant extra memory.

Example 1:
Input: nums = [1,2,3]
Output: [1,3,2]

Example 2:
Input: nums = [3,2,1]
Output: [1,2,3]

Example 3:
Input: nums = [1,1,5]
Output: [1,5,1]

Constraints:
    1 <= nums.length <= 100
    0 <= nums[i] <= 100
    
    Complexity:
        O(n) time complexity
        O(1) space complexity
    */
    public class NextPermitationSolution
    {
        public void NextPermutation(int[] nums)
        {
            int n = nums.Length;

            void Swap(int i1, int i2)
            {
                int tmp = nums[i1];
                nums[i1] = nums[i2];
                nums[i2] = tmp;
            }

            void Rearrange(int i1, int i2)
            {
                for (int j = i1; j < i1 + (i2 - i1) / 2 + 1; j++)
                {
                    Swap(j, i2 - (j - i1));
                }
            }

            // Find the first pair from the right where nums[i-1] < nums[i]
            int i = n - 1;
            while (i > 0 && nums[i - 1] >= nums[i]) i--;
            if (i == 0)
            {
                // we're on the last permutation (e.g. 321), invert the array to get the first one
                Rearrange(0, n - 1);
            }
            else
            {
                // find the closest larger number
                int swapWith = i;
                for (int j = n - 1; j >= i; j--)
                {
                    if (nums[i - 1] < nums[j])
                    {
                        swapWith = j;
                        break;
                    }
                }
                // invert the "unordered pair"
                Swap(i - 1, swapWith);

                // the right part is ordered descending, invert it (e.g. from 14_321 to 14_123)
                Rearrange(i, n - 1);
            }
        }
    }
}