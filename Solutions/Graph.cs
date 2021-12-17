using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    public class Graph
    {
        public int V { get; private set; }

        public List<int>[] AdjacencyList { get; private set; }

        public Graph(int v)
        {
            V = v;
            AdjacencyList = new List<int>[v];

            for (int i = 0; i < V; i++)
            {
                AdjacencyList[i] = new List<int>();
            }
        }

        public Graph(int v, int[][] edges)
        : this(v)
        {
            foreach (var edge in edges)
            {
                AdjacencyList[edge[0]].Add(edge[1]);
            }
        }

        public bool ContainsCycle()
        {
            bool[] visited = new bool[V];
            
            bool ContainsCycle(int v, HashSet<int> path)
            {
                if (path.Contains(v))
                {
                    return true;
                }

                if (visited[v])
                {
                    return false;
                }

                visited[v] = true;
                path.Add(v);

                if (AdjacencyList[v].Any(n => ContainsCycle(n, path)))
                {
                    return true;
                }
                else
                {
                    path.Remove(v);
                    return false;
                }
            }

            for(int i=0; i<V; i++)
            {
                if (!visited[i])
                {
                    if (ContainsCycle(i, new HashSet<int>()))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}