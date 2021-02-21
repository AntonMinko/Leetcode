using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    Grid traveler

You are a traveler on a 2D grid. You begin at the top-left corner and your goal is to travel 
to the bottom-right corner. You may only move down or right.
In how many ways can you travel to the goal on a grid with dimentions m*n?
    
    Complexity:
        O(m*n) time complexity
        O(m*n) space complexity
    */
    public class GridTravelerTabulation
    {
        public long CountWays(int m, int n)
        {
            if (m == 0 || n == 0) return 0;

            long[,] table = new long[m, n];
            table[0, 0] = 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i + 1 < m) table[i + 1, j] += table[i, j];
                    if (j + 1 < n) table[i, j + 1] += table[i, j];
                }
            }

            return table[m - 1, n - 1];
        }
    }

}