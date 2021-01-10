using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    54. Spiral Matrix

    Link: https://leetcode.com/problems/spiral-matrix/
    
    Difficulty: Medium

Given an m x n matrix, return all elements of the matrix in spiral order.

Example 1:
Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
Output: [1,2,3,6,9,8,7,4,5]

Example 2:
Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
Output: [1,2,3,4,8,12,11,10,9,5,6,7]

Constraints:
    m == matrix.length
    n == matrix[i].length
    1 <= m, n <= 10
    -100 <= matrix[i][j] <= 100

Tags:
    Array, recursion

Complexity:
    O(m*n) time
    O(m*n) space
    
    */
    public class SpiralMatrix
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            return OuterItems(matrix, 0, matrix.Length, 0, matrix[0].Length);
        }

        private IList<int> OuterItems(int[][] matrix, int x_l, int x_h, int y_l, int y_h)
        {
            var items = new List<int>();

            // top row
            for (int j = y_l; j < y_h; j++)
            {
                items.Add(matrix[x_l][j]);
            }

            //right column
            if (x_h - x_l > 1)
            {
                for (int i = x_l + 1; i < x_h; i++)
                {
                    items.Add(matrix[i][y_h - 1]);
                }
            }

            // bottom row
            if (x_h - x_l > 1 && y_h - y_l > 1)
            {
                for (int j = y_h - 2; j >= y_l; j--)
                {
                    items.Add(matrix[x_h - 1][j]);
                }
            }

            //left column
            if (x_h - x_l > 1 && y_h - y_l > 1)
            {
                for (int i = x_h - 2; i > x_l; i--)
                {
                    items.Add(matrix[i][y_l]);
                }
            }

            if (x_h - x_l > 2 && y_h - y_l > 2)
            {
                items.AddRange(OuterItems(matrix, x_l + 1, x_h - 1, y_l + 1, y_h - 1));
            }

            return items;
        }
    }

}