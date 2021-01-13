using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    10. Regular Expression Matching

    Solution 2 using DP + tabulation

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
    
    */
    public class RegularExpressionMatching_2
    {
        public bool IsMatch(string s, string p)
        {
            HashSet<int>[] positions = new HashSet<int>[s.Length + 1];
            positions[0] = new HashSet<int> { 0 };

            for (int i = 0; i <= s.Length; i++)
            {
                if (positions[i] == null) continue;

                foreach (int j in positions[i].ToArray())
                {
                    int pos = j;

                    // if (j == p.Length)
                    // {
                    //     positions[i].Remove(j);
                    //     continue;
                    // }

                    bool isStar;
                    do
                    {
                        isStar = (p.Length != pos + 1) && p[pos + 1] == '*';
                        if (isStar && pos + 2 <= p.Length)
                        {
                            pos += 2;
                            positions[i].Add(pos);
                        }

                    }
                    while (isStar && pos + 2 <= p.Length);
                }

                if (i == s.Length) continue;

                foreach (int j in positions[i])
                {
                    if (j >= p.Length) continue;

                    if (p[j] == '.' || s[i] == p[j])
                    {
                        if (positions[i + 1] == null)
                        {
                            positions[i + 1] = new HashSet<int>();
                        }

                        bool isStar = (p.Length != j + 1) && p[j + 1] == '*';
                        positions[i + 1].Add(isStar ? j : j + 1);
                    }
                }
            }

            return positions[p.Length] != null && positions[p.Length].Any(pos => pos == p.Length);

        }
    }

}