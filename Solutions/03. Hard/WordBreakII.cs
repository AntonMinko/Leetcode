using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    140. Word Break II

    Link: https://leetcode.com/problems/word-break-ii/
    
    Difficulty: Hard

Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, add spaces in s to construct a sentence where each word is a valid dictionary word. Return all such possible sentences.

Note:
    The same word in the dictionary may be reused multiple times in the segmentation.
    You may assume the dictionary does not contain duplicate words.

Example 1:
Input:
s = "catsanddog"
wordDict = ["cat", "cats", "and", "sand", "dog"]
Output:
[
  "cats and dog",
  "cat sand dog"
]

Example 2:
Input:
s = "pineapplepenapple"
wordDict = ["apple", "pen", "applepen", "pine", "pineapple"]
Output:
[
  "pine apple pen apple",
  "pineapple pen apple",
  "pine applepen apple"
]
Explanation: Note that you are allowed to reuse a dictionary word.

Example 3:
Input:
s = "catsandog"
wordDict = ["cats", "dog", "sand", "and", "cat"]
Output:
[]

Example 4:
Input:
s = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaabaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"
wordDict = ["a","aa","aaa","aaaa","aaaaa","aaaaaa","aaaaaaa","aaaaaaaa","aaaaaaaaa","aaaaaaaaaa"]
Output:
[]
    
    */
    public class WordBreakII
    {
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            var wordsCombinations = GetWordBreakCombinations(s, wordDict, new Dictionary<string, List<List<string>>>());
            return wordsCombinations.Select(sentenceWords => string.Join(" ", sentenceWords)).ToList();
        }

        private List<List<string>> GetWordBreakCombinations(string s, IList<string> wordDict, IDictionary<string, List<List<string>>> memo)
        {
            if (memo.ContainsKey(s)) return CopyList(memo[s]);
            var result = new List<List<string>>();

            foreach (string word in wordDict)
            {
                if (s.StartsWith(word))
                {
                    string suffix = s.Substring(word.Length);
                    //Console.WriteLine($"word={word}, suffix={suffix}");

                    if (suffix == string.Empty)
                    {
                        result.Add(new List<string> { word });
                    }

                    var suffWords = GetWordBreakCombinations(suffix, wordDict, memo);
                    if (suffWords.Any())
                    {
                        suffWords.ForEach(sentence => sentence.Insert(0, word));
                        result.AddRange(suffWords);
                    }
                }
            }

            memo[s] = CopyList(result);
            return result;
        }

        private List<List<string>> CopyList(List<List<string>> source)
        {
            var dest = new List<List<string>>(source.Count);
            foreach (var l in source)
            {
                dest.Add(new List<string>(l));
            }

            return dest;
        }
    }

}