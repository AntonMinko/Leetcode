using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    5. Longest Palindromic Substring

    Link: https://leetcode.com/problems/longest-palindromic-substring/
    
    Difficulty: Medium

Given a string s, find the longest palindromic substring in s. You may assume that 
the maximum length of s is 1000.

Example 1:
Input: "babad"
Output: "bab"
Note: "aba" is also a valid answer.

Example 2:
Input: "cbbd"
Output: "bb"
    */
    public class LongestPalindromicSubstring
    {
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            int maxLength = 0;
            int start=0;
            int l = 0;
            int r = s.Length - 1;

            while (s.Length - l >= maxLength)
            {
                r = s.Length - 1;
                while (r-l >= maxLength)
                {
                    if (IsPalindrome(s, l, r))
                    {
                        maxLength = r-l+1;
                        start = l;
                        break;
                    }
                    r--;
                }
                l++;
            }
            return s.Substring(start, maxLength);
        }

        private bool IsPalindrome(string s, int l, int r)
        {
            while (l <= r)
            {
                if (s[l] != s[r]) return false;

                l++;
                r--;
            }
            return true;
        }
    }

}