using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    869. Reordered Power of 2

    Link: https://leetcode.com/problems/reordered-power-of-2/
    
    Difficulty: Medium

Starting with a positive integer N, we reorder the digits in any order (including the original order) such that the leading digit is not zero.
Return true if and only if we can do this in a way such that the resulting number is a power of 2.

Example 1:
Input: 1
Output: true

Example 2:
Input: 10
Output: false

Example 3:
Input: 16
Output: true

Example 4:
Input: 24
Output: false

Example 5:
Input: 46
Output: true

Note:
    1 <= N <= 10^9

    Complexity:
        O() time complexity
        O() space complexity
    */
    public class PowerOf2
    {
        public bool ReorderedPowerOf2(int N)
        {
            long orderedN = ToOrderedLong(N);
            long powerOf2 = 1;
            long upperLimit = (long)(N) * 10;
            while (powerOf2 < upperLimit)
            {
                long orderedPowerOf2 = ToOrderedLong(powerOf2);
                if (orderedN == orderedPowerOf2)
                {
                    return true;
                }

                powerOf2 <<= 1;
            }

            return false;
        }

        private long ToOrderedLong(long n)
        {
            List<int> digits = new List<int>();
            while (n > 0)
            {
                digits.Add((int)(n % 10));
                n /= 10;
            }

            long result = 0;
            bool isFirst = true;
            foreach (int digit in digits.OrderByDescending(d => d))
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    result *= 10;
                }
                result += digit;
            }

            return result;
        }
    }

}