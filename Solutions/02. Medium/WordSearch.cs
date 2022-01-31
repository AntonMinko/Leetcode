using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    79. Word Search

    Link: https://leetcode.com/problems/word-search/
    
    Difficulty: Medium

Given an m x n grid of characters board and a string word, return true if word exists in the grid.
The word can be constructed from letters of sequentially adjacent cells, where adjacent cells are 
horizontally or vertically neighboring. The same letter cell may not be used more than once.

Example 1:
Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCCED"
Output: true

Example 2:
Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "SEE"
Output: true

Example 3:
Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word = "ABCB"
Output: false

Constraints:
    m == board.length
    n = board[i].length
    1 <= m, n <= 6
    1 <= word.length <= 15
    board and word consists of only lowercase and uppercase English letters.

    Complexity:
        O(m*n) time complexity
        O(m*n) space complexity
    */
    public class WordSearch
    {
        public bool Exist(char[][] board, string word)
        {
            int m = board.Length;
            int n = board[0].Length;
            var used = new bool[m, n];

            bool TryStep(int i, int j, int pos)
            {
                if (i < 0 || i >= m || j < 0 || j >= n ||
                    used[i, j] || board[i][j] != word[pos])
                {
                    return false;
                }

                if (pos == word.Length - 1) return true;

                used[i, j] = true;
                pos++;
                bool found = TryStep(i - 1, j, pos) ||
                             TryStep(i + 1, j, pos) ||
                             TryStep(i, j - 1, pos) ||
                             TryStep(i, j + 1, pos);
                used[i, j] = false;

                return found;
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (TryStep(i, j, 0))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}