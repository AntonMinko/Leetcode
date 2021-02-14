using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    23. Merge k Sorted Lists

    Link: https://leetcode.com/problems/merge-k-sorted-lists/
    
    Difficulty: Hard

You are given an array of k linked-lists lists, each linked-list is sorted in ascending order.
Merge all the linked-lists into one sorted linked-list and return it.

Example 1:
Input: lists = [[1,4,5],[1,3,4],[2,6]]
Output: [1,1,2,3,4,4,5,6]
Explanation: The linked-lists are:
[
  1->4->5,
  1->3->4,
  2->6
]
merging them into one sorted list:
1->1->2->3->4->4->5->6

Example 2:
Input: lists = []
Output: []

Example 3:
Input: lists = [[]]
Output: [] 

Constraints:
    k == lists.length
    0 <= k <= 10^4
    0 <= lists[i].length <= 500
    -10^4 <= lists[i][j] <= 10^4
    lists[i] is sorted in ascending order.
    The sum of lists[i].length won't exceed 10^4.

    */
    public class MergeKSortedLists
    {
        public ListNode MergeKLists(ListNode[] lists)
        {
            var sorted = new SortedDictionary<int, int>();
            foreach (var list in lists)
            {
                var cur = list;
                while (cur != null)
                {
                    if (sorted.ContainsKey(cur.val))
                    {
                        sorted[cur.val] += 1;
                    }
                    else
                    {
                        sorted[cur.val] = 1;
                    }
                    cur = cur.next;
                }
            }
            ListNode head = null;
            ListNode tail = null;
            foreach (var kvp in sorted)
            {
                int val = kvp.Key;
                int duplicates = kvp.Value;
                for (int i = 0; i < duplicates; i++)
                {
                    ListNode node = new ListNode(val);
                    if (head == null)
                    {
                        head = node;
                        tail = node;
                    }
                    else
                    {
                        tail.next = node;
                        tail = tail.next;
                    }
                }
            }

            return head;
        }
    }
}