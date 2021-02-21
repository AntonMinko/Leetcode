using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions.DynamicProgramming
{
    /*
    Write a function HowSum(targetSum, numbers) that takes in a targetSum and an array of numbers as arguments.
    The function should return an array containing any combination of elements that add up to exactly the targetSum.
    If there are multiple combinations possible, you may return any single one.
    You may use an element of the array as many times as needed.
    You may assume that all input numbers are non-negative.

    m - targetSum
    n - numbers.Length
    O(m*n) time
    O(m) space
    
    */
    public class HowSumTabulation
    {
        record Element(int Number, int? PrevElement = null);

        public int[] HowSum(int targetSum, int[] numbers)
        {
            var table = new Element[targetSum + 1];
            table[0] = new Element(-1);

            for (int i = 0; i < targetSum; i++)
            {
                if (table[i] == null) continue;

                foreach (int num in numbers)
                {
                    if (i + num <= targetSum && table[i + num] == null)
                    {
                        table[i + num] = new Element(num, i);
                    }
                }
            }

            if (table[targetSum] == null) return null;

            var result = new LinkedList<int>();
            var el = table[targetSum];

            while (el.Number != -1)
            {
                result.AddFirst(el.Number);
                el = table[el.PrevElement ?? 0];
            }

            return result.ToArray();
        }
    }

}