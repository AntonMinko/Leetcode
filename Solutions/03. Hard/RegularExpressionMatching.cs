using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    10. Regular Expression Matching

    Solution 1 using DP + recursion

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
    public class RegularExpressionMatching
    {
        public bool IsMatch(string s, string p)
        {
            var pattern = new Pattern(p);
            return pattern.Match(s);
        }

        private class CharPattern
        {
            public char Char { get; }
            public bool IsAny { get; }
            public bool IsZeroOrMore { get; }
            public CharPattern(char c, bool isAny, bool isZeroOrMore)
            {
                Char = c;
                IsAny = isAny;
                IsZeroOrMore = isZeroOrMore;
            }
        }

        private class Pattern
        {
            private IList<CharPattern> _elements = new List<CharPattern>();

            public Pattern(string p)
            {
                int N = p.Length;
                int i = 0;
                while (true)
                {
                    if (i >= N) break;

                    bool isAny = p[i] == '.';
                    bool isZeroOrMore = i + 1 < N && p[i + 1] == '*' ? true : false;
                    _elements.Add(new CharPattern(p[i], isAny, isZeroOrMore));
                    i += isZeroOrMore ? 2 : 1;
                }
            }

            public bool Match(string s)
            {
                return Match(s, 0, 0);
            }

            private bool Match(string s, int s_i, int p_i)
            {
                if (s_i == s.Length && p_i == _elements.Count ||
                    s_i == s.Length && p_i == _elements.Count - 1 && _elements[p_i].IsZeroOrMore) return true;
                if (s_i > s.Length || p_i == _elements.Count) return false;

                while (true)
                {
                    //Console.WriteLine($"s_i={s_i}, p_i={p_i}");

                    var charPattern = _elements[p_i];
                    if (s_i == s.Length)
                    {
                        if (!charPattern.IsZeroOrMore)
                        {
                            return false;
                        }
                        if (p_i == _elements.Count - 1)
                        {
                            return true;
                        }
                    }
                    else if (charPattern.IsAny || charPattern.Char == s[s_i])
                    {
                        bool isMatch = Match(s, s_i + 1, charPattern.IsZeroOrMore ? p_i : p_i + 1);
                        if (isMatch)
                        {
                            return true;
                        }
                    }

                    if (charPattern.IsZeroOrMore)
                    {
                        ++p_i;
                    }

                    if (!charPattern.IsZeroOrMore || p_i == _elements.Count)
                    {
                        break;
                    }
                }

                return false;
            }
        }

    }
}