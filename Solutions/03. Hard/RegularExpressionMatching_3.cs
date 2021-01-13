using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    10. Regular Expression Matching

    Proper Solution using DP + tabulation with 2d table

    Link: https://leetcode.com/problems/regular-expression-matching/
    
    Difficulty: Hard

Given an input string (s) and a pattern (p), implement regular expression matching with support for '.' and '*'.

'.' Matches any single character.
'*' Matches zero or more of the preceding element.

The matching should cover the entire input string (not partial).

Note:

    s could be empty and contains only lowercase letters a-z.
    p could be empty and contains only lowercase letters a-z, and characters like . or *.

Example 1:

Input:
s = "aa"
p = "a"
Output: false
Explanation: "a" does not match the entire string "aa".

Example 2:

Input:
s = "aa"
p = "a*"
Output: true
Explanation: '*' means zero or more of the preceding element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".

Example 3:

Input:
s = "ab"
p = ".*"
Output: true
Explanation: ".*" means "zero or more (*) of any character (.)".

Example 4:

Input:
s = "aab"
p = "c*a*b"
Output: true
Explanation: c can be repeated 0 times, a can be repeated 1 time. Therefore, it matches "aab".

Example 5:

Input:
s = "mississippi"
p = "mis*is*p*."
Output: false
    
    O(nm) time complexity
    O(nm) space complexity
    
    */
    public class RegularExpressionMatching_3
    {
        public bool IsMatch(string s, string p)
        {
            var dp = new bool[s.Length + 1, p.Length + 1];
            dp[0, 0] = true;

            for (int i = 0; i < s.Length + 1; i++)
                for (int j = 0; j < p.Length + 1; j++)
                {
                    if (!dp[i, j]) continue;

                    bool isZeroOrMore = (j < p.Length - 1) && p[j + 1] == '*';
                    if (isZeroOrMore)
                    {
                        dp[i, j + 2] = true;
                    }

                    bool isCharMatch = i < s.Length && j < p.Length && (s[i] == p[j] || p[j] == '.');
                    if (isCharMatch)
                    {
                        if (isZeroOrMore)
                        {
                            dp[i + 1, j] = true;
                            dp[i + 1, j + 2] = true;
                        }
                        else
                        {
                            dp[i + 1, j + 1] = true;
                        }
                    }
                }

            return dp[s.Length, p.Length];
        }
    }

}