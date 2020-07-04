using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    208. Implement Trie (Prefix Tree)

    Link: https://leetcode.com/problems/implement-trie-prefix-tree/
    
    Difficulty: Medium

    Implement a trie with insert, search, and startsWith methods.

    Example:
    Trie trie = new Trie();
    trie.insert("apple");
    trie.search("apple");   // returns true
    trie.search("app");     // returns false
    trie.startsWith("app"); // returns true
    trie.insert("app");   
    trie.search("app");     // returns true

    Note:
        You may assume that all inputs are consist of lowercase letters a-z.
        All inputs are guaranteed to be non-empty strings.
    */
    public class Trie
    {
        private class TrieNode
        {
            private const int ArrayLength = 26;
            //public IDictionary<char, TrieNode> Children { get; }
            public TrieNode[] Children {get;}

            public bool IsEndOfWord { get; set; }

            public TrieNode()
            {
                Children = new TrieNode[ArrayLength];
            }
        }

        private readonly TrieNode _root = new TrieNode();

        /** Initialize your data structure here. */
        public Trie()
        {

        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            var cur = _root;
            foreach(char c in word)
            {
                int ind = c - 'a';
                if (cur.Children[ind] == null)
                {
                    cur.Children[ind] = new TrieNode();
                }
                cur = cur.Children[ind];
            }
            cur.IsEndOfWord = true;
        }

        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            return StartsWithLastNode(word)?.IsEndOfWord ?? false;
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            return StartsWithLastNode(prefix) != null;
        }

        private TrieNode StartsWithLastNode(string prefix)
        {
            var cur = _root;
            foreach(char c in prefix)
            {
                int ind = c - 'a';
                if (cur.Children[ind] == null)
                {
                    return null;
                }
                cur = cur.Children[ind];
            }
            return cur;
        }
    }

}