using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions.DynamicProgramming
{
    /*
    Write a function CanConstruct(target, wordBank) that takes in a target string and 
    an array of strings.
    The function should return an boolean indicating whether or not the target can be
    constructed by concatenating elements of the wordBank array.
    You may use an element of the array as many times as needed.


    m - length of the target
    n - wordBank.Length
    O(n*m^2) time
    O(m+n) space
    
    */
    public class CanConstructMemoization
    {
        public bool CanConstruct(string target, string[] wordBank)
        {
            return CanConstruct(target, 0, wordBank, new Dictionary<int, bool>());
        }

        private bool CanConstruct(string target, int start, string[] wordBank, IDictionary<int, bool> memo)
        {
            if (start == target.Length) return true;
            if (start > target.Length) return false;
            if (memo.ContainsKey(start)) return memo[start];

            foreach (string word in wordBank)
            {
                if (target.IndexOf(word, start) == start)
                {
                    if (CanConstruct(target, start + word.Length, wordBank, memo))
                    {
                        memo[start] = true;
                        return true;
                    }
                }
            }

            memo[start] = false;
            return false;
        }
    }
}