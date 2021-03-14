using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    445. Add Two Numbers II

    Link: https://leetcode.com/problems/add-two-numbers-ii/
    
    Difficulty: Medium

You are given two non-empty linked lists representing two non-negative integers. 
The most significant digit comes first and each of their nodes contain a single digit. 
Add the two numbers and return it as a linked list.

You may assume the two numbers do not contain any leading zero, except the number 0 itself.

Follow up:
What if you cannot modify the input lists? In other words, reversing the lists is not allowed.

Example:

Input: (7 -> 2 -> 4 -> 3) + (5 -> 6 -> 4)
Output: 7 -> 8 -> 0 -> 7

    
    */

    public class AddTwoNumbers2
    {
        public ListNode AddTwoNumbersWithStacks(ListNode l1, ListNode l2)
        {
            Stack<int> num1Stack = ConvertToStack(l1);
            Stack<int> num2Stack = ConvertToStack(l2);

            return SumStacks(num1Stack, num2Stack);
        }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            ListNode l1Inv = InvertList(l1);
            ListNode l2Inv = InvertList(l2);
            // Stack<int> num1Stack = ConvertToStack(l1);
            // Stack<int> num2Stack = ConvertToStack(l2);

            return SumLists(l1Inv, l2Inv, null, 0);
        }

        private Stack<int> ConvertToStack(ListNode l1)
        {
            var stack = new Stack<int>();
            while (l1 != null)
            {
                stack.Push(l1.val);
                l1 = l1.next;
            }

            return stack;
        }

        private ListNode SumStacks(Stack<int> num1Stack, Stack<int> num2Stack)
        {
            ListNode cur = null, prev = null;
            int digit = 0, overflow = 0;
            while (num1Stack.Count > 0 || num2Stack.Count > 0)
            {
                int num1 = num1Stack.Count > 0 ? num1Stack.Pop() : 0;
                int num2 = num2Stack.Count > 0 ? num2Stack.Pop() : 0;
                digit = num1 + num2 + overflow;
                overflow = digit / 10;
                digit = digit % 10;

                cur = new ListNode(digit);
                cur.next = prev;
                prev = cur;
            }
            if (overflow > 0)
            {
                cur = new ListNode(overflow);
                cur.next = prev;
            }
            return cur;
        }

        private ListNode SumLists(ListNode node1, ListNode node2, ListNode next, int overflow)
        {
            int sum = overflow;
            sum += node1 != null ? node1.val : 0;
            sum += node2 != null ? node2.val : 0;
            int digit = sum % 10;
            overflow = sum >= 10 ? 1 : 0;

            ListNode cur = new ListNode(digit);
            cur.next = next;
            node1 = node1?.next;
            node2 = node2 != null ? node2.next : null;
            if (node1 != null || node2 != null)
            {
                return SumLists(node1, node2, cur, overflow);
            }
            if (overflow != 0)
            {
                ListNode head = new ListNode(overflow);
                head.next = cur;
                return head;
            }
            return cur;
        }

        private ListNode InvertList(ListNode node)
        {
            if (node == null || node.next == null) return node;

            ListNode head = node;
            ListNode next = head.next;
            head.next = null;
            while(next != null)
            {
                ListNode nextNext = next.next;
                next.next = head;
                head = next;
                next = nextNext;
            }
            return head;
        }
    }

}