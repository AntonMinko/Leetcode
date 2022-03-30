using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    74. Search a 2D Matrix
    
    Link: https://leetcode.com/problems/search-a-2d-matrix/
    
    Difficulty: Medium

Write an efficient algorithm that searches for a value target in an m x n integer matrix matrix. This matrix has the following properties:
    Integers in each row are sorted from left to right.
    The first integer of each row is greater than the last integer of the previous row.

Example 1:
Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 3
Output: true

Example 2:
Input: matrix = [[1,3,5,7],[10,11,16,20],[23,30,34,60]], target = 13
Output: false

Constraints:
    m == matrix.length
    n == matrix[i].length
    1 <= m, n <= 100
    -104 <= matrix[i][j], target <= 104
    
    Complexity:
        O(log(m*n)) time complexity
        O(1) space complexity
    */
    public class SearchInMatrix
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int size = m * n;

            bool Contains(int target)
            {
                int l = 0;
                int r = size - 1;
                while (l <= r)
                {
                    int mid = l + (r - l) / 2;
                    int row = mid / n;
                    int column = mid % n;
                    int val = matrix[row][column];

                    if (val == target) return true;
                    if (val < target)
                    {
                        l = mid + 1;
                    }
                    else
                    {
                        r = mid - 1;
                    }
                }

                return false;
            }

            return Contains(target);
        }
    }
}