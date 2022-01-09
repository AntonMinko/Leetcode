using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    1584. Min Cost to Connect All Points

    Link: https://leetcode.com/problems/min-cost-to-connect-all-points/
    
    Difficulty: Medium

You are given an array points representing integer coordinates of some points on a 2D-plane, 
where points[i] = [xi, yi].
The cost of connecting two points [xi, yi] and [xj, yj] is the manhattan distance between them: 
|xi - xj| + |yi - yj|, where |val| denotes the absolute value of val.
Return the minimum cost to make all points connected. All points are connected if there is 
exactly one simple path between any two points.

Example 1:
Input: points = [[0,0],[2,2],[3,10],[5,2],[7,0]]
Output: 20
Explanation: 
We can connect the points as shown above to get the minimum cost of 20.
Notice that there is a unique path between every pair of points.

Example 2:
Input: points = [[3,12],[-2,5],[-4,1]]
Output: 18

Constraints:
    1 <= points.length <= 1000
    -106 <= xi, yi <= 106
    All pairs (xi, yi) are distinct.

    Complexity:
        E = N*N
        O(E*logE) time complexity
        O(E) space complexity
    */
    public class MinCostToConnectPoints
    {
        private record Edge(int V1, int V2, int Weight) { }

        public int MinCostConnectPoints(int[][] points)
        {
            var N = points.Length;
            if (N < 2) return 0;
            var queue = new Edge[(N * (N - 1)) / 2];

            int pos = 0;
            for (int i = 0; i < N - 1; i++)
            {
                var fromPoint = points[i];
                for (int j = i + 1; j < N; j++)
                {
                    var toPoint = points[j];
                    int dist = Math.Abs(fromPoint[0] - toPoint[0]) + Math.Abs(fromPoint[1] - toPoint[1]);
                    var edge = new Edge(i, j, dist);
                    queue[pos] = edge;
                    ++pos;
                }
            }
            Array.Sort(queue, (x, y) => x.Weight - y.Weight);

            var roots = new int[N];
            for (int i = 0; i < N; i++)
            {
                roots[i] = i;
            }

            int Find(int v)
            {
                if (roots[v] != v)
                {
                    roots[v] = Find(roots[v]);
                }
                return roots[v];
            }

            void Union(int x1, int x2)
            {
                int rootX1 = Find(x1);
                int rootX2 = Find(x2);
                if (rootX1 != rootX2)
                {
                    roots[rootX1] = rootX2;
                }
            }

            bool IsConnected(int x1, int x2)
            {
                return Find(x1) == Find(x2);
            }

            int cost = 0;
            int components = N;
            for (int i = 0; i < queue.Length; i++)
            {
                Edge edge = queue[i];
                if (IsConnected(edge.V1, edge.V2)) continue;

                Union(edge.V1, edge.V2);
                cost += edge.Weight;
                --components;
                if (components == 1)
                {
                    break;
                }
            }

            return cost;
        }
    }
}