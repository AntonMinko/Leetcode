using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    200. Number of Islands

    Link: https://leetcode.com/problems/number-of-islands/
    
    Difficulty: Medium

Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. 
An island is surrounded by water and is formed by connecting adjacent lands 
horizontally or vertically. You may assume all four edges of the grid are all 
surrounded by water.

Example 1:

Input:
11110
11010
11000
00000
Output: 1

Example 2:

Input:
11000
11000
00100
00011
Output: 3

    
    */
    public class NumberOfIslands
    {
        public int NumIslands(char[][] grid)
        {
            if (grid.Length == 0) return 0;
            
            Dictionary<int, List<int>> islands = new Dictionary<int, List<int>>();
            Dictionary<int, int> cells = new Dictionary<int, int>();
            int rowLength = grid[0].Length;
            int islandId = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (Is0(grid[i][j])) continue;

                    int curCell = GetCellId(i, j, rowLength);
                    int leftCell = GetCellId(i, j - 1, rowLength);
                    int topCell = GetCellId(i - 1, j, rowLength);
                    int leftIsland = cells.ContainsKey(leftCell) ? cells[leftCell] : -1;
                    int topIsland = cells.ContainsKey(topCell) ? cells[topCell] : -1;
                    if (topIsland <= 0 && leftIsland <= 0)
                    {   // Start a new island
                        islandId++;
                        cells[curCell] = islandId;
                        islands[islandId] = new List<int>();
                        islands[islandId].Add(curCell);
                    }
                    else if (topIsland > 0 && leftIsland > 0 && topIsland != leftIsland)
                    {   // Found top island, so the left one is part of the top one -> merge
                        foreach(int lCell in islands[leftIsland])
                        {
                            cells[lCell] = topIsland;
                        }
                        islands[topIsland].AddRange(islands[leftIsland]);
                        islands.Remove(leftIsland);
                        islands[topIsland].Add(curCell);
                        cells[curCell] = topIsland;
                    }
                    else
                    {
                        int island = leftIsland > 0 ? leftIsland : topIsland;
                        islands[island].Add(curCell);
                        cells[curCell] = island;
                    }
                }
            }
            return islands.Count;
        }

        private int GetCellId(int i, int j, int rowLength)
        {
            if (i < 0 || j < 0) return -1;

            return i * rowLength + j;
        }

        private bool Is0(char c) => c == '0';
    }
}