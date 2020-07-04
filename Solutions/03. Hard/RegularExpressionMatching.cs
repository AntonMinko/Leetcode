using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    10. Regular Expression Matching

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
        private class Pattern
        {
            private List<Token> _pattern = new List<Token>();
            private int i = 0;
            Token cur;
            public Pattern(string p)
            {
                _pattern = PreparePattern(p);
                cur = _pattern[0];
            }

            private List<Token> PreparePattern(string p)
            {
                var pattern = new List<Token>();
                int N = p.Length;
                int i = 0;
                while (i < N)
                {
                    char c = p[i];
                    if (i + 1 < N && p[i + 1] == '*')
                    {
                        pattern.Add(new Token(c, true));
                        i += 2;
                    }
                    else
                    {
                        pattern.Add(new Token(c, false));
                        i++;
                    }
                }
                return pattern;
            }

            private Token MoveNext()
            {
                if (i < _pattern.Count - 1)
                {
                    i++;
                    cur = _pattern[i];
                }
                else
                {
                    cur = null;
                }

                return cur;
            }

            public bool IsCharMatch(char c)
            {
                if (cur == null) return false;

                if (cur.IsMatch(c))
                {
                    if (!cur.IsMultiple)
                    {
                        MoveNext();
                    }
                    return true;
                }
                else if (cur.IsMultiple)
                {
                    if (MoveNext() == null) return false;

                    if (cur.IsMatch(c))
                    {
                        if (!cur.IsMultiple)
                        {
                            MoveNext();
                        }
                        return true;
                    }
                }
                return false;
            }

            public bool IsEnd => cur == null || (cur.IsMultiple && i == _pattern.Count-1);

            private class Token
            {
                public Token(char c, bool isMultiple = false)
                {
                    Char = c;
                    IsMultiple = isMultiple;
                    if (c == '.')
                    {
                        IsAnySingle = true;
                    }
                }
                public char Char { get; }

                public bool IsAnySingle { get; }

                public bool IsMultiple { get; }

                public bool IsMatch(char c)
                {
                    return IsAnySingle || Char == c;
                }
            }
        }



        public bool IsMatch(string s, string p)
        {
            if (String.IsNullOrEmpty(p)) return false;

            var pattern = new Pattern(p);
            foreach (char c in s)
            {
                if (!pattern.IsCharMatch(c))
                {
                    return false;
                }
            }
            return pattern.IsEnd;
        }
    }

}