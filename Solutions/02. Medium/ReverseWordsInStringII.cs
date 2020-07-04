using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    186. Reverse Words in a String II

    Link: https://leetcode.com/problems/reverse-words-in-a-string-ii/
    
    Difficulty: Medium

    Given an input string , reverse the string word by word. 

Example:
Input:  ["t","h","e"," ","s","k","y"," ","i","s"," ","b","l","u","e"]
Output: ["b","l","u","e"," ","i","s"," ","s","k","y"," ","t","h","e"]

Note: 
    A word is defined as a sequence of non-space characters.
    The input string does not contain leading or trailing spaces.
    The words are always separated by a single space.

Follow up: Could you do it in-place without allocating extra space?

    */
    public class ReverseWordsInStringII
    {
        private void Reverse(char[] s, int l, int r)
        {
            while (l < r)
            {
                (s[l], s[r]) = (s[r], s[l]);
                l++;
                r--;
            }
        }

        public void ReverseWords(char[] s)
        {
            int l = 0;
            int r = s.Length - 1;
            Reverse(s, l, r);

            l = 0;
            while (l < s.Length)
            {
                r = l + 1;
                while (r < s.Length && s[r] != ' ')
                {
                    r++;
                }
                //Console.WriteLine($"1. l={l}, r={r}");
                Reverse(s, l, r - 1);
                l = r + 1;
            }
        }
    }
}