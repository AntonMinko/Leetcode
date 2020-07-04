using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    64. Minimum Path Sum

    Link: https://leetcode.com/problems/minimum-path-sum/
    
    Difficulty: Medium

Given a m x n grid filled with non-negative numbers, find a path from top left to bottom right which minimizes the sum of all numbers along its path.

Note: You can only move either down or right at any point in time.

Example:

Input:
[
  [1,3,1],
  [1,5,1],
  [4,2,1]
]
Output: 7
Explanation: Because the path 1→3→1→1→1 minimizes the sum.
    
    */
    public class MinimumPathSum
    {
        public int MinPathSum(int[][] grid)
        {
            if (grid.Length == 0) return 0;

            int n = grid.Length;
            int m = grid[0].Length;
            for(int i=0; i<n; i++)
            {
                for (int j=0; j<m; j++)
                {
                    if (i==0 && j==0) continue;

                    int leftPath = i>0 ? grid[i-1][j] + grid[i][j] : int.MaxValue;
                    int topPath = j>0 ? grid[i][j-1] + grid[i][j] : int.MaxValue;
                    grid[i][j] = Math.Min(leftPath, topPath);
                }
            }
            return grid[n-1][m-1];
        }
    }

}