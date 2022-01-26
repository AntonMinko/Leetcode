using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    815. Bus Routes

    Link: https://leetcode.com/problems/bus-routes/
    
    Difficulty: Hard

You are given an array routes representing bus routes where routes[i] is a bus route 
that the ith bus repeats forever.
For example, if routes[0] = [1, 5, 7], this means that the 0th bus travels 
in the sequence 1 -> 5 -> 7 -> 1 -> 5 -> 7 -> 1 -> ... forever.
You will start at the bus stop source (You are not on any bus initially), and you want 
to go to the bus stop target. You can travel between bus stops by buses only.
Return the least number of buses you must take to travel from source to target. 
Return -1 if it is not possible.

Example 1:
Input: routes = [[1,2,7],[3,6,7]], source = 1, target = 6
Output: 2
Explanation: The best strategy is take the first bus to the bus stop 7, then take the second bus 
to the bus stop 6.

Example 2:
Input: routes = [[7,12],[4,5,15],[6],[15,19],[9,12,13]], source = 15, target = 12
Output: -1

Constraints:
    1 <= routes.length <= 500.
    1 <= routes[i].length <= 105
    All the values of routes[i] are unique.
    sum(routes[i].length) <= 105
    0 <= routes[i][j] < 106
    0 <= source, target < 106
    
    Complexity:
        O() time complexity
        O() space complexity
    */
    public class BusRoutes
    {
        record RouteWithDistance(int Route, int Distance);

        public int NumBusesToDestination(int[][] routes, int source, int target)
        {
            if (source == target) return 0;

            // build a graph of routes (not stations): Vertex is a route and Edge is a connection between two routes
            var map = new Dictionary<int, List<int>>();  // station -> route
            var adjList = new List<int>[routes.Length];
            for (int i = 0; i < routes.Length; i++)
            {
                adjList[i] = new List<int>();
                // map bus stops to route i:
                foreach (int stop in routes[i])
                {
                    if (map.ContainsKey(stop))
                    {
                        // this stop is part of other routes, add edges:
                        foreach (int otherRoute in map[stop])
                        {
                            adjList[i].Add(otherRoute);
                            adjList[otherRoute].Add(i);
                        }
                    }
                    else
                    {
                        map.Add(stop, new List<int>());
                    }
                    map[stop].Add(i);
                }
            }

            // ensure source and target stations belong to at least one route
            if (!map.ContainsKey(source) || !map.ContainsKey(target))
            {
                return -1;
            }

            var finishSet = new HashSet<int>(map[target]);
            var queue = new Queue<RouteWithDistance>();
            var visited = new bool[adjList.Length];

            foreach (int route in map[source])
            {
                if (finishSet.Contains(route)) return 1;
                queue.Enqueue(new RouteWithDistance(route, 1));
            }

            // bfs to find the shortest route
            while (queue.Count > 0)
            {
                var routeDist = queue.Dequeue();
                int route = routeDist.Route;
                int distance = routeDist.Distance + 1;
                foreach (int next in adjList[route])
                {
                    if (!visited[next])
                    {
                        if (finishSet.Contains(next))
                        {
                            return distance;
                        }
                        else
                        {
                            queue.Enqueue(new RouteWithDistance(next, distance));
                        }
                    }
                }
                visited[route] = true;
            }

            return -1;
        }
    }
}