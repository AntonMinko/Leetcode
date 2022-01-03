using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    269. Alien Dictionary

    Link: https://leetcode.com/problems/alien-dictionary/
    
    Difficulty: Hard

There is a new alien language that uses the English alphabet. However, the order among the letters is unknown to you.
You are given a list of strings words from the alien language's dictionary, where the strings in words are sorted lexicographically by the rules of this new language.
Return a string of the unique letters in the new alien language sorted in lexicographically increasing order by the new language's rules. 
If there is no solution, return "". If there are multiple solutions, return any of them.
A string s is lexicographically smaller than a string t if at the first letter where they differ, the letter in s comes before the letter in t in the alien language. 
If the first min(s.length, t.length) letters are the same, then s is smaller if and only if s.length < t.length.

Example 1:
Input: words = ["wrt","wrf","er","ett","rftt"]
Output: "wertf"

Example 2:
Input: words = ["z","x"]
Output: "zx"

Example 3:
Input: words = ["z","x","z"]
Output: ""
Explanation: The order is invalid, so return "".

Constraints:
    1 <= words.length <= 100
    1 <= words[i].length <= 100
    words[i] consists of only lowercase English letters.
    
    Complexity:
        O() time complexity
        O() space complexity
    */
    public class AlienDictionary
    {
        private class Node
        {
            public char Letter { get; }
            public List<Node> Children { get; } = new List<Node>();

            public Node(char letter)
            {
                Letter = letter;
            }

            public int FindIndex(char ch)
            {
                return Children.FindIndex(n => n.Letter == ch);
            }
        }

        private Node BuildTree(string[] words)
        {
            var root = new Node('_');

            void ProcessLetter(Node parent, string word, int pos)
            {
                if (word.Length == pos)
                {
                    if (parent.Children.Any())
                    {
                        // ensure we didn't encounter a longer word before
                        throw new Exception("Wrong order");
                    }

                    return;
                }
                char letter = word[pos];
                int index = parent.FindIndex(letter);
                if (index >= 0 && index < parent.Children.Count - 1)
                {
                    // current letter is out of order
                    throw new Exception("Wrong order");
                }

                if (index == -1)
                {
                    parent.Children.Add(new Node(letter));
                }

                ProcessLetter(parent.Children.Last(), word, ++pos);
            }

            foreach (string word in words)
            {
                ProcessLetter(root, word, 0);
            }

            return root;
        }

        public string AlienOrder(string[] words)
        {
            Node root;
            try
            {
                root = BuildTree(words);
            }
            catch (Exception)
            {
                return "";
            }

            var indegrees = new Dictionary<char, int>();
            var adjacencyList = new Dictionary<char, HashSet<char>>();
            var encounteredList = new LinkedList<char>();

            void InitNode(Node node)
            {
                void InitChar(Node n)
                {
                    if (n == null) return;
                    if (!indegrees.ContainsKey(n.Letter))
                    {
                        indegrees.Add(n.Letter, 0);
                        adjacencyList.Add(n.Letter, new HashSet<char>());
                        encounteredList.AddLast(n.Letter);
                    }
                }

                for (int i = 0; i < node.Children.Count; i++)
                {
                    var current = node.Children[i];
                    InitChar(current);
                    var dependent = i < node.Children.Count - 1 ? node.Children[i + 1] : null;
                    InitChar(dependent);
                    if (dependent != null)
                    {
                        if (adjacencyList[current.Letter].Add(dependent.Letter))
                        {
                            indegrees[dependent.Letter]++;
                        }
                    }

                    InitNode(current);
                }
            }

            InitNode(root);

            var queue = new Queue<char>();
            foreach (char ch in encounteredList)
            {
                if (indegrees[ch] == 0)
                {
                    queue.Enqueue(ch);
                }
            }

            var result = new List<char>();
            while (queue.Count > 0)
            {
                char ch = queue.Dequeue();
                result.Add(ch);

                foreach (char dependency in adjacencyList[ch])
                {
                    if (result.Contains(dependency)) continue;

                    indegrees[dependency]--;
                    if (indegrees[dependency] == 0)
                    {
                        queue.Enqueue(dependency);
                    }
                }
            }

            return indegrees.All(kvp => kvp.Value == 0) ? new string(result.ToArray()) : String.Empty;
        }
    }
}