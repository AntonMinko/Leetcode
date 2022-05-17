using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*

    1091. Shortest Path in Binary Matrix

    Link: https://leetcode.com/problems/shortest-path-in-binary-matrix/
    
    Difficulty: Medium

Given an n x n binary matrix grid, return the length of the shortest clear path in the matrix. If there is no clear path, return -1.
A clear path in a binary matrix is a path from the top-left cell (i.e., (0, 0)) to the bottom-right cell (i.e., (n - 1, n - 1)) such that:
    All the visited cells of the path are 0.
    All the adjacent cells of the path are 8-directionally connected (i.e., they are different and they share an edge or a corner).
The length of a clear path is the number of visited cells of this path.

Example 1:
Input: grid = [[0,1],[1,0]]
Output: 2

Example 2:
Input: grid = [[0,0,0],[1,1,0],[1,1,0]]
Output: 4

Example 3:
Input: grid = [[1,0,0],[1,1,0],[1,1,0]]
Output: -1

Constraints:
    n == grid.length
    n == grid[i].length
    1 <= n <= 100
    grid[i][j] is 0 or 1
    
    Complexity:
        O() time complexity
        O() space complexity
    */
    public class ShortestPathInBinaryMatrix
    {
        public int ShortestPathBinaryMatrix(int[][] grid)
        {
            int n = grid.Length;

            if (grid[0][0] == 1) return -1;

            var queue = new Queue<(int, int)>();
            var queued = new bool[n][];
            var visited = new bool[n][];
            for (int i = 0; i < n; i++)
            {
                queued[i] = new bool[n];
                visited[i] = new bool[n];
            }

            int steps = 1;
            int optionsLeft = 1;
            queue.Enqueue((0, 0));
            queued[0][0] = true;

            IEnumerable<(int, int)> GetOptions(int i, int j)
            {
                if (i < n - 1)
                {
                    yield return (i + 1, j);
                }
                if (i < n - 1 && j < n - 1)
                {
                    yield return (i + 1, j + 1);
                }
                if (j < n - 1)
                {
                    yield return (i, j + 1);
                }
                if (i > 0 && j < n - 1)
                {
                    yield return (i - 1, j + 1);
                }
                if (i > 0)
                {
                    yield return (i - 1, j);
                }
                if (i > 0 && j > 0)
                {
                    yield return (i - 1, j - 1);
                }
                if (j > 0)
                {
                    yield return (i, j - 1);
                }
                if (i < n - 1 && j > 0)
                {
                    yield return (i + 1, j - 1);
                }
            }

            while (queue.Any())
            {
                (int i, int j) = queue.Dequeue();
                if (i == n - 1 && j == n - 1)
                {
                    return steps;
                }

                visited[i][j] = true;
                foreach ((int i1, int j1) in GetOptions(i, j))
                {
                    if (grid[i1][j1] == 0 && !queued[i1][j1])
                    {
                        queue.Enqueue((i1, j1));
                        queued[i1][j1] = true;
                    }
                }

                optionsLeft--;
                if (optionsLeft == 0)
                {
                    steps++;
                    optionsLeft = queue.Count();
                }
            }

            return -1;
        }
    }
}