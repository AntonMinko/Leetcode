using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions
{
    /*
    Link: https://leetcode.com/problems/group-anagrams/
    
    Difficulty: Medium

    49. Group Anagrams
    Given an array of strings, group anagrams together.

    Example:

    Input: ["eat", "tea", "tan", "ate", "nat", "bat"],
    Output:
    [
    ["ate","eat","tea"],
    ["nat","tan"],
    ["bat"]
    ]

    Note:
        All inputs will be in lowercase.
        The order of your output does not matter.

    */
    public class GroupAnagramsProblem
    {
        private class AnagramList
        {
            private char[] _orderedChars;
            private int _length;
            public IList<string> Anagrams { get; private set; }

            public AnagramList(string initialAnagram, char[] orderedChars)
            {
                Anagrams = new List<string>();
                Anagrams.Add(initialAnagram);
                _length = initialAnagram.Length;
                _orderedChars = orderedChars;
            }
            public bool TryAdd(string str, char[] orderedChars)
            {
                if (str.Length != _length) return false;

                if (orderedChars.SequenceEqual(_orderedChars))
                {
                    Anagrams.Add(str);
                    return true;
                }
                return false;
            }
        }
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var anagrams = new Dictionary<string, IList<string>>();
            
            foreach (string str in strs)
            {
                string key = GetKey(str);
                if(!anagrams.ContainsKey(key))
                {
                    anagrams[key] = new List<string>();
                }
                anagrams[key].Add(str);
            }


            return anagrams.Values.ToList();
        }

        private string GetKey(string str)
        {
            int[] charCounter = new int[26];
            foreach(char c in str)
            {
                charCounter[c-'a'] += 1;
            }

            StringBuilder sb = new StringBuilder();
            foreach(int count in charCounter)
            {
                sb.Append(count);
            }

            return sb.ToString();
        }
    }

}