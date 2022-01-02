using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    547. Number of Provinces

    Link: https://leetcode.com/problems/number-of-provinces/
    
    Difficulty: Medium

There are n cities. Some of them are connected, while some are not. If city a is connected directly with city b, and city b is connected directly 
with city c, then city a is connected indirectly with city c.
A province is a group of directly or indirectly connected cities and no other cities outside of the group.
You are given an n x n matrix isConnected where isConnected[i][j] = 1 if the ith city and the jth city are directly connected, and isConnected[i][j] = 0 otherwise.
Return the total number of provinces.

Example 1:
Input: isConnected = [[1,1,0],[1,1,0],[0,0,1]]
Output: 2

Example 2:
Input: isConnected = [[1,0,0],[0,1,0],[0,0,1]]
Output: 3

Constraints:
    1 <= n <= 200
    n == isConnected.length
    n == isConnected[i].length
    isConnected[i][j] is 1 or 0.
    isConnected[i][i] == 1
    isConnected[i][j] == isConnected[j][i]
    */
    public class NumberOfProvinces
    {
        /*
        Complexity:
            O(V*E^2) time complexity
            O(V) space complexity
        */
        public int FindCircleNum_QuickFind(int[][] isConnected)
        {
            int n = isConnected.Length;
            var roots = new int[n];
            for (int i = 0; i < n; i++)
            {
                roots[i] = i;
            }

            void Union(int a, int b)
            {
                if (roots[a] != roots[b])
                {
                    int oldRoot = roots[a];
                    int newRoot = roots[b];
                    for (int i = 0; i < n; i++)
                    {
                        if (roots[i] == oldRoot)
                        {
                            roots[i] = newRoot;
                        }
                    }
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (isConnected[i][j] == 1)
                    {
                        Union(i, j);
                    }
                }
            }

            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (roots[i] == i)
                {
                    count++;
                }
            }
            return count;
        }

        /*
        Complexity:
            O(V*E) time complexity
            O(V) space complexity
        */        
        public int FindCircleNum_QuickUnion(int[][] isConnected)
        {
            int n = isConnected.Length;
            var roots = new int[n];
            for (int i = 0; i < n; i++)
            {
                roots[i] = i;
            }

            int Find(int a)
            {
                if (a == roots[a]) return a;

                roots[a] = Find(roots[a]);
                return roots[a];
            }

            void Union(int a, int b)
            {
                int rootA = Find(a);
                int rootB = Find(b);
                if (rootA != rootB)
                {
                    roots[rootA] = rootB;
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (isConnected[i][j] == 1)
                    {
                        Union(i, j);
                    }
                }
            }

            int count = 0;
            for (int i = 0; i < n; i++)
            {
                if (roots[i] == i)
                {
                    count++;
                }
            }
            return count;
        }

        /*
        Complexity:
            O(E*logV) time complexity
            O(V) space complexity
        */        
        public int FindCircleNum_QuickUnionByRankWithPathCompaction(int[][] isConnected)
        {
            int n = isConnected.Length;
            var roots = new int[n];
            var rank = new int[n];
            int count = n;
            for (int i = 0; i < n; i++)
            {
                roots[i] = i;
                rank[i] = 1;
            }

            int Find(int a)
            {
                if (a == roots[a]) return a;

                roots[a] = Find(roots[a]);
                return roots[a];
            }

            void Union(int a, int b)
            {
                int rootA = Find(a);
                int rootB = Find(b);
                if (rootA == rootB) return;
                
                if (rank[rootA] > rank[rootB]) {
                    roots[rootB] = rootA;
                }
                else if (rank[rootA] < rank[rootB]) {
                    roots[rootA] = rootB;
                }
                else
                {
                    roots[rootA] = rootB;
                    rank[rootB] += 1;
                }
                count--;
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (isConnected[i][j] == 1)
                    {
                        Union(i, j);
                    }
                }
            }

            return count;
        }
    }
}