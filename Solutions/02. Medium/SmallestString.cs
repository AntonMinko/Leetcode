using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    1202. Smallest String With Swaps

    Link: https://leetcode.com/problems/smallest-string-with-swaps/
    
    Difficulty: Medium

You are given a string s, and an array of pairs of indices in the string pairs where 
pairs[i] = [a, b] indicates 2 indices(0-indexed) of the string.
You can swap the characters at any pair of indices in the given pairs any number of times.
Return the lexicographically smallest string that s can be changed to after using the swaps.

Example 1:
Input: s = "dcab", pairs = [[0,3],[1,2]]
Output: "bacd"
Explaination: 
Swap s[0] and s[3], s = "bcad"
Swap s[1] and s[2], s = "bacd"

Example 2:
Input: s = "dcab", pairs = [[0,3],[1,2],[0,2]]
Output: "abcd"
Explaination: 
Swap s[0] and s[3], s = "bcad"
Swap s[0] and s[2], s = "acbd"
Swap s[1] and s[2], s = "abcd"

Example 3:
Input: s = "cba", pairs = [[0,1],[1,2]]
Output: "abc"
Explaination: 
Swap s[0] and s[1], s = "bca"
Swap s[1] and s[2], s = "bac"
Swap s[0] and s[1], s = "abc"

Constraints:
    1 <= s.length <= 10^5
    0 <= pairs.length <= 10^5
    0 <= pairs[i][0], pairs[i][1] < s.length
    s only contains lower case English letters.
    
    Complexity:
        O(n * log(k)) time complexity where k is the max elements in one group
        O(n) space complexity
    */
    public class SmallestString
    {
        public string SmallestStringWithSwaps(string s, IList<IList<int>> pairs)
        {
            var roots = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                roots[i] = i;
            }

            int Find(int pos)
            {
                int i = pos;
                while (i != roots[i])
                {
                    i = roots[i];
                }
                roots[pos] = i;
                return i;
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

            foreach (var pair in pairs)
            {
                Union(pair[0], pair[1]);
            }

            var queues = new Dictionary<int, PriorityQueue<char, char>>();
            for (int i = 0; i < roots.Length; i++)
            {
                int root = Find(i);
                if (!queues.ContainsKey(root))
                {
                    queues[root] = new PriorityQueue<char, char>();
                }
                queues[root].Enqueue(s[i], s[i]);
            }

            var sb = new StringBuilder(s.Length);
            for (int i = 0; i < roots.Length; i++)
            {
                sb.Append(queues[roots[i]].Dequeue());
            }

            return sb.ToString();
        }
    }
}