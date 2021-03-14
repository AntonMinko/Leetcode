using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    12. Integer to Roman

    Link: https://leetcode.com/problems/integer-to-roman/
    
    Difficulty: Medium

Roman numerals are represented by seven different symbols: I, V, X, L, C, D and M.

Symbol       Value
I             1
V             5
X             10
L             50
C             100
D             500
M             1000

For example, 2 is written as II in Roman numeral, just two one's added together. 12 is written as XII, which is simply X + II. 
The number 27 is written as XXVII, which is XX + V + II.

Roman numerals are usually written largest to smallest from left to right. However, the numeral for four is not IIII. 
Instead, the number four is written as IV. Because the one is before the five we subtract it making four. 
The same principle applies to the number nine, which is written as IX. There are six instances where subtraction is used:
    I can be placed before V (5) and X (10) to make 4 and 9. 
    X can be placed before L (50) and C (100) to make 40 and 90. 
    C can be placed before D (500) and M (1000) to make 400 and 900.

Given an integer, convert it to a roman numeral.

Example 1:
Input: num = 3
Output: "III"

Example 2:
Input: num = 4
Output: "IV"

Example 3:
Input: num = 9
Output: "IX"

Example 4:
Input: num = 58
Output: "LVIII"
Explanation: L = 50, V = 5, III = 3.

Example 5:
Input: num = 1994
Output: "MCMXCIV"
Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.

Constraints:
    1 <= num <= 3999
    
    Complexity:
        O() time complexity
        O() space complexity
    */
    public class IntegerToRoman
    {
        public string IntToRoman(int num)
        {
            StringBuilder sb = new StringBuilder();
            void ProcessDigit(int digit, string one, string five, string ten)
            {
                switch (digit)
                {
                    case 1:
                        sb.Insert(0, one);
                        break;
                    case 2:
                        sb.Insert(0, $"{one}{one}");
                        break;
                    case 3:
                        sb.Insert(0, $"{one}{one}{one}");
                        break;
                    case 4:
                        sb.Insert(0, $"{one}{five}");
                        break;
                    case 5:
                        sb.Insert(0, $"{five}");
                        break;
                    case 6:
                        sb.Insert(0, $"{five}{one}");
                        break;
                    case 7:
                        sb.Insert(0, $"{five}{one}{one}");
                        break;
                    case 8:
                        sb.Insert(0, $"{five}{one}{one}{one}");
                        break;
                    case 9:
                        sb.Insert(0, $"{one}{ten}");
                        break;
                    case 0:
                    default:
                        break;
                }
            }

            int firstDigit = num % 10;
            ProcessDigit(firstDigit, "I", "V", "X");

            num = num / 10;
            int secondDigit = num % 10;
            ProcessDigit(secondDigit, "X", "L", "C");
            num = num / 10;
            int thirdDigit = num % 10;
            ProcessDigit(thirdDigit, "C", "D", "M");

            num = num / 10;
            int fourthDigit = num % 10;
            ProcessDigit(fourthDigit, "M", string.Empty, string.Empty);

            return sb.ToString();
        }
    }

}