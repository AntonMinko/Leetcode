using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    1136. Parallel Courses

    Link: https://leetcode.com/problems/parallel-courses/
    
    Difficulty: Medium

You are given an integer n which indicates that we have n courses, labeled from 1 to n. You are also given an array relations 
where relations[i] = [a, b], representing a prerequisite relationship between course a and course b: course a has to be studied before course b.
In one semester, you can study any number of courses as long as you have studied all the prerequisites for the course you are studying.
Return the minimum number of semesters needed to study all courses. If there is no way to study all the courses, return -1.

Example 1:
Input: n = 3, relations = [[1,3],[2,3]]
Output: 2
Explanation: In the first semester, courses 1 and 2 are studied. In the second semester, course 3 is studied.

Example 2:
Input: n = 3, relations = [[1,2],[2,3],[3,1]]
Output: -1
Explanation: No course can be studied because they depend on each other.

Constraints:
    1 <= n <= 5000
    1 <= relations.length <= 5000
    1 <= a, b <= n
    a != b
    All the pairs [a, b] are unique.
    
    Complexity:
        O(n*m) time complexity
        O() space complexity
    */
    public class ParallelCourses
    {
        public int MinimumSemesters(int n, int[][] relations)
        {
            var dependsOn = new Dictionary<int, HashSet<int>>();
            var dependents = new Dictionary<int, LinkedList<int>>();
            var studiedCourses = new bool[n + 1];

            foreach (var pair in relations)
            {
                int prereq = pair[0];
                int followUp = pair[1];
                if (!dependents.ContainsKey(prereq))
                {
                    dependents.Add(prereq, new LinkedList<int>());
                }
                dependents[prereq].AddLast(followUp);

                if (!dependsOn.ContainsKey(followUp))
                {
                    dependsOn.Add(followUp, new HashSet<int>());
                }
                dependsOn[followUp].Add(prereq);
            }

            int semesters = 0;
            var studiedThisSemester = new LinkedList<int>();
            while (true)
            {
                bool hasUnstudied = false;
                for (int i = 1; i <= n; i++)
                {
                    if (studiedCourses[i])
                    {
                        continue;
                    }

                    hasUnstudied = true;
                    if (!dependsOn.ContainsKey(i) || dependsOn[i].Count == 0)
                    {
                        studiedThisSemester.AddLast(i);
                    }
                }

                if (!hasUnstudied)
                {
                    return semesters;
                }

                semesters++;

                if (hasUnstudied && !studiedThisSemester.Any())
                {
                    return -1;
                }

                foreach(int i in studiedThisSemester)
                {
                    studiedCourses[i] = true;

                    if (dependents.ContainsKey(i))
                    {
                        foreach (int dep in dependents[i])
                        {
                            dependsOn[dep].Remove(i);
                        }
                        dependents.Remove(i);
                    }
                }
                studiedThisSemester.Clear();
            }
        }
    }

}