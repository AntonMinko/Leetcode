using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    221. Maximal Square

    Link: https://leetcode.com/problems/maximal-square/
    
    Difficulty: Medium

Given a 2D binary matrix filled with 0's and 1's, find the largest square containing 
only 1's and return its area.

Example:
Input: 
1 0 1 0 0
1 0 1 1 1
1 1 1 1 1
1 0 0 1 0
Output: 4
    
    */
    public class MaximalSquareProblem
    {
        public int MaximalSquare(char[][] matrix)
        {
            if (matrix.Length == 0) return 0;

            int n = matrix.Length;
            int m = matrix[0].Length;
            int[,] verticals = CalculateVerticals(matrix, n, m);
            int[,] horizontals = CalculateHorizontals(matrix, n, m);

            int maxSide = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    int candidateSide = GetSquareSide(verticals, horizontals, i, j);
                    if (candidateSide <= maxSide) continue;
                    for (int k = 1; k < candidateSide; k++)
                    {
                        int side = GetSquareSide(verticals, horizontals, i+k, j+k);
                        candidateSide = Math.Min(candidateSide, side + k);
                        if (side <= 1)
                        {
                            break;
                        }
                    }
                    maxSide = Math.Max(candidateSide,maxSide);
                }
            }

            return maxSide*maxSide;
        }

        private int GetSquareSide(int[,] verticals, int[,] horizontals, int i, int j)
        {
            return Math.Min(horizontals[i,j], verticals[i,j]);
        }

        private static int[,] CalculateVerticals(char[][] matrix, int n, int m)
        {
            int[,] verticals = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i][j] == '0') continue;

                    int count = 1;
                    for (int k = i + 1; k < n; k++)
                    {
                        if (matrix[k][j] == '0') break;
                        
                        ++count;
                    }
                    verticals[i, j] = count;
                }
            }
            return verticals;
        }

        private static int[,] CalculateHorizontals(char[][] matrix, int n, int m)
        {
            int[,] horizontals = new int[n,m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matrix[i][j] == '0') continue;

                    int count = 1;
                    for (int k = j + 1; k < m; k++)
                    {
                        if (matrix[i][k] == '0') break;
                        
                        ++count;
                    }
                    horizontals[i,j] = count;
                }
            }
            return horizontals;
        }
    }

}