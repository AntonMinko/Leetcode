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
    O(m) space
    
    */
    public class CanConstructTabulation
    {
        public bool CanConstruct(string target, string[] wordBank)
        {
            var table = new bool[target.Length + 1];
            table[0] = true;
            for (int i = 0; i < target.Length; i++)
            {
                if (!table[i]) continue;

                foreach (string word in wordBank)
                {
                    if (i + word.Length <= target.Length && target.IndexOf(word, i) == i)
                    {
                        table[i + word.Length] = true;
                    }
                }
            }

            return table[target.Length];
        }
    }
}