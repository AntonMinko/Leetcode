﻿using System;
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
        O(E^2+(V+E)) time complexity
        O(V+E) space complexity
    */
    public class NetworkDelayTimeDijkstra
    {
        private record Edge(int To, int Weight);

        public int NetworkDelayTime(int[][] times, int n, int k)
        {
            var adjList = new List<Edge>[n + 1];
            for (int i = 1; i <= n; i++)
            {
                adjList[i] = new List<Edge>();
            }
            //O(V)
            foreach (var edge in times)
            {
                adjList[edge[0]].Add(new Edge(edge[1], edge[2]));
            }

            var visited = new bool[n + 1];
            var distance = new int[n + 1];
            for (int i = 1; i <= n; i++)
            {
                distance[i] = int.MaxValue;
            }
            distance[k] = 0;
            int visitedCount = 0;

            //O(E)
            int FindNextNode()
            {
                int min = int.MaxValue;
                int node = -1;
                for (int i = 1; i <= n; i++)
                {
                    if (!visited[i] && min > distance[i])
                    {
                        min = distance[i];
                        node = i;
                    }
                }

                return node;
            }

            //O(E)
            while (visitedCount < n)
            {
                int i = FindNextNode(); //O(E)
                if (i == -1)
                {
                    return -1;
                }

                int distToI = distance[i];
                //O(V) for all E
                foreach (var edge in adjList[i])
                {
                    if (distance[edge.To] > distToI + edge.Weight)
                    {
                        distance[edge.To] = distToI + edge.Weight;
                    }
                }
                visited[i] = true;
                visitedCount++;
            }

            //O(E)
            return distance.Max();
        }
    }
}