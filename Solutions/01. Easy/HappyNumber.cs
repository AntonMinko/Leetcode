using System;
using System.Collections.Generic;

namespace Solutions
{
    /*
    https://leetcode.com/problems/happy-number/
    
    Easy

    Write an algorithm to determine if a number is "happy".

    A happy number is a number defined by the following process: 
    Starting with any positive integer, replace the number by the 
    sum of the squares of its digits, and repeat the process until 
    the number equals 1 (where it will stay), or it loops endlessly 
    in a cycle which does not include 1. Those numbers for which 
    this process ends in 1 are happy numbers.
    */
    public class HappyNumber
    {
        private const int MaxAttempts = 100;
        public bool IsHappy(int n) {
            HashSet<int> uniqueNumbers = new HashSet<int>();
            int iterationCount = 0;
            int sum = n;

            while(true)
            {
                sum = GetSquaredSum(sum);
                if (sum == 1)
                {
                    return true;
                }

                if (!uniqueNumbers.Add(sum))
                {   // Loop detected, it's not a lucky number
                    return false;
                }

                // if (iterationCount == MaxAttempts)
                // {
                //     return false;
                // }
                ++iterationCount;
            }
        }

        private int GetSquaredSum(int number)
        {
            int result = 0;
            while (number > 0)
            {
                int digit = number % 10;
                result += digit*digit;
                number = number / 10;
            }
            return result;
        }
    }
}