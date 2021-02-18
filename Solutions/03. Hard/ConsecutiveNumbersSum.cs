using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    829. Consecutive Numbers Sum

    Link: https://leetcode.com/problems/consecutive-numbers-sum/
    
    Difficulty: Hard

Given a positive integer N, how many ways can we write it as a sum of consecutive positive integers?

Example 1:
Input: 5
Output: 2
Explanation: 5 = 5 = 2 + 3

Example 2:
Input: 9
Output: 3
Explanation: 9 = 9 = 4 + 5 = 2 + 3 + 4

Example 3:
Input: 15
Output: 4
Explanation: 15 = 15 = 8 + 7 = 4 + 5 + 6 = 1 + 2 + 3 + 4 + 5

Note: 1 <= N <= 10 ^ 9.

    Complexity:
        Looks like O(sqrt(N)) time complexity, but why?
        O(1) space complexity
    */
    public class ConsecutiveNumbersSum
    {
        public int Sum(int N)
        {
            int remainders = 1;
            int n = 2;
            int sums = 1;
            int basis = N;

            while (basis > 0 && remainders < N)
            {
                basis = (N - remainders) / n;
                int rem = (N - remainders) % n;

                if (basis > 0 && rem == 0)
                {
                    sums++;
                }

                remainders += n;
                n++;
            }

            return sums;
        }
    }

}