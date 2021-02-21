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
    O(n*m*m) time (extra m due to IndexOf)
    O(m) space
    
    */
    public class CountConstructTabulation
    {
        public int CountConstruct(string target, string[] wordBank)
        {
            var table = new int[target.Length + 1];
            table[0] = 1;

            for (int i = 0; i < target.Length; i++)
            {
                if (table[i] == 0) continue;

                foreach (var word in wordBank)
                {
                    if (i + word.Length > target.Length) continue;

                    if (target.IndexOf(word, i) == i)
                    {
                        table[i + word.Length] += table[i];
                    }
                }
            }

            return table[target.Length];
        }
    }
}