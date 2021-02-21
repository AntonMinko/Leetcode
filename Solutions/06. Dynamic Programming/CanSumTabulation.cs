using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions.DynamicProgramming
{
    /*
    Write a function canSum(targetSum, numbers) that takes in a targetSum and an array of numbers as arguments.
    The function should return a boolean indicating whether or not it is possible to generate the targetSum using numbers from the array.
    You may use an element of the array as many times as needed.
    You may assume that all input numbers are non-negative.

    m - targetSum
    n - numbers.Length
    O(m*n) time
    O(m) space
    
    */
    public class CanSumTabulation
    {
        public bool CanSum(int targetSum, int[] numbers)
        {
            bool[] table = new bool[targetSum + 1];
            table[0] = true;
            for (int i = 0; i < targetSum; i++)
            {
                if (!table[i]) continue;

                foreach (int number in numbers)
                {
                    if (i + number <= targetSum)
                    {
                        table[i + number] = true;
                    }
                }
            }

            return table[targetSum];
        }
    }

}