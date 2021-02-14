using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions.Links
{
    /*
    138. Copy List with Random Pointer

    Link: https://leetcode.com/problems/copy-list-with-random-pointer/
    
    Difficulty: Medium

A linked list of length n is given such that each node contains an additional random pointer, which could point to any node in the list, or null.

Construct a deep copy of the list. The deep copy should consist of exactly n brand new nodes, where each new node has its value set to the value of 
its corresponding original node. Both the next and random pointer of the new nodes should point to new nodes in the copied list such that the pointers 
in the original list and copied list represent the same list state. None of the pointers in the new list should point to nodes in the original list.

For example, if there are two nodes X and Y in the original list, where X.random --> Y, then for the corresponding two nodes x and y in the copied list, x.random --> y.

Return the head of the copied linked list.

The linked list is represented in the input/output as a list of n nodes. Each node is represented as a pair of [val, random_index] where:
    val: an integer representing Node.val
    random_index: the index of the node (range from 0 to n-1) that the random pointer points to, or null if it does not point to any node.

Your code will only be given the head of the original linked list.

    */

    public class Node
    {
        public int val;
        public Node next;
        public Node random;

        public Node(int _val)
        {
            val = _val;
            next = null;
            random = null;
        }
    }
    
    public class DeepCopyWithRandomPointer
    {
        public Node CopyRandomList(Node head)
        {
            if (head == null) return null;

            var lookup = new Dictionary<Node, int>();
            var node = head;
            int ind = 0;
            while (node != null)
            {
                lookup[node] = ind;
                ind++;
                node = node.next;
            }

            var list = new List<Node>(lookup.Count);
            node = head;
            while (node != null)
            {
                list.Add(new Node(node.val) { random = node.random });
                node = node.next;
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (i < list.Count - 1)
                {
                    list[i].next = list[i + 1];
                }
                if (list[i].random != null)
                {
                    list[i].random = list[lookup[list[i].random]];
                }
            }

            return list[0];
        }
    }
}