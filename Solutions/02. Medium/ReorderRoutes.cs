﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace Solutions
{
    /*
    1466. Reorder Routes to Make All Paths Lead to the City Zero

    Link: https://leetcode.com/problems/reorder-routes-to-make-all-paths-lead-to-the-city-zero/
    
    Difficulty: Medium

There are n cities numbered from 0 to n - 1 and n - 1 roads such that there is only one way 
to travel between two different cities (this network form a tree). Last year, The ministry of transport 
decided to orient the roads in one direction because they are too narrow.
Roads are represented by connections where connections[i] = [ai, bi] represents a road from 
city ai to city bi.
This year, there will be a big event in the capital (city 0), and many people want to travel to this city.
Your task consists of reorienting some roads such that each city can visit the city 0. 
Return the minimum number of edges changed.
It's guaranteed that each city can reach city 0 after reorder.

Example 1:
Input: n = 6, connections = [[0,1],[1,3],[2,3],[4,0],[4,5]]
Output: 3
Explanation: Change the direction of edges show in red such that each node can reach the node 0 (capital).

Example 2:
Input: n = 5, connections = [[1,0],[1,2],[3,2],[3,4]]
Output: 2
Explanation: Change the direction of edges show in red such that each node can reach the node 0 (capital).

Example 3:
Input: n = 3, connections = [[1,0],[2,0]]
Output: 0

Constraints:
    2 <= n <= 5 * 104
    connections.length == n - 1
    connections[i].length == 2
    0 <= ai, bi <= n - 1
    ai != bi
    
    Complexity:
        O(V+E) time complexity
        O(V+E) space complexity
    */
    public class ReorderRoutes
    {
        public int MinReorder(int n, int[][] connections)
        {
            var adjList = new List<int>[n];
            var reverseAdjList = new List<int>[n];
            for (int i = 0; i < n; i++)
            {
                adjList[i] = new List<int>();
                reverseAdjList[i] = new List<int>();
            }

            foreach (var connection in connections)
            {
                int from = connection[0];
                int to = connection[1];
                adjList[from].Add(to);
                reverseAdjList[to].Add(from);
            }

            var queue = new Queue<int>();
            queue.Enqueue(0);
            var visited = new bool[n];
            int reorders = 0;

            // bfs for all ingoing and outgoing nodes
            while (queue.Any())
            {
                int cur = queue.Dequeue();
                if (visited[cur]) continue;

                visited[cur] = true;

                foreach (int outNode in adjList[cur])
                {
                    if (!visited[outNode])
                    {
                        queue.Enqueue(outNode);
                        ++reorders;
                    }
                }

                foreach (int inNode in reverseAdjList[cur])
                {
                    if (!visited[inNode])
                    {
                        queue.Enqueue(inNode);
                    }
                }
            }

            return reorders;
        }
    }
}