using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    151. Reverse Words in a String

    Link: https://leetcode.com/problems/reverse-words-in-a-string/
    
    Difficulty: Medium

    Given an input string, reverse the string word by word.

Example 1:

Input: "the sky is blue"
Output: "blue is sky the"

Example 2:

Input: "  hello world!  "
Output: "world! hello"
Explanation: Your reversed string should not contain leading or trailing spaces.

Example 3:

Input: "a good   example"
Output: "example good a"
Explanation: You need to reduce multiple spaces between two words to a single space in the reversed string.

Note:
    A word is defined as a sequence of non-space characters.
    Input string may contain leading or trailing spaces. However, your reversed string should not contain leading or trailing spaces.
    You need to reduce multiple spaces between two words to a single space in the reversed string.

    */
    public class ReverseWordsInString
    {
        public string ReverseWords(string s)
        {
            if (s.Length == 0) return s;

            Stack<string> words = new Stack<string>();
            int cur = s.IndexOf(' ');
            int last = 0;
            
            while(true)
            {
                if (cur - last > 0)
                {
                    words.Push(s.Substring(last, cur - last));
                }
                if (cur == -1)
                {
                    words.Push(s.Substring(last));
                    break;
                }
                last = cur + 1;
                cur = s.IndexOf(' ', cur + 1);
            }

            var sb = new StringBuilder();
            foreach (var word in words)
            {
                if (sb.Length > 0)
                {
                    sb.Append(' ');
                }
                sb.Append(word);
            }

            return sb.ToString();
        }


        public string ReverseWords2(string s)
        {
            IEnumerable<string> words = s.Split(' ').Reverse();

            return String.Join(" ", words);
        }
    }

}