using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    423. Reconstruct Original Digits from English

    Link: https://leetcode.com/problems/reconstruct-original-digits-from-english/
    
    Difficulty: Medium

Given a non-empty string containing an out-of-order English representation of digits 0-9, output the digits in ascending order.

Note:
    Input contains only lowercase English letters.
    Input is guaranteed to be valid and can be transformed to its original digits. That means invalid inputs such as "abc" or "zerone" are not permitted.
    Input length is less than 50,000.

Example 1:
Input: "owoztneoer"
Output: "012"

Example 2:
Input: "fviefuro"
Output: "45"

    Complexity:
        O(n) time complexity
        O(n) space complexity
    */
    public class ReconstructDigits
    {
        public string OriginalDigits(string s)
        {
            var used = new bool[s.Length];
            var expected = new Dictionary<char, int>();
            var sb = new StringBuilder();

            int CountChars(char charToCount)
            {
                int count = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (!used[i] && s[i] == charToCount)
                    {
                        count++;
                    }
                }
                return count;
            }

            void AddToExpected(int digit, int count)
            {
                if (count == 0) return;

                expected.Clear();

                switch (digit)
                {
                    case 0:
                        expected.Add('z', count);
                        expected.Add('e', count);
                        expected.Add('r', count);
                        expected.Add('o', count);
                        break;
                    case 1:
                        expected.Add('o', count);
                        expected.Add('n', count);
                        expected.Add('t', count);
                        break;
                    case 2:
                        expected.Add('t', count);
                        expected.Add('w', count);
                        expected.Add('o', count);
                        break;
                    case 3:
                        expected.Add('t', count);
                        expected.Add('h', count);
                        expected.Add('r', count);
                        expected.Add('e', count * 2);
                        break;
                    case 4:
                        expected.Add('f', count);
                        expected.Add('o', count);
                        expected.Add('u', count);
                        expected.Add('r', count);
                        break;
                    case 5:
                        expected.Add('f', count);
                        expected.Add('i', count);
                        expected.Add('v', count);
                        expected.Add('e', count);
                        break;
                    case 6:
                        expected.Add('s', count);
                        expected.Add('i', count);
                        expected.Add('x', count);
                        break;
                    case 7:
                        expected.Add('s', count);
                        expected.Add('e', count * 2);
                        expected.Add('v', count);
                        expected.Add('n', count);
                        break;
                    case 8:
                        expected.Add('e', count);
                        expected.Add('i', count);
                        expected.Add('g', count);
                        expected.Add('h', count);
                        expected.Add('t', count);
                        break;
                    case 9:
                    default:
                        expected.Add('n', count * 2);
                        expected.Add('i', count);
                        expected.Add('e', count);
                        break;
                }
            }

            void MarkAsUsed(int digit, int count)
            {
                AddToExpected(digit, count);

                for (int i = 0; i < s.Length; i++)
                {
                    char c = s[i];
                    if (!used[i] && expected.ContainsKey(c))
                    {
                        used[i] = true;

                        if (expected[c] == 1)
                        {
                            expected.Remove(c);
                        }
                        else
                        {
                            expected[c] -= 1;
                        }
                    }
                }
            }

            var result = new int[10];
            result[0] = CountChars('z');
            MarkAsUsed(0, result[0]);

            result[2] = CountChars('w');
            MarkAsUsed(2, result[2]);

            result[4] = CountChars('u');
            MarkAsUsed(4, result[4]);

            result[6] = CountChars('x');
            MarkAsUsed(6, result[6]);

            result[8] = CountChars('g');
            MarkAsUsed(8, result[8]);

            result[3] = CountChars('r');
            MarkAsUsed(3, result[3]);

            result[5] = CountChars('f');
            MarkAsUsed(5, result[5]);

            result[7] = CountChars('s');
            MarkAsUsed(7, result[7]);

            result[1] = CountChars('o');
            MarkAsUsed(1, result[1]);

            result[9] = CountChars('i');
            MarkAsUsed(9, result[9]);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < result[i]; j++)
                {
                    sb.Append(i);
                }
            }

            return sb.ToString();
        }
    }

}