using System;
using System.Linq;
using System.Collections.Generic;
using static System.Math;

namespace Solutions
{
    /*
    1631. Path With Minimum Effort

    Link: https://leetcode.com/problems/path-with-minimum-effort/submissions/
    
    Difficulty: Medium

You are a hiker preparing for an upcoming hike. You are given heights, a 2D array of size rows x columns, where heights[row][col] represents 
the height of cell (row, col). You are situated in the top-left cell, (0, 0), and you hope to travel to the bottom-right cell, (rows-1, columns-1) (i.e., 0-indexed). 
You can move up, down, left, or right, and you wish to find a route that requires the minimum effort.
A route's effort is the maximum absolute difference in heights between two consecutive cells of the route.
Return the minimum effort required to travel from the top-left cell to the bottom-right cell.

Example 1:
Input: heights = [[1,2,2],[3,8,2],[5,3,5]]
Output: 2
Explanation: The route of [1,3,5,3,5] has a maximum absolute difference of 2 in consecutive cells.
This is better than the route of [1,2,2,2,5], where the maximum absolute difference is 3.

Example 2:
Input: heights = [[1,2,3],[3,8,4],[5,3,5]]
Output: 1
Explanation: The route of [1,2,3,4,5] has a maximum absolute difference of 1 in consecutive cells, which is better than route [1,3,5,3,5].

Example 3:
Input: heights = [[1,2,1,1,1],[1,2,1,2,1],[1,2,1,2,1],[1,2,1,2,1],[1,1,1,2,1]]
Output: 0
Explanation: This route does not require any effort.

Constraints:
    rows == heights.length
    columns == heights[i].length
    1 <= rows, columns <= 100
    1 <= heights[i][j] <= 10^6

    Complexity:
        O(n*m) time complexity
        O(n*m) space complexity
    */
    public class PathWithMinimumEffort
    {
        public int MinimumEffortPath(int[][] heights)
        {
            int rows = heights.Length;
            int cols = heights[0].Length;
            var maxDiff = new int[rows, cols];
            var processed = new bool[rows, cols];
            var queue = new Queue<(int, int)>();
            queue.Enqueue((0, 0));

            void ProcessCell(int i, int j)
            {
                int diff = 0;
                if (i > 0 || j > 0)
                {
                    // find the diff if we come from the left/right/top/bottom cell to a current one
                    int left = i > 0 && processed[i - 1, j] ? Max(maxDiff[i - 1, j], Abs(heights[i - 1][j] - heights[i][j])) : int.MaxValue;
                    int right = i < rows - 1 && processed[i + 1, j] ? Max(maxDiff[i + 1, j], Abs(heights[i + 1][j] - heights[i][j])) : int.MaxValue;
                    int top = j > 0 && processed[i, j - 1] ? Max(maxDiff[i, j - 1], Abs(heights[i][j - 1] - heights[i][j])) : int.MaxValue;
                    int bottom = j < cols - 1 && processed[i, j + 1] ? Max(maxDiff[i, j + 1], Abs(heights[i][j + 1] - heights[i][j])) : int.MaxValue;

                    // choose the minimum effort from the 4 incoming edges
                    diff = Min(left, Min(right, Min(top, bottom)));
                }

                // if the maxDiff for the current cell changed, (re-)process connected cells
                if (!processed[i, j] || maxDiff[i, j] > diff)
                {
                    maxDiff[i, j] = diff;
                    processed[i, j] = true;

                    if (i > 0) queue.Enqueue((i - 1, j));
                    if (j > 0) queue.Enqueue((i, j - 1));
                    if (i < rows - 1) queue.Enqueue((i + 1, j));
                    if (j < cols - 1) queue.Enqueue((i, j + 1));
                }
            }

            // bfs
            while (queue.Any())
            {
                (int i, int j) = queue.Dequeue();
                ProcessCell(i, j);
            }

            return maxDiff[rows - 1, cols - 1];
        }
    }
}