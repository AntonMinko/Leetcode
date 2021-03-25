using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    417. Pacific Atlantic Water Flow

    Link: https://leetcode.com/problems/pacific-atlantic-water-flow/
    
    Difficulty: Medium

Given an m x n matrix of non-negative integers representing the height of each unit cell in a continent, 
the "Pacific ocean" touches the left and top edges of the matrix and the "Atlantic ocean" touches the right and bottom edges.
Water can only flow in four directions (up, down, left, or right) from a cell to another one with height equal or lower.
Find the list of grid coordinates where water can flow to both the Pacific and Atlantic ocean.
Note:
    The order of returned grid coordinates does not matter.
    Both m and n are less than 150.
    
Example:
Given the following 5x5 matrix:
  Pacific ~   ~   ~   ~   ~ 
       ~  1   2   2   3  (5) *
       ~  3   2   3  (4) (4) *
       ~  2   4  (5)  3   1  *
       ~ (6) (7)  1   4   5  *
       ~ (5)  1   1   2   4  *
          *   *   *   *   * Atlantic
Return:
[[0, 4], [1, 3], [1, 4], [2, 2], [3, 0], [3, 1], [4, 0]] (positions with parentheses in above matrix).

    Complexity:
        O() time complexity
        O() space complexity
    */
    public class OceansWaterFlow
    {
        [Flags]
        enum Oceans
        {
            None = 0,
            Pacific = 1,
            Atlantic = 2,
            Both = Pacific | Atlantic,
        }

        public IList<IList<int>> PacificAtlantic(int[][] matrix)
        {
            if (matrix.Length == 0 || matrix[0].Length == 0) return new List<IList<int>>();

            int N = matrix.Length;
            int M = matrix[0].Length;

            var oceans = new Oceans[N, M];
            var queue = new Queue<(int, int)>();

            bool HasOcean(Oceans val, Oceans ocean) => (val & ocean) == ocean;

            void ProcessQueue(Oceans ocean)
            {
                while (queue.Any())
                {
                    (int i, int j) = queue.Dequeue();
                    oceans[i, j] |= ocean;
                    //Console.WriteLine($"Cur {i},{j} = {oceans[i,j]}");

                    if (i > 0 && !HasOcean(oceans[i - 1, j], ocean) && matrix[i - 1][j] >= matrix[i][j])
                    {
                        oceans[i - 1, j] |= ocean;
                        queue.Enqueue((i - 1, j));
                        //Console.WriteLine($"{i-1},{j} = {oceans[i-1,j]}");
                    }
                    if (j > 0 && !HasOcean(oceans[i, j - 1], ocean) && matrix[i][j - 1] >= matrix[i][j])
                    {
                        oceans[i, j - 1] |= ocean;
                        queue.Enqueue((i, j - 1));
                        //Console.WriteLine($"{i},{j-1} = {oceans[i,j-1]}");
                    }

                    if (i < N - 1 && !HasOcean(oceans[i + 1, j], ocean) && matrix[i + 1][j] >= matrix[i][j])
                    {
                        oceans[i + 1, j] |= ocean;
                        queue.Enqueue((i + 1, j));
                        //Console.WriteLine($"{i+1},{j} = {oceans[i+1,j]}");
                    }
                    if (j < M - 1 && !HasOcean(oceans[i, j + 1], ocean) && matrix[i][j + 1] >= matrix[i][j])
                    {
                        oceans[i, j + 1] |= ocean;
                        queue.Enqueue((i, j + 1));
                        //Console.WriteLine($"{i},{j+1} = {oceans[i,j+1]}");
                    }
                }
            }

            // Pacific
            for (int i = 0; i < N; i++)
            {
                queue.Enqueue((i, 0));
            }
            for (int j = 0; j < M; j++)
            {
                queue.Enqueue((0, j));
            }
            ProcessQueue(Oceans.Pacific);

            // Atlantic
            for (int i = 0; i < N; i++)
            {
                queue.Enqueue((i, M - 1));
            }
            for (int j = 0; j < M; j++)
            {
                queue.Enqueue((N - 1, j));
            }
            ProcessQueue(Oceans.Atlantic);

            var result = new List<IList<int>>();
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (oceans[i, j] == Oceans.Both)
                    {
                        result.Add(new List<int> { i, j });
                    }
                }
            }

            return result;
        }
    }

}