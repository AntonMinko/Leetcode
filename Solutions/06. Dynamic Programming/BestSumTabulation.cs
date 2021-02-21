using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions.DynamicProgramming
{
    /*
    Write a function BestSum(targetSum, numbers) that takes in a targetSum and an array of numbers as arguments.
    The function should return an array containing the shortest combination of elements that add up to exactly the targetSum.
    If there is a tie for the shortest combination, you may return any one of the shortest.
    You may use an element of the array as many times as needed.
    You may assume that all input numbers are non-negative.

    m - targetSum
    n - numbers.Length
    O(m*n) time
    O(m) space
    
    */
    public class BestSumTabulation
    {
        record Element(int Number, int Length, int Prev);

        public int[] BestSum(int targetSum, int[] numbers)
        {
            var table = new Element[targetSum + 1];
            table[0] = new Element(-1, 0, -1);

            for (int i = 0; i < targetSum; i++)
            {
                if (table[i] == null) continue;

                foreach (int num in numbers)
                {
                    if (i + num > targetSum) continue;

                    if (table[i + num] == null || table[i + num].Length > table[i].Length + 1)
                    {
                        table[i + num] = new Element(num, table[i].Length + 1, i);
                    }
                }
            }

            if (table[targetSum] == null) return null;

            var result = new LinkedList<int>();
            var el = table[targetSum];
            while (el.Prev != -1)
            {
                result.AddFirst(el.Number);
                el = table[el.Prev];
            }

            return result.ToArray();
        }
    }
}