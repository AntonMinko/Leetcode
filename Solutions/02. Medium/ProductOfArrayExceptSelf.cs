using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    238. Product of Array Except Self

    Link: https://leetcode.com/problems/product-of-array-except-self/
    
    Difficulty: Medium

    Given an array nums of n integers where n > 1,  return an array output such that output[i] is equal to the product of all the elements of nums except nums[i].

Example:
Input:  [1,2,3,4]
Output: [24,12,8,6]

Constraint: It's guaranteed that the product of the elements of any prefix or suffix of the array (including the whole array) fits in a 32 bit integer.

Note: Please solve it without division and in O(n).

Follow up:
Could you solve it with constant space complexity? (The output array does not count as extra space for the purpose of space complexity analysis.)

    */
    public class ProductOfArrayExceptSelf
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            int n = nums.Length;
            int[] result = new int[nums.Length];

            int leftProduct = 1, cur = 1;
            for(int i=0; i<n; i++)
            {
                leftProduct *= cur;
                cur = nums[i];
                result[i] = leftProduct;
            }

            int rightProduct = 1;
            cur = 1;
            for(int i=n-1; i>=0; i--)
            {
                rightProduct *= cur;
                cur = nums[i];
                result[i] *= rightProduct;
            }

            return result;
        }
    }

}