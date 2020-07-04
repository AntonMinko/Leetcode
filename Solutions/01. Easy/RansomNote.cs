using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    383. Ransom Note

    Link: https://leetcode.com/problems/ransom-note/
    
    Difficulty: Easy

Given an arbitrary ransom note string and another string containing letters from 
all the magazines, write a function that will return true if the ransom note can be 
constructed from the magazines; otherwise, it will return false.
Each letter in the magazine string can only be used once in your ransom note.

Note:
You may assume that both strings contain only lowercase letters.

canConstruct("a", "b") -> false
canConstruct("aa", "ab") -> false
canConstruct("aa", "aab") -> true

    */
    public class RansomNote
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            if (ransomNote.Length == 0) return true;

            var ransomChars = new Dictionary<char,int>();
            foreach(char c in ransomNote)
            {
                if (ransomChars.ContainsKey(c))
                {
                    ransomChars[c]++;
                }
                else
                {
                    ransomChars.Add(c, 1);
                }
            }

            foreach (char c in magazine)
            {
                if (ransomChars.ContainsKey(c))
                {
                    if (ransomChars[c] == 1)
                    {
                        ransomChars.Remove(c);
                    }
                    else
                    {
                        ransomChars[c]--;
                    }
                }
                if (ransomChars.Count == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }

}