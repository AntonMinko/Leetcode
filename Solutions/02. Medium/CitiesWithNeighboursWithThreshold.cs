using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    1334. Find the City With the Smallest Number of Neighbors at a Threshold Distance

    Link: https://leetcode.com/problems/find-the-city-with-the-smallest-number-of-neighbors-at-a-threshold-distance/
    
    Difficulty: medium

There are n cities numbered from 0 to n-1. Given the array edges where edges[i] = [fromi, toi, weighti] 
represents a bidirectional and weighted edge between cities fromi and toi, and given the integer 
distanceThreshold.
Return the city with the smallest number of cities that are reachable through some path and whose 
distance is at most distanceThreshold, If there are multiple such cities, return the city with 
the greatest number.
Notice that the distance of a path connecting cities i and j is equal to the sum of the edges' weights 
along that path.

Example 1:
Input: n = 4, edges = [[0,1,3],[1,2,1],[1,3,4],[2,3,1]], distanceThreshold = 4
Output: 3
Explanation: The figure above describes the graph. 
The neighboring cities at a distanceThreshold = 4 for each city are:
City 0 -> [City 1, City 2] 
City 1 -> [City 0, City 2, City 3] 
City 2 -> [City 0, City 1, City 3] 
City 3 -> [City 1, City 2] 
Cities 0 and 3 have 2 neighboring cities at a distanceThreshold = 4, but we have to return city 3 since 
it has the greatest number.

Example 2:
Input: n = 5, edges = [[0,1,2],[0,4,8],[1,2,3],[1,4,2],[2,3,1],[3,4,1]], distanceThreshold = 2
Output: 0
Explanation: The figure above describes the graph. 
The neighboring cities at a distanceThreshold = 2 for each city are:
City 0 -> [City 1] 
City 1 -> [City 0, City 4] 
City 2 -> [City 3, City 4] 
City 3 -> [City 2, City 4]
City 4 -> [City 1, City 2, City 3] 
The city 0 has 1 neighboring city at a distanceThreshold = 2.

Constraints:
    2 <= n <= 100
    1 <= edges.length <= n * (n - 1) / 2
    edges[i].length == 3
    0 <= fromi < toi < n
    1 <= weighti, distanceThreshold <= 10^4
    All pairs (fromi, toi) are distinct.
    
    Complexity:
        O() time complexity
        O() space complexity
    */
    public class CitiesWithNeighboursWithThreshold
    {
        private record Edge(int from, int to, int weight);

        public int FindTheCity(int n, int[][] edgesList, int distanceThreshold)
        {
            var edges = ToAdjacencyList(n, edgesList, distanceThreshold);

            var reachableCitiesCount = new int[n];
            for (int i = 0; i < n; i++)
            {
                reachableCitiesCount[i] = bfs(n, i, edges, distanceThreshold);
            }

            // Find the smallest number from the end
            int ind = n - 1;
            int min = reachableCitiesCount[ind];
            for (int i = n - 1; i >= 0; i--)
            {
                if (reachableCitiesCount[i] < min)
                {
                    ind = i;
                    min = reachableCitiesCount[i];
                }
            }

            return ind;
        }

        private int bfs(int n, int k, Dictionary<int, List<Edge>> edges, int distanceThreshold)
        {
            var distance = new int[n];
            for (int i = 0; i < n; i++)
            {
                distance[i] = int.MaxValue;
            }
            distance[k] = 0;

            var todo = new Queue<int>();
            todo.Enqueue(k);

            int reachable = 0;
            while (todo.Any())
            {
                int v = todo.Dequeue();
                foreach (var edge in edges[v])
                {
                    int dist = distance[v] + edge.weight;
                    if (distance[edge.to] > dist && dist <= distanceThreshold)
                    {
                        if (distance[edge.to] == int.MaxValue)
                        {
                            // Count each vertice once, later we might re-calculate it again
                            reachable++;
                        }
                        distance[edge.to] = dist;
                        todo.Enqueue(edge.to);
                    }
                }
            }

            return reachable;
        }

        private Dictionary<int, List<Edge>> ToAdjacencyList(int n, int[][] edgesList, int distanceThreshold)
        {
            var edges = new Dictionary<int, List<Edge>>(n);
            for (int i = 0; i < n; i++)
            {
                edges[i] = new List<Edge>();
            }

            foreach (var edgeArr in edgesList)
            {
                if (edgeArr[2] <= distanceThreshold)
                {
                    edges[edgeArr[0]].Add(new Edge(edgeArr[0], edgeArr[1], edgeArr[2]));
                    edges[edgeArr[1]].Add(new Edge(edgeArr[1], edgeArr[0], edgeArr[2]));
                }
            }

            return edges;
        }
    }
}