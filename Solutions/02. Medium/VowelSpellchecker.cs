using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    966. Vowel Spellchecker

    Link: https://leetcode.com/problems/vowel-spellchecker/
    
    Difficulty: Medium

Given a wordlist, we want to implement a spellchecker that converts a query word into a correct word.
For a given query word, the spell checker handles two categories of spelling mistakes:

    Capitalization: If the query matches a word in the wordlist (case-insensitive), then the query word is returned with the same case as the case in the wordlist.
        Example: wordlist = ["yellow"], query = "YellOw": correct = "yellow"
        Example: wordlist = ["Yellow"], query = "yellow": correct = "Yellow"
        Example: wordlist = ["yellow"], query = "yellow": correct = "yellow"
    Vowel Errors: If after replacing the vowels ('a', 'e', 'i', 'o', 'u') of the query word with any vowel individually, it matches a word in the wordlist (case-insensitive), then the query word is returned with the same case as the match in the wordlist.
        Example: wordlist = ["YellOw"], query = "yollow": correct = "YellOw"
        Example: wordlist = ["YellOw"], query = "yeellow": correct = "" (no match)
        Example: wordlist = ["YellOw"], query = "yllw": correct = "" (no match)

In addition, the spell checker operates under the following precedence rules:
    When the query exactly matches a word in the wordlist (case-sensitive), you should return the same word back.
    When the query matches a word up to capitlization, you should return the first such match in the wordlist.
    When the query matches a word up to vowel errors, you should return the first such match in the wordlist.
    If the query has no matches in the wordlist, you should return the empty string.

Given some queries, return a list of words answer, where answer[i] is the correct word for query = queries[i].

Example 1:
Input: wordlist = ["KiTe","kite","hare","Hare"], queries = ["kite","Kite","KiTe","Hare","HARE","Hear","hear","keti","keet","keto"]
Output: ["kite","KiTe","KiTe","Hare","hare","","","KiTe","","KiTe"]

Note:
    1 <= wordlist.length <= 5000
    1 <= queries.length <= 5000
    1 <= wordlist[i].length <= 7
    1 <= queries[i].length <= 7
    All strings in wordlist and queries consist only of english letters.
    
    Complexity:
        O() time complexity
        O() space complexity
    */
    public class VowelSpellchecker
    {
        public string[] Spellchecker(string[] wordlist, string[] queries)
        {
            // Initialize
            var dictionary = new Dictionary<string, int>();
            var permutations = new Dictionary<string, int>();

            for (int i = 0; i < wordlist.Length; i++)
            {
                string word = wordlist[i];
                if (!dictionary.ContainsKey(word))
                {
                    dictionary.Add(word, i);
                }
            }

            for (int i = 0; i < wordlist.Length; i++)
            {
                string word = wordlist[i];
                word = word.ToLower();
                if (!permutations.ContainsKey(word))
                {
                    permutations.Add(word, i);
                }

                word = RemoveVowels(word);
                if (!permutations.ContainsKey(word))
                {
                    permutations.Add(word, i);
                }
            }

            int? TryFindIndex(string query, bool ignoreCase)
            {
                if (!ignoreCase && dictionary.ContainsKey(query))
                {
                    return dictionary[query];
                }

                if (ignoreCase && permutations.ContainsKey(query))
                {
                    return permutations[query];
                }

                return null;
            }

            var result = new string[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                string query = queries[i];
                int? index = TryFindIndex(query, false) ?? TryFindIndex(query.ToLower(), true) ?? TryFindIndex(RemoveVowels(query.ToLower()), true);
                result[i] = index != null ? wordlist[index.Value] : string.Empty;
            }

            return result;
        }

        private string RemoveVowels(string word)
        {
            var sb = new StringBuilder();
            foreach (char c in word)
            {
                switch (c)
                {
                    case 'a':
                    case 'e':
                    case 'i':
                    case 'o':
                    case 'u':
                        sb.Append('_');
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }

            return sb.ToString();
        }
    }

}