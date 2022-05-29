using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    212. Word Search II

    Link: https://leetcode.com/problems/word-search-ii/
    
    Difficulty: Hard

Given an m x n board of characters and a list of strings words, return all words on the board.

Each word must be constructed from letters of sequentially adjacent cells, 
where adjacent cells are horizontally or vertically neighboring. 
The same letter cell may not be used more than once in a word.

Example 1:
Input: board = [["o","a","a","n"],["e","t","a","e"],["i","h","k","r"],["i","f","l","v"]], words = ["oath","pea","eat","rain"]
Output: ["eat","oath"]

Example 2:
Input: board = [["a","b"],["c","d"]], words = ["abcb"]
Output: []

Constraints:
    m == board.length
    n == board[i].length
    1 <= m, n <= 12
    board[i][j] is a lowercase English letter.
    1 <= words.length <= 3 * 104
    1 <= words[i].length <= 10
    words[i] consists of lowercase English letters.
    All the strings of words are unique.
    
    Complexity:
        l = max word length
        O(m*n*l) time complexity
        O(chars in words) space complexity
    */
    public class WordSearchII
    {
        class TrieNode
        {
            public Dictionary<char, TrieNode> Nested { get; } = new Dictionary<char, TrieNode>();
            public string Word { get; set; }
        }

        private TrieNode PopulateTrie(string[] words)
        {
            var root = new TrieNode();

            void AddLetter(TrieNode node, string word, int pos)
            {
                if (pos == word.Length)
                {
                    node.Word = word;
                    return;
                }

                char ch = word[pos];
                if (!node.Nested.ContainsKey(ch))
                {
                    node.Nested[ch] = new TrieNode();
                }
                AddLetter(node.Nested[ch], word, pos + 1);
            }

            foreach (string word in words)
            {
                AddLetter(root, word, 0);
            }

            return root;
        }

        public IList<string> FindWords(char[][] board, string[] words)
        {
            int m = board.Length;
            int n = board[0].Length;
            var trie = PopulateTrie(words);
            var results = new List<string>();

            void FindWord(TrieNode node, int i, int j)
            {
                if (node.Word != null)
                {
                    results.Add(node.Word);
                    node.Word = null;
                }

                char ch = board[i][j];
                board[i][j] = ' ';
                if (i > 0 && node.Nested.ContainsKey(board[i - 1][j]))
                {
                    FindWord(node.Nested[board[i - 1][j]], i - 1, j);
                }
                if (i < m - 1 && node.Nested.ContainsKey(board[i + 1][j]))
                {
                    FindWord(node.Nested[board[i + 1][j]], i + 1, j);
                }
                if (j > 0 && node.Nested.ContainsKey(board[i][j - 1]))
                {
                    FindWord(node.Nested[board[i][j - 1]], i, j - 1);
                }
                if (j < n - 1 && node.Nested.ContainsKey(board[i][j + 1]))
                {
                    FindWord(node.Nested[board[i][j + 1]], i, j + 1);
                }
                board[i][j] = ch;
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (trie.Nested.ContainsKey(board[i][j]))
                    {
                        FindWord(trie.Nested[board[i][j]], i, j);
                    }
                }
            }

            return results;
        }
    }
}