using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    273. Integer to English Words

    Link: https://leetcode.com/problems/integer-to-english-words/
    
    Difficulty: Hard

Convert a non-negative integer num to its English words representation.

Example 1:
Input: num = 123
Output: "One Hundred Twenty Three"

Example 2:
Input: num = 12345
Output: "Twelve Thousand Three Hundred Forty Five"

Example 3:
Input: num = 1234567
Output: "One Million Two Hundred Thirty Four Thousand Five Hundred Sixty Seven"

Example 4:
Input: num = 1234567891
Output: "One Billion Two Hundred Thirty Four Million Five Hundred Sixty Seven Thousand Eight Hundred Ninety One"

Constraints:
    0 <= num <= 231 - 1

    */
    public class IntegerToEnglishWords
    {
        private readonly Dictionary<int, string> _wordMap = new Dictionary<int, string>
        {
            {0, "Zero"},
            {1, "One"},
            {2, "Two"},
            {3, "Three"},
            {4, "Four"},
            {5, "Five"},
            {6, "Six"},
            {7, "Seven"},
            {8, "Eight"},
            {9, "Nine"},
            {10, "Ten"},
            {11, "Eleven"},
            {12, "Twelve"},
            {13, "Thirteen"},
            {14, "Fourteen"},
            {15, "Fifteen"},
            {16, "Sixteen"},
            {17, "Seventeen"},
            {18, "Eighteen"},
            {19, "Nineteen"},
            {20, "Twenty"},
            {30, "Thirty"},
            {40, "Forty"},
            {50, "Fifty"},
            {60, "Sixty"},
            {70, "Seventy"},
            {80, "Eighty"},
            {90, "Ninety"},
            {100, "Hundred"},
            {1000, "Thousand"},
            {1_000_000, "Million"},
            {1_000_000_000, "Billion"},
        };

        public string NumberToWords(int num)
        {
            if (num == 0) return "Zero";

            var sb = new StringBuilder();

            void ProcessGroup(int digitGroup, int groupPosition = 0)
            {
                if (digitGroup == 0) return;

                int hundreds = digitGroup / 100;
                ProcessDigit(hundreds, 100);
                digitGroup %= 100;

                if (digitGroup < 20)
                {
                    ProcessDigit(digitGroup);
                }
                else
                {
                    int tens = (digitGroup / 10) * 10;
                    ProcessDigit(tens);

                    digitGroup %= 10;
                    ProcessDigit(digitGroup);
                }

                if (groupPosition > 0)
                {
                    sb.Append(" ");
                    sb.Append(_wordMap[groupPosition]);
                }
            }

            void ProcessDigit(int digit, int position = 0)
            {
                if (digit == 0) return;

                if (sb.Length != 0)
                {
                    sb.Append(" ");
                }
                sb.Append(_wordMap[digit]);

                if (position > 0)
                {
                    sb.Append(" ");
                    sb.Append(_wordMap[position]);
                }
            }

            int billions = num / 1_000_000_000;
            ProcessGroup(billions, 1_000_000_000);
            num %= 1_000_000_000;

            int millions = num / 1_000_000;
            if (millions > 0)
            {
                ProcessGroup(millions, 1_000_000);
            }
            num %= 1_000_000;

            int thousands = num / 1_000;
            if (thousands > 0)
            {
                ProcessGroup(thousands, 1_000);
            }
            num %= 1_000;

            if (num > 0)
            {
                ProcessGroup(num);
            }

            return sb.ToString();
        }
    }

}