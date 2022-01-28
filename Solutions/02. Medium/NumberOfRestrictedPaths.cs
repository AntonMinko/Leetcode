using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    1786. Number of Restricted Paths From First to Last Node

    Link: https://leetcode.com/problems/number-of-restricted-paths-from-first-to-last-node/
    
    Difficulty: Medium

There is an undirected weighted connected graph. You are given a positive integer n which denotes that the graph has n nodes labeled from 1 to n, 
and an array edges where each edges[i] = [ui, vi, weighti] denotes that there is an edge between nodes ui and vi with weight equal to weighti.
A path from node start to node end is a sequence of nodes [z0, z1, z2, ..., zk] such that z0 = start and zk = end and there is an edge between zi and zi+1 
where 0 <= i <= k-1.
The distance of a path is the sum of the weights on the edges of the path. Let distanceToLastNode(x) denote the shortest distance of a path between 
node n and node x. A restricted path is a path that also satisfies that distanceToLastNode(zi) > distanceToLastNode(zi+1) where 0 <= i <= k-1.
Return the number of restricted paths from node 1 to node n. Since that number may be too large, return it modulo 109 + 7.

Example 1:
Input: n = 5, edges = [[1,2,3],[1,3,3],[2,3,1],[1,4,2],[5,2,2],[3,5,1],[5,4,10]]
Output: 3
Explanation: Each circle contains the node number in black and its distanceToLastNode value in blue. The three restricted paths are:
1) 1 --> 2 --> 5
2) 1 --> 2 --> 3 --> 5
3) 1 --> 3 --> 5

Example 2:
Input: n = 7, edges = [[1,3,1],[4,1,2],[7,3,4],[2,5,3],[5,6,1],[6,7,2],[7,5,3],[2,6,4]]
Output: 1
Explanation: Each circle contains the node number in black and its distanceToLastNode value in blue. The only restricted path is 1 --> 3 --> 7.

Constraints:
    1 <= n <= 2 * 104
    n - 1 <= edges.length <= 4 * 104
    edges[i].length == 3
    1 <= ui, vi <= n
    ui != vi
    1 <= weighti <= 105
    There is at most one edge between any two nodes.
    There is at least one path between any two nodes.

    Complexity:
        O() time complexity
        O() space complexity
    */
    public class NumberOfRestrictedPaths
    {
        record Edge(int To, int Weight);

        public int CountRestrictedPaths(int n, int[][] edges)
        {
            // 1. build adjacency list
            var adjList = new List<Edge>[n + 1];
            for (int i = 1; i <= n; i++)
            {
                adjList[i] = new List<Edge>();
            }
            foreach (var edgeData in edges)
            {
                adjList[edgeData[0]].Add(new Edge(edgeData[1], edgeData[2]));
                adjList[edgeData[1]].Add(new Edge(edgeData[0], edgeData[2]));
            }

            // 2. calculate distance to last, starting from the last node
            var visited = new bool[n + 1];
            var distance = new int[n + 1];
            var pQueue = new SortedSet<(int, int)>();
            for (int i = 1; i < n; i++)
            {
                distance[i] = int.MaxValue;
            }

            void ProcessNode(int node)
            {
                int dist = distance[node];
                foreach (var edge in adjList[node])
                {
                    if (distance[edge.To] > dist + edge.Weight)
                    {
                        distance[edge.To] = dist + edge.Weight;
                        pQueue.Add((distance[edge.To], edge.To));
                    }
                }
                visited[node] = true;
            }

            // start from node n
            distance[n] = 0;
            pQueue.Add((0, n));
            while (true)
            {
                if (pQueue.Count == 0) break;
                var (dist, node) = pQueue.Min;
                pQueue.Remove((dist, node));

                ProcessNode(node);
            }

            // 3. dfs + memoization to find restricted paths
            var memo = new long[n + 1];
            for (int i = 0; i <= n; i++)
            {
                memo[i] = -1;
            }
            long dfs(int from)
            {
                if (from == n) return 1;
                if (memo[from] != -1) return memo[from];

                long paths = 0;
                int dist = distance[from];
                foreach (var edge in adjList[from])
                {
                    if (dist > distance[edge.To])
                    {
                        paths += dfs(edge.To) % 1_000_000_007;
                    }
                }

                memo[from] = paths;
                return paths;
            }
            return (int)(dfs(1) % 1_000_000_007);
        }
    }
}