using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions.DynamicProgramming
{
    /*
    Write a function CountConstruct(target, wordBank) that takes in a target string and 
    an array of strings.
    The function should return the number of ways that the target can be
    constructed by concatenating elements of the wordBank array.
    You may use an element of the array as many times as needed.


    m - length of the target
    n - wordBank.Length
    O(n*m) time
    O(m) space
    
    */
    public class CountConstructMemoization
    {
        public int CountConstruct(string target, string[] wordBank)
        {
            return CountConstruct(target, 0, wordBank, new Dictionary<int, int>());
        }

        private int CountConstruct(string target, int index, string[] wordBank, Dictionary<int, int> memo)
        {
            if (index == target.Length) return 1;
            if (index > target.Length) return 0;
            if (memo.ContainsKey(index)) return memo[index];

            int sum = 0;
            foreach (string word in wordBank)
            {
                if (target.IndexOf(word, index) == index)
                {
                    sum += CountConstruct(target, index + word.Length, wordBank, memo);
                }
            }

            memo[index] = sum;
            return sum;
        }
    }
}