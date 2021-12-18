using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    743. Network Delay Time

    Link: https://leetcode.com/problems/network-delay-time/
    
    Difficulty: Medium

You are given a network of n nodes, labeled from 1 to n. You are also given times, a list of travel times 
as directed edges times[i] = (ui, vi, wi), where ui is the source node, vi is the target node, 
and wi is the time it takes for a signal to travel from source to target.

We will send a signal from a given node k. Return the time it takes for all the n nodes to receive 
the signal. If it is impossible for all the n nodes to receive the signal, return -1.

Example 1:
Input: times = [[2,1,1],[2,3,1],[3,4,1]], n = 4, k = 2
Output: 2

Example 2:
Input: times = [[1,2,1]], n = 2, k = 1
Output: 1

Example 3:
Input: times = [[1,2,1]], n = 2, k = 2
Output: -1 

Constraints:
    1 <= k <= n <= 100
    1 <= times.length <= 6000
    times[i].length == 3
    1 <= ui, vi <= n
    ui != vi
    0 <= wi <= 100
    All the pairs (ui, vi) are unique. (i.e., no multiple edges.)
    
    Complexity:
        O(V+E) time complexity
        O(V+E) space complexity
    */
    public class NetworkDelayTime
    {
        private record Edge(int from, int to, int weight);

        public int GetNetworkDelayTime(int[][] times, int n, int k)
        {
            var edges = ToEdgesList(times, n);

            // calculated minimum delays, ignore delay[0] to keep all indexes 1-based
            int startFrom = k;
            var delay = new int[n + 1];
            for (int i = 1; i < delay.Length; i++)
            {
                delay[i] = int.MaxValue;
            }
            delay[startFrom] = 0;

            // BFS
            var todo = new Queue<int>();
            todo.Enqueue(startFrom);

            while (todo.Any())
            {
                int v = todo.Dequeue();
                foreach (var edge in edges[v])
                {
                    if (delay[edge.to] > delay[edge.from] + edge.weight)
                    {
                        delay[edge.to] = delay[edge.from] + edge.weight;
                        todo.Enqueue(edge.to);
                    }
                }
            }

            int maxDelay = delay.Max();
            return maxDelay == int.MaxValue ? -1 : maxDelay;
        }

        private Dictionary<int, List<Edge>> ToEdgesList(int[][] times, int n)
        {
            var edges = new Dictionary<int, List<Edge>>();
            for (int i = 1; i <= n; i++)
            {
                edges.Add(i, new List<Edge>());
            }
            for (int i = 0; i < times.Length; i++)
            {
                var edge = new Edge(times[i][0], times[i][1], times[i][2]);
                if (!edges.ContainsKey(edge.from))
                {
                    edges[edge.from] = new List<Edge>();
                }
                edges[edge.from].Add(edge);
            }
            return edges;
        }
    }
}