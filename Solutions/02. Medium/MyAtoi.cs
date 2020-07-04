using System;

namespace Solutions
{
    /*
    8. String to Integer (atoi)

    Link: https://leetcode.com/problems/string-to-integer-atoi/
    
    Difficulty: Medium

Implement atoi which converts a string to an integer.

The function first discards as many whitespace characters as necessary until the first non-whitespace character is found. Then, starting from this character, takes an optional initial plus or minus sign followed by as many numerical digits as possible, and interprets them as a numerical value.

The string can contain additional characters after those that form the integral number, which are ignored and have no effect on the behavior of this function.

If the first sequence of non-whitespace characters in str is not a valid integral number, or if no such sequence exists because either str is empty or it contains only whitespace characters, no conversion is performed.

If no valid conversion could be performed, a zero value is returned.

Note:
    Only the space character ' ' is considered as whitespace character.
    Assume we are dealing with an environment which could only store integers within the 32-bit signed integer range: [−231,  231 − 1]. If the numerical value is out of the range of representable values, INT_MAX (231 − 1) or INT_MIN (−231) is returned.

Example 1:

Input: "42"
Output: 42

Example 2:

Input: "   -42"
Output: -42
Explanation: The first non-whitespace character is '-', which is the minus sign.
             Then take as many numerical digits as possible, which gets 42.

Example 3:

Input: "4193 with words"
Output: 4193
Explanation: Conversion stops at digit '3' as the next character is not a numerical digit.

Example 4:

Input: "words and 987"
Output: 0
Explanation: The first non-whitespace character is 'w', which is not a numerical 
             digit or a +/- sign. Therefore no valid conversion could be performed.

Example 5:

Input: "-91283472332"
Output: -2147483648
Explanation: The number "-91283472332" is out of the range of a 32-bit signed integer.
             Thefore INT_MIN (−231) is returned.
    
    */
    public class Atoi
    {
        private class NumberConstructor
        {
            private long longResult = 0;
            private bool canContinue = true;
            internal bool IsNegative { get; set; }

            internal bool AppendToNumber(char c)
            {
                if (!canContinue) return false;

                int digit = (int)c - (int)'0';
                longResult = 10 * longResult + digit;

                if (longResult > Int32.MaxValue)
                {
                    canContinue = false;
                }
                return canContinue;
            }

            internal int ToInt()
            {
                if (IsNegative)
                {
                    longResult = -longResult;
                }
                if (longResult > Int32.MaxValue) return Int32.MaxValue;
                if (longResult < Int32.MinValue) return Int32.MinValue;
                return (int)longResult;
            }
        }
        public int MyAtoi(string str)
        {
            var numberConstructor = new NumberConstructor();
            bool isFirstChar = true;
            str = str.TrimStart(new char[] {' '});

            foreach (char c in str)
            {
                if (isFirstChar && IsMinusSign(c))
                {
                    isFirstChar = false;
                    numberConstructor.IsNegative = true;
                }
                else if (isFirstChar && IsPlusSign(c))
                {
                    isFirstChar = false;
                    continue;
                }
                else if (char.IsDigit(c))
                {
                    isFirstChar = false;
                    bool isSuccessful = numberConstructor.AppendToNumber(c);
                    if (!isSuccessful)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            return numberConstructor.ToInt();
        }

        private bool IsPlusSign(char c)
        {
            return c == '+';
        }

        private bool IsMinusSign(char c)
        {
            return c == '-';
        }
    }
}