using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    647. Palindromic Substrings

    Link: https://leetcode.com/problems/palindromic-substrings/
    
    Difficulty: Medium
    
Given a string, your task is to count how many palindromic substrings in this string.
The substrings with different start indexes or end indexes are counted as 
different substrings even they consist of same characters.

Example 1:
Input: "abc"
Output: 3
Explanation: Three palindromic strings: "a", "b", "c".

Example 2:
Input: "aaa"
Output: 6
Explanation: Six palindromic strings: "a", "a", "a", "aa", "aa", "aaa".

Note:
    The input string length won't exceed 1000.

    Complexity:
        O(N^2) time complexity
        O(N^2) space complexity
    */
    public class PalindromicSubstrings
    {
        public int CountSubstrings(string s)
        {
            int N = s.Length;
            var dp = new bool[N, N];
            int count = 0;

            for (int offset = 0; offset < N; offset++)
            {
                for (int l = 0; l < N - offset; l++)
                {
                    int r = l + offset;
                    bool isPalindrome = false;

                    if (l == r)
                    {
                        isPalindrome = true;
                    }
                    else if (l == r - 1)
                    {
                        isPalindrome = s[l] == s[r];
                    }
                    else
                    {
                        isPalindrome = s[l] == s[r] && dp[l + 1, r - 1];
                    }

                    if (isPalindrome)
                    {
                        dp[l, r] = true;
                        count++;
                    }
                }
            }

            return count;
        }
    }
}