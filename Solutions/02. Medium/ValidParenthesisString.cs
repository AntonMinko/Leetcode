using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    678. Valid Parenthesis String

    Link: https://leetcode.com/problems/valid-parenthesis-string/
    
    Difficulty: Medium

     Given a string containing only three types of characters: '(', ')' and '*', write a function to check whether this string is valid. We define the validity of a string by these rules:

    Any left parenthesis '(' must have a corresponding right parenthesis ')'.
    Any right parenthesis ')' must have a corresponding left parenthesis '('.
    Left parenthesis '(' must go before the corresponding right parenthesis ')'.
    '*' could be treated as a single right parenthesis ')' or a single left parenthesis '(' or an empty string.
    An empty string is also valid.

Example 1:

Input: "()"
Output: True

Example 2:

Input: "(*)"
Output: True

Example 3:

Input: "(*))"
Output: True

Note:
    The string size will be in the range [1, 100].

    */
    public class ValidParenthesisString
    {
        public bool CheckValidString2(string s) {
            int minOpen = 0, maxOpen = 0;
            foreach(char c in s)
            {
                if (c == '(')
                {
                    minOpen++;
                    maxOpen++;
                }
                if (c == ')')
                {
                    minOpen = Math.Max(--minOpen, 0);
                    maxOpen--;
                    if (maxOpen < 0)
                    {
                        return false;
                    }
                }
                if (c == '*')
                {
                    minOpen = Math.Max(--minOpen, 0);
                    maxOpen++;
                }
            }
            return minOpen == 0;
        }

        public bool CheckValidString(string s) {
            return IsValid(s, 0, 0);
        }
        
        private bool IsValid(string s, int i, int openParenthesisCount)
        {
            if (s.Length == i)
            {
                return openParenthesisCount == 0;
            }
            
            char current = s[i];
            switch (current)
            {
            case '(':
                return IsValidOpenParenthesis(s, i, openParenthesisCount);
            case ')':
                return IsValidClosingParenthesis(s, i, openParenthesisCount);
            default:
                return IsValidAsterisk(s, i, openParenthesisCount);
            }    
        }

        private bool IsValidOpenParenthesis(string s, int i, int openParenthesisCount)
        {
            return IsValid(s, i+1, ++openParenthesisCount);
        }

        private bool IsValidClosingParenthesis(string s, int i, int openParenthesisCount)
        {
            if (openParenthesisCount == 0)
            {
                return false;
            }
            return IsValid(s, i+1, --openParenthesisCount);
        }

        private bool IsValidAsterisk(string s, int i, int openParenthesisCount)
        {
            // * == '', just proceed with the next char
            if (IsValid(s, i+1, openParenthesisCount))
            {
                return true;
            }
            //Console.WriteLine($"The * is empty string is not valid");
            
            // * == '('
            if (IsValidOpenParenthesis(s, i, openParenthesisCount))
            {
                return true;
            }
            //Console.WriteLine($"The * is ( is not valid");
            
            // * == ')'
            if (IsValidClosingParenthesis(s, i, openParenthesisCount))
            {
                return true;
            }
            //Console.WriteLine($"The * is ) is not valid");

            return false;
        }
    }

}