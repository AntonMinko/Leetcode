using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions.DynamicProgramming
{
    /*
    Write a function AllConstruct(target, wordBank) that takes in a target string and 
    an array of strings.
    The function should return a 2D array containing all of the ways the target can be
    constructed by concatenating elements of the wordBank array.
    Each element of the 2D array should represent one combination that constructs target.
    You may use an element of the array as many times as needed.


    m - length of the target
    n - wordBank.Length
    O(m^n) time
    O(m*n) space
    
    */
    public class AllConstructTabulation
    {
        public List<List<string>> AllConstruct(string target, string[] wordBank)
        {
            int M = target.Length;
            var table = new List<List<string>>[M + 1];
            table[0] = new List<List<string>>();
            table[0].Add(new List<string>());

            for (int i = 0; i < M; i++)
            {
                if (table[i] == null) continue;

                foreach (var word in wordBank)
                {
                    if (i + word.Length > M) continue;
                    if (target.IndexOf(word, i) != i) continue;

                    if (table[i + word.Length] == null)
                    {
                        table[i + word.Length] = new List<List<string>>();
                    }

                    foreach (var list in table[i])
                    {
                        table[i + word.Length].Add(CopyAndAppend(list, word));
                    }
                }
            }

            return table[M];
        }

        private List<string> CopyAndAppend(List<string> list, string value)
        {
            var copy = new List<string>(list);
            copy.Add(value);

            return copy;
        }
    }
}