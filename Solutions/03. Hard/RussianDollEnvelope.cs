using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    354. Russian Doll Envelopes

    Link: https://leetcode.com/problems/russian-doll-envelopes/
    
    Difficulty: Hard

You are given a 2D array of integers envelopes where envelopes[i] = [wi, hi] represents the width and the height of an envelope.
One envelope can fit into another if and only if both the width and height of one envelope is greater than the width and height of the other envelope.
Return the maximum number of envelopes can you Russian doll (i.e., put one inside the other).
Note: You cannot rotate an envelope.

Example 1:
Input: envelopes = [[5,4],[6,4],[6,7],[2,3]]
Output: 3
Explanation: The maximum number of envelopes you can Russian doll is 3 ([2,3] => [5,4] => [6,7]).

Example 2:
Input: envelopes = [[1,1],[1,1],[1,1]]
Output: 1

Constraints:
    1 <= envelopes.length <= 5000
    envelopes[i].length == 2
    1 <= wi, hi <= 104

    Complexity:
        O() time complexity
        O() space complexity
    */
    public class RussianDollEnvelope
    {
        public string MaxEnvelopes(int[][] envelopes)
        {
            if (envelopes.Length == 1) return "";

            int N = envelopes.Length;
            var fitIn = new Dictionary<int, List<int>>(N);
            for (int i = 0; i < N; i++)
            {
                fitIn[i] = new List<int>();
                for (int j = 0; j < N; j++)
                {
                    if (envelopes[i][0] < envelopes[j][0] &&
                       envelopes[i][1] < envelopes[j][1])
                    {
                        fitIn[i].Add(j);
                    }
                }
            }
            var sb = new StringBuilder();
            for (int i = 0; i < N; i++)
            {
                fitIn[i] = fitIn[i].OrderByDescending(env => fitIn[env].Count).ToList();
            }
            //return sb.ToString();

            var usedEnvelopes = new LinkedList<int>();
            var usedEnvelopesSet = new HashSet<int>();
            int max = 0;

            void FindMax(int i, int curLength)
            {
                if (curLength > 100)
                {
                    max = 100;
                    return;
                }
                if (fitIn[i].Count == 0)
                {
                    max = curLength + 1;
                    //Console.WriteLine($"max={max}");
                    return;
                }

                if (curLength + fitIn[i].Count + 1 <= max) return;
                if (usedEnvelopesSet.Contains(i)) return;

                while (usedEnvelopes.Count > curLength)
                {
                    usedEnvelopesSet.Remove(usedEnvelopes.Last.Value);
                    usedEnvelopes.RemoveLast();
                }

                usedEnvelopes.AddLast(i);
                usedEnvelopesSet.Add(i);

                for (int j = 0; j < fitIn[i].Count; j++)
                //foreach (var j in fitIn[i].Where(j => curLength + fitIn[i].Count >= max).OrderByDescending(j => fitIn[j].Count))
                {
                    //Console.WriteLine($"i={i}, j={j}, fitIn[i].Count={fitIn[i].Count}");
                    FindMax(j, curLength + 1);
                }

            }
            //for(int i=0; i<N; i++)
            int r = 0;
            foreach (var kvp in fitIn.OrderByDescending(kvp => kvp.Value.Count))
            {
                r++;
                if (r > 1) return sb.ToString();
                sb.AppendLine($"i={kvp.Key}, count={kvp.Value.Count}");
                FindMax(kvp.Key, 0);
            }

            return max.ToString();
        }
    }

}