using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    210. Course Schedule II

    Link: https://leetcode.com/problems/course-schedule/
    
    Difficulty: Medium

There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1. 
You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must take course bi first if you want to take course ai.
For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.
Return the ordering of courses you should take to finish all courses. If there are many valid answers, return any of them. 
If it is impossible to finish all courses, return an empty array.

Example 1:
Input: numCourses = 2, prerequisites = [[1,0]]
Output: [0,1]
Explanation: There are a total of 2 courses to take. To take course 1 you should have finished course 0. So the correct course order is [0,1].

Example 2:
Input: numCourses = 4, prerequisites = [[1,0],[2,0],[3,1],[3,2]]
Output: [0,2,1,3]
Explanation: There are a total of 4 courses to take. To take course 3 you should have finished both courses 1 and 2. 
Both courses 1 and 2 should be taken after you finished course 0.
So one correct course order is [0,1,2,3]. Another correct ordering is [0,2,1,3].

Example 3:
Input: numCourses = 1, prerequisites = []
Output: [0]

Constraints:
    1 <= numCourses <= 2000
    0 <= prerequisites.length <= numCourses * (numCourses - 1)
    prerequisites[i].length == 2
    0 <= ai, bi < numCourses
    ai != bi
    All the pairs [ai, bi] are distinct.

    Complexity:
        O() time complexity
        O() space complexity
    */
    public class CourseScheduleII
    {
        public int[] FindOrder(int numCourses, int[][] prerequisites)
        {
            // Build a graph, root vertices have no prerequisites (inverse direction)
            var adjList = new List<int>[numCourses];
            for (int i = 0; i < adjList.Length; i++)
            {
                adjList[i] = new List<int>();
            }

            foreach (var prereq in prerequisites)
            {
                adjList[prereq[1]].Add(prereq[0]);
            }

            var visited = new bool[numCourses];
            var path = new HashSet<int>();
            var orderedCourses = new Stack<int>();
            bool hasCycle = false;

            void dfs(int v)
            {
                if (hasCycle) return;
                if (path.Contains(v))
                {
                    hasCycle = true;
                    return;
                }

                path.Add(v);

                adjList[v].ForEach(dfs);

                if (!visited[v])
                {
                    // Leaf node is the course that will be taken last.
                    // Due to stack, we don't care where we start, 
                    // we can start from the middle of the tree.
                    orderedCourses.Push(v);
                    visited[v] = true;
                }
                path.Remove(v);
            }

            for (int i = 0; i < numCourses; i++)
            {
                if (!visited[i])
                {
                    dfs(i);
                }
            }

            return !hasCycle && orderedCourses.Count == numCourses
                ? orderedCourses.ToArray()
                : new int[0];
        }
    }
}
