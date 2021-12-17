using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    207. Course Schedule

    Link: https://leetcode.com/problems/course-schedule/
    
    Difficulty: Medium

    There are a total of numCourses courses you have to take, labeled from 0 to numCourses - 1.
    You are given an array prerequisites where prerequisites[i] = [ai, bi] indicates that you must
    take course bi first if you want to take course ai.

    For example, the pair [0, 1], indicates that to take course 0 you have to first take course 1.

    Return true if you can finish all courses. Otherwise, return false.

    Example 1:
    Input: numCourses = 2, prerequisites = [[1,0]]
    Output: true
    Explanation: There are a total of 2 courses to take. 
    To take course 1 you should have finished course 0. So it is possible.

    Example 2:
    Input: numCourses = 2, prerequisites = [[1,0],[0,1]]
    Output: false
    Explanation: There are a total of 2 courses to take. 
    To take course 1 you should have finished course 0, and to take course 0 you should also have finished course 1. So it is impossible.

    Constraints:

        1 <= numCourses <= 105
        0 <= prerequisites.length <= 5000
        prerequisites[i].length == 2
        0 <= ai, bi < numCourses
        All the pairs prerequisites[i] are unique.

    Complexity:
        O() time complexity
        O() space complexity
    */
    public class CourseSchedule
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {
            // invert edges
            foreach(var prereq in prerequisites)
            {
                int to = prereq[0];
                int from = prereq[1];
                prereq[0] = from;
                prereq[1] = to;
            }
            
            var graph = new Graph(numCourses, prerequisites);
            return graph.ContainsCycle();
        }
    }
}