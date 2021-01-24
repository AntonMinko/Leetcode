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
    public class AllConstructMemoization
    {
        public List<List<string>> AllConstruct(string target, string[] wordBank)
        {
            return AllConstruct(target, 0, wordBank, new Dictionary<int, List<List<string>>>());
        }

        private List<List<string>> AllConstruct(string target, int index, string[] wordBank, Dictionary<int, List<List<string>>> memo)
        {
            if (target.Length == index) return new List<List<string>> { new List<string>() };
            if (target.Length < index) return new List<List<string>>();
            if (memo.ContainsKey(index)) return DeepCopy(memo[index]);

            List<List<string>> result = new List<List<string>>();
            foreach (string word in wordBank)
            {
                if (target.IndexOf(word, index) == index)
                {
                    var remainder = AllConstruct(target, index + word.Length, wordBank, memo);
                    foreach (var list in remainder)
                    {
                        list.Insert(0, word);
                    }
                    result.AddRange(remainder);
                }
            }

            memo[index] = DeepCopy(result);
            return result;
        }

        private List<List<T>> DeepCopy<T>(List<List<T>> source)
        {
            var copy = new List<List<T>>(source.Count);
            foreach (var list in source)
            {
                copy.Add(new List<T>(list));
            }
            return copy;
        }
    }
}