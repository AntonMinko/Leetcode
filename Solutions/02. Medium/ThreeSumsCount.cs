﻿using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    923. 3Sum With Multiplicity

    Link: https://leetcode.com/problems/3sum-with-multiplicity/
    
    Difficulty: Medium

Given an integer array arr, and an integer target, return the number of tuples i, j, k such 
that i < j < k and arr[i] + arr[j] + arr[k] == target.
As the answer can be very large, return it modulo 109 + 7.

Example 1:
Input: arr = [1,1,2,2,3,3,4,4,5,5], target = 8
Output: 20
Explanation: 
Enumerating by the values (arr[i], arr[j], arr[k]):
(1, 2, 5) occurs 8 times;
(1, 3, 4) occurs 8 times;
(2, 2, 4) occurs 2 times;
(2, 3, 3) occurs 2 times.

Example 2:
Input: arr = [1,1,2,2,2,2], target = 5
Output: 12
Explanation: 
arr[i] = 1, arr[j] = arr[k] = 2 occurs 12 times:
We choose one 1 from [1,1] in 2 ways,
and two 2s from [2,2,2,2] in 6 ways.

Constraints:
    3 <= arr.length <= 3000
    0 <= arr[i] <= 100
    0 <= target <= 300
    
    Complexity:
        O() time complexity
        O() space complexity
    */
    public class ThreeSumsCount
    {
        public int ThreeSumMulti(int[] arr, int target)
        {
            long count = 0;
            Dictionary<int, int> twoSumMap = new Dictionary<int, int>();

            for (int k = 2; k < arr.Length; k++)
            {
                int ak = arr[k];
                int aj = arr[k - 1];

                for (int i = 0; i <= k - 2; i++)
                {
                    int twoSum = arr[i] + aj;
                    if (twoSum <= target)
                    {
                        if (twoSumMap.ContainsKey(twoSum))
                        {
                            twoSumMap[twoSum] += 1;
                        }
                        else
                        {
                            twoSumMap[twoSum] = 1;
                        }
                    }
                }

                foreach (var kvp in twoSumMap)
                {
                    if (kvp.Key + ak == target)
                    {
                        count += kvp.Value;
                    }
                }
            }

            return (int)(count % 1_000_000_007);
        }
    }

}