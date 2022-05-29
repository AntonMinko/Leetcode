using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    32. Longest Valid Parentheses

    Link: https://leetcode.com/problems/longest-valid-parentheses/
    
    Difficulty: Hard

Given a string containing just the characters '(' and ')', find the length of the longest valid (well-formed) parentheses substring.

Example 1:
Input: s = "(()"
Output: 2
Explanation: The longest valid parentheses substring is "()".

Example 2:
Input: s = ")()())"
Output: 4
Explanation: The longest valid parentheses substring is "()()".

Example 3:
Input: s = ""
Output: 0

Constraints:
    0 <= s.length <= 3 * 104
    s[i] is '(', or ')'.
    
    Complexity:
        O(n) time complexity
        O(n) space complexity
    */
    public class LongestValidParentheses
    {
        public int Find(string s) {
            int n = s.Length;
            var stack = new Stack<int>();
            var used = new bool[n];
            
            for(int i=0; i<n; i++) {
                if (s[i] == '(') {
                    stack.Push(i);
                }
                else if (stack.Any()) {
                    used[i] = true;
                    used[stack.Pop()] = true;
                }
                // otherwise, just continue
            }
            
            int max = 0;
            int cur = 0;
            for(int i=0; i<n; i++) {
                if (used[i]) {
                    cur++;
                }
                else {
                    max = Math.Max(max, cur);
                    cur = 0;
                }
            }
            
            return Math.Max(max, cur);
        }
    }
}