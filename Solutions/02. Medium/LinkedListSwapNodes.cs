using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    1721. Swapping Nodes in a Linked List

    Link: https://leetcode.com/problems/swapping-nodes-in-a-linked-list/
    
    Difficulty: Medium
You are given the head of a linked list, and an integer k.
Return the head of the linked list after swapping the values 
of the kth node from the beginning and the kth node from the end (the list is 1-indexed).

Example 1:
Input: head = [1,2,3,4,5], k = 2
Output: [1,4,3,2,5]

Example 2:
Input: head = [7,9,6,6,7,8,3,0,9,5], k = 5
Output: [7,9,6,6,8,7,3,0,9,5]

Example 3:
Input: head = [1], k = 1
Output: [1]

Example 4:
Input: head = [1,2], k = 1
Output: [2,1]

Example 5:
Input: head = [1,2,3], k = 2
Output: [1,2,3]

Constraints:
    The number of nodes in the list is n.
    1 <= k <= n <= 105
    0 <= Node.val <= 100
    
    Complexity:
        O() time complexity
        O() space complexity
    */
    public class LinkedListSwapNodes
    {
        public ListNode SwapNodes(ListNode head, int k)
        {
            // Single pass, O(n) extra memory
            var list = new List<ListNode>();
            ListNode cur = head;
            while (cur != null)
            {
                list.Add(cur);
                cur = cur.next;
            }

            int N = list.Count;
            int tmp = list[k - 1].val;
            list[k - 1].val = list[N - k].val;
            list[N - k].val = tmp;

            return head;
        }

        public ListNode SwapNodes2(ListNode head, int k)
        {
            // Single pass, O(1) memory complexity

            ListNode left = null;
            ListNode right = null;
            ListNode cur = head;
            int i = 1;
            while (cur != null)
            {
                if (i == k)
                {
                    left = cur;
                }
                if (i - k == 0)
                {
                    right = head;
                }
                else if (i - k > 0)
                {
                    right = right.next;
                }

                i++;
                cur = cur.next;
            }

            int tmp = left.val;
            left.val = right.val;
            right.val = tmp;

            return head;
        }
    }

}