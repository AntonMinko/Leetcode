using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    68. Text Justification

    Link: https://leetcode.com/problems/text-justification/
    
    Difficulty: Hard

Given an array of words and a width maxWidth, format the text such that each line has exactly maxWidth characters and is fully (left and right) justified.
You should pack your words in a greedy approach; that is, pack as many words as you can in each line. Pad extra spaces ' ' when necessary so that each line has exactly maxWidth characters.
Extra spaces between words should be distributed as evenly as possible. If the number of spaces on a line do not divide evenly between words, the empty slots on the left will be assigned more spaces than the slots on the right.
For the last line of text, it should be left justified and no extra space is inserted between words.

Note:
    A word is defined as a character sequence consisting of non-space characters only.
    Each word's length is guaranteed to be greater than 0 and not exceed maxWidth.
    The input array words contains at least one word.

Example 1:
Input: words = ["This", "is", "an", "example", "of", "text", "justification."], maxWidth = 16
Output:
[
   "This    is    an",
   "example  of text",
   "justification.  "
]

Example 2:
Input: words = ["What","must","be","acknowledgment","shall","be"], maxWidth = 16
Output:
[
  "What   must   be",
  "acknowledgment  ",
  "shall be        "
]
Explanation: Note that the last line is "shall be    " instead of "shall     be", because the last line must be left-justified instead of fully-justified.
Note that the second line is also left-justified becase it contains only one word.

Example 3:
Input: words = ["Science","is","what","we","understand","well","enough","to","explain","to","a","computer.","Art","is","everything","else","we","do"], maxWidth = 20
Output:
[
  "Science  is  what we",
  "understand      well",
  "enough to explain to",
  "a  computer.  Art is",
  "everything  else  we",
  "do                  "
]

Constraints:
    1 <= words.length <= 300
    1 <= words[i].length <= 20
    words[i] consists of only English letters and symbols.
    1 <= maxWidth <= 100
    words[i].length <= maxWidth

    Complexity:
        n = words.length
        m = maxWidth
        O(n * m) time complexity
        O() space complexity
    */
    public class TextJustification
    {
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            var lines = new List<string>();
            int l = 0;
            int r = 0;
            do
            {
                (l, r) = GetNextLineWordIds(words, maxWidth, r);
                lines.Add(JustifyLine(words, l, r, maxWidth));
            }
            while (r < words.Length);

            return lines;
        }

        private string JustifyLine(string[] words, int l, int r, int maxWidth)
        {
            var sb = new StringBuilder();
            int wordsInLine = r - l;
            bool isLastLine = r == words.Length;
            bool isLeftJustified = isLastLine || wordsInLine == 1;
            int nonSpaceChars = 0;

            for (int i = l; i < r; i++)
            {
                nonSpaceChars += words[i].Length;
            }

            int spaceChars = maxWidth - nonSpaceChars;
            int spaceCount = wordsInLine == 1 ? 0 : spaceChars / (wordsInLine - 1);
            int extraSpaces = wordsInLine == 1 ? 0 : spaceChars % (wordsInLine - 1);

            void AppendWhitespaces(int count)
            {
                for (int i = 0; i < count; i++)
                {
                    sb.Append(" ");
                }
            }

            for (int i = l; i < r; i++)
            {
                if (i != l)
                {
                    int spaces = isLeftJustified
                        ? 1
                        : i - l <= extraSpaces
                            ? spaceCount + 1
                            : spaceCount;
                    AppendWhitespaces(spaces);
                }

                sb.Append(words[i]);
            }

            if (isLeftJustified)
            {
                AppendWhitespaces(maxWidth - sb.Length);
            }

            return sb.ToString();
        }

        private (int l, int r) GetNextLineWordIds(string[] words, int maxWidth, int l)
        {
            int r = l;
            int chars = 0;
            while (r < words.Length)
            {
                if (chars > 0)
                {
                    ++chars;
                }

                int nextWordLength = words[r].Length;
                if (chars + nextWordLength > maxWidth)
                {
                    break;
                }

                chars += nextWordLength;
                ++r;
            }

            return (l, r);
        }
    }

}