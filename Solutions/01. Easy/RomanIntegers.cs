using System;
using System.Collections.Generic;

namespace Solutions
{
    /*
    13. Roman to Integer

    Link: https://leetcode.com/problems/roman-to-integer/
    
    Difficulty: Easy

Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

Symbol       Value
I             1
V             5
X             10
L             50
C             100
D             500
M             1000

For example, two is written as II in Roman numeral, just two one's added together. Twelve is written as, XII, which is simply X + II. The number twenty seven is written as XXVII, which is XX + V + II.

Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. Instead, the number four is written as IV. Because the one is before the five we subtract it making four. The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:

    I can be placed before V (5) and X (10) to make 4 and 9. 
    X can be placed before L (50) and C (100) to make 40 and 90. 
    C can be placed before D (500) and M (1000) to make 400 and 900.

Given a roman numeral, convert it to an integer. Input is guaranteed to be within the range from 1 to 3999.

Example 1:

Input: "III"
Output: 3

Example 2:

Input: "IV"
Output: 4

Example 3:

Input: "IX"
Output: 9

Example 4:

Input: "LVIII"
Output: 58
Explanation: L = 50, V= 5, III = 3.

Example 5:

Input: "MCMXCIV"
Output: 1994
Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.

    */

    public class RomanIntegers
    {
        private const string R1 = "I", R5 = "V", R10 = "X",
        R50 = "L", R100 = "C", R500 = "D", R1000 = "M",
        R4 = "IV", R9 = "IX", R40 = "XL", 
        R90 = "XC", R400 = "CD", R900 = "CM";
    
    public int RomanToInt(string s) {
        int number = 0;
        
        foreach(string token in Tokenize(s))
        {
            number += ToNumber(token);
        }

        return number;
    }

    private IEnumerable<string> Tokenize(string s)
    {
        for(int i=0; i<s.Length; i++)
        {
            char cur=s[i];
            char next = i+1 == s.Length ? (char)0 : s[i+1];

            if (i+1 < s.Length)
            {
                string twoLetters = s.Substring(i, 2);
                if (twoLetters == R4 ||twoLetters == R9 ||
                    twoLetters == R40 || twoLetters == R90 ||
                    twoLetters == R400 || twoLetters == R900)
                {
                    yield return twoLetters;
                    ++i;
                    continue;
                }
            }

            yield return s[i].ToString();
        }
    }

    private int ToNumber(string romanToken)
    {
        switch(romanToken)
        {
            case R1:
                return 1;
            case R4:
                return 4;
            case R5:
                return 5;
            case R9:
                return 9;
            case R10: 
                return 10;
            case R40:
                return 40;
            case R50:
                return 50;
            case R90:
                return 90;
            case R100:
                return 100;
            case R400: 
                return 400;
            case R500: 
                return 500;
            case R900: 
                return 900;
            case R1000: 
                return 1000;
            default:
                throw new ArgumentException($"The '{romanToken} is not a valid Roman number.'");
        }
    }
    }
}