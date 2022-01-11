using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    959. Regions Cut By Slashes

    Link: https://leetcode.com/problems/regions-cut-by-slashes/
    
    Difficulty: Medium

An n x n grid is composed of 1 x 1 squares where each 1 x 1 square consists of a '/', '\', 
or blank space ' '. These characters divide the square into contiguous regions.
Given the grid grid represented as a string array, return the number of regions.
Note that backslash characters are escaped, so a '\' is represented as '\\'.

Example 1:
Input: grid = [" /","/ "]
Output: 2

Example 2:
Input: grid = [" /","  "]
Output: 1

Example 3:
Input: grid = ["/\\","\\/"]
Output: 5
Explanation: Recall that because \ characters are escaped, "\\/" refers to \/, and "/\\" refers to /\.

Constraints:
    n == grid.length == grid[i].length
    1 <= n <= 30
    grid[i][j] is either '/', '\', or ' '.

    Complexity:
        O() time complexity
        O() space complexity
    */
    public class RegionsCutBySlashes
    {
        public int RegionsBySlashes(string[] grid)
        {
            int n = grid.Length;

            // split each cell into two: left and right subcells. If whitespace, Union them.
            int components = 2 * n * n;
            var roots = new int[components];
            for (int i = 0; i < components; i++)
            {
                roots[i] = i;
            }

            int Find(int x)
            {
                if (roots[x] != x)
                {
                    roots[x] = Find(roots[x]);
                }

                return roots[x];
            }

            void Union(int x, int y)
            {

                int rootX = Find(x);
                int rootY = Find(y);

                if (rootX != rootY)
                {
                    roots[rootX] = rootY;
                    --components;
                }
            }

            for (int i = 0; i < n; i++)
            {
                string row = grid[i];
                for (int j = 0; j < n; j++)
                {
                    int above = -1;
                    if (i > 0)
                    {
                        char aboveCh = grid[i - 1][j];
                        int ind = (i - 1) * 2 * n + 2 * j;
                        if (aboveCh == '/')
                        {
                            // right subcell
                            ++ind;
                        }
                        above = Find(ind);
                    }

                    int left = 2 * i * n + 2 * j;
                    int right = left + 1;
                    if (j > 0)
                    {
                        Union(left - 1, left);
                    }
                    if (row[j] == ' ')
                    {
                        Union(left, right);
                    }
                    if (above != -1)
                    {
                        if (row[j] == '\\')
                        {
                            Union(right, above);
                        }
                        else
                        {
                            Union(left, above);
                        }
                    }
                }
            }

            return components;
        }
    }
}