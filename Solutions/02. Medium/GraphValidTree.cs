using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    261. Graph Valid Tree

    Link: https://leetcode.com/problems/graph-valid-tree/
    
    Difficulty: Medium

You have a graph of n nodes labeled from 0 to n - 1. You are given an integer n and a list of edges where edges[i] = [ai, bi] 
indicates that there is an undirected edge between nodes ai and bi in the graph.
Return true if the edges of the given graph make up a valid tree, and false otherwise.

Example 1:
Input: n = 5, edges = [[0,1],[0,2],[0,3],[1,4]]
Output: true

Example 2:
Input: n = 5, edges = [[0,1],[1,2],[2,3],[1,3],[1,4]]
Output: false

Constraints:
    1 <= n <= 2000
    0 <= edges.length <= 5000
    edges[i].length == 2
    0 <= ai, bi < n
    ai != bi
    There are no self-loops or repeated edges.

    Complexity:
        O(E*V) time complexity
        O(V) space complexity
    */
    public class GraphValidTree
    {
        public bool ValidTree(int n, int[][] edges)
        {
            var roots = new int[n];
            for (int i = 0; i < n; i++)
            {
                roots[i] = i;
            }
            int treesCount = n;

            int Find(int a)
            {
                if (a == roots[a]) return a;

                roots[a] = Find(roots[a]);
                return roots[a];
            }

            bool UnionIfNew(int a, int b)
            {
                int rootA = Find(a);
                int rootB = Find(b);
                if (rootA == rootB) return false;

                roots[rootA] = rootB;
                treesCount--;
                return true;
            }

            for (int i = 0; i < edges.Length; i++)
            {
                if (!UnionIfNew(edges[i][0], edges[i][1]))
                {
                    return false;
                }
            }

            return treesCount == 1;
        }
    }
}