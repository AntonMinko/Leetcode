using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    823. Binary Trees With Factors

    Link: https://leetcode.com/problems/binary-trees-with-factors/
    
    Difficulty: Medium

Given an array of unique integers, arr, where each integer arr[i] is strictly greater than 1.

We make a binary tree using these integers, and each number may be used for any number of times. 
Each non-leaf node's value should be equal to the product of the values of its children.

Return the number of binary trees we can make. The answer may be too large so return 
the answer modulo 10^9 + 7.

Example 1:
Input: arr = [2,4]
Output: 3
Explanation: We can make these trees: [2], [4], [4, 2, 2]

Example 2:
Input: arr = [2,4,5,10]
Output: 7
Explanation: We can make these trees: [2], [4], [5], [10], [4, 2, 2], [10, 2, 5], [10, 5, 2].

Constraints:
    1 <= arr.length <= 1000
    2 <= arr[i] <= 10^9
    
    Complexity:
        O() time complexity
        O() space complexity
    */
    public class NumberOfBinaryTrees
    {
        public int NumFactoredBinaryTrees(int[] arr)
        {
            Dictionary<int, long> memo = new Dictionary<int, long>();
            var numbers = new HashSet<int>(arr);

            long NumOfTrees(int root)
            {
                if (memo.ContainsKey(root)) return memo[root];

                long count = 1; //just current item
                foreach (int n in numbers)
                {
                    if (root > n && root % n == 0)
                    {
                        int otherN = root / n;
                        if (numbers.Contains(otherN))
                        {
                            count += NumOfTrees(n) * NumOfTrees(otherN);
                        }
                    }
                }
                memo[root] = count;
                return count;
            }

            long total = 0;
            foreach (int n in numbers)
            {
                total += NumOfTrees(n);
            }

            return (int)(total % 1000000007);
        }
    }

}