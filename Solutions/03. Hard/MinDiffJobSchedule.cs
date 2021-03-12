using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    1335. Minimum Difficulty of a Job Schedule

    Link: https://leetcode.com/problems/minimum-difficulty-of-a-job-schedule/
    
    Difficulty: Hard

    Dynamic programming

You want to schedule a list of jobs in d days. Jobs are dependent (i.e To work on the i-th job, 
you have to finish all the jobs j where 0 <= j < i).
You have to finish at least one task every day. The difficulty of a job schedule is the sum of difficulties of 
each day of the d days. The difficulty of a day is the maximum difficulty of a job done in that day.
Given an array of integers jobDifficulty and an integer d. The difficulty of the i-th job is jobDifficulty[i].
Return the minimum difficulty of a job schedule. If you cannot find a schedule for the jobs return -1.

Example 1:
Input: jobDifficulty = [6,5,4,3,2,1], d = 2
Output: 7
Explanation: First day you can finish the first 5 jobs, total difficulty = 6.
Second day you can finish the last job, total difficulty = 1.
The difficulty of the schedule = 6 + 1 = 7 

Example 2:
Input: jobDifficulty = [9,9,9], d = 4
Output: -1
Explanation: If you finish a job per day you will still have a free day. you cannot find a schedule for the given jobs.

Example 3:
Input: jobDifficulty = [1,1,1], d = 3
Output: 3
Explanation: The schedule is one job per day. total difficulty will be 3.

Example 4:
Input: jobDifficulty = [7,1,7,1,7,1], d = 3
Output: 15

Example 5:
Input: jobDifficulty = [11,111,22,222,33,333,44,444], d = 6
Output: 843

Constraints:
    1 <= jobDifficulty.length <= 300
    0 <= jobDifficulty[i] <= 1000
    1 <= d <= 10
    
    Complexity:
        O(N*M) time complexity
        O(N*M) space complexity
    */
    public class MinDiffJobSchedule
    {
        public int MinDifficulty(int[] jobDifficulty, int days)
        {
            Dictionary<string, int> memo = new Dictionary<string, int>();
            string GetKey(int curJob, int curDay) => $"{curJob}_{curDay}";

            int J = jobDifficulty.Length;
            if (J < days) return -1;

            int MinDifficulty(int curJob, int curDay)
            {
                if (curJob == J - 1)
                {
                    return jobDifficulty[curJob];
                }
                string key = GetKey(curJob, curDay);
                if (memo.ContainsKey(key)) return memo[key];

                int minDiff = int.MaxValue;
                int curDaySum = 0;
                for (int i = curJob; i < J - (days - curDay); i++)
                {
                    curDaySum = Math.Max(curDaySum, jobDifficulty[i]);
                    if (curDay < days)
                    {
                        int remainingDiff = MinDifficulty(i + 1, curDay + 1);
                        minDiff = Math.Min(minDiff, curDaySum + remainingDiff);
                    }
                    else
                    {
                        minDiff = curDaySum;
                    }
                }

                memo[key] = minDiff;
                return minDiff;
            }

            return MinDifficulty(0, 1);
        }

        public int MinDifficulty2_HasBugs(int[] jobDifficulty, int days)
        {
            var table = new (int, int)[days + 1, jobDifficulty.Length + 1];
            for (int i = 0; i <= days; i++)
            {
                for (int j = 0; j <= jobDifficulty.Length; j++)
                {
                    table[i, j] = (1000000, 0);
                }
            }

            table[0, 0] = (0, 0);

            for (int d = 1; d <= days; d++)
            {
                for (int j = d; j <= jobDifficulty.Length - days + d; j++)
                {
                    int curJob = jobDifficulty[j - 1];
                    int dayDiff = Math.Max(table[d, j - 1].Item2, curJob);
                    int daySum1 = table[d - 1, j - 1].Item1 + curJob;
                    int daySum2 = table[d, j - 1].Item1 - table[d, j - 1].Item2 + dayDiff;
                    if (daySum1 < daySum2)
                    {
                        table[d, j] = (daySum1, curJob);
                    }
                    else
                    {
                        table[d, j] = (daySum2, dayDiff);
                    }

                }
            }
            int result = table[days, jobDifficulty.Length].Item1;
            return result < 1000000 ? result : -1;
        }
    }

}