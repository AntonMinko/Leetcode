using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    301. Remove Invalid Parentheses

    Link: https://leetcode.com/problems/remove-invalid-parentheses/
    
    Difficulty: Hard

Given a string s that contains parentheses and letters, remove the minimum number of invalid parentheses to make the input string valid.
Return all the possible results. You may return the answer in any order.

Example 1:
Input: s = "()())()"
Output: ["(())()","()()()"]

Example 2:
Input: s = "(a)())()"
Output: ["(a())()","(a)()()"]

Example 3:
Input: s = ")("
Output: [""]

Constraints:
    1 <= s.length <= 25
    s consists of lowercase English letters and parentheses '(' and ')'.
    There will be at most 20 parentheses in s.
    
    Complexity:
        O(2^N) time complexity
        O(N) space complexity
    */
    public class FixParenthesis
    {
        public IList<string> RemoveInvalidParentheses(string s)
        {
            var result = new HashSet<string>();

            void TryConstruct(LinkedList<char> builder, Stack<char> stack, int pos, int leftRemove, int rightRemove)
            {
                if (pos == s.Length)
                {
                    if (!stack.Any()) result.Add(new string(builder.ToArray()));
                    return;
                }

                char cur = s[pos];
                pos++;
                switch(cur)
                {
                    case '(':
                        if (leftRemove > 0)
                        {
                            TryConstruct(builder, stack, pos, leftRemove-1, rightRemove);
                        }

                        builder.AddLast(cur);
                        stack.Push(cur);
                        TryConstruct(builder, stack, pos, leftRemove, rightRemove);
                        stack.Pop();
                        builder.RemoveLast();
                        break;
                    case ')':
                        if (rightRemove > 0)
                        {
                            TryConstruct(builder, stack, pos, leftRemove, rightRemove-1);
                        }

                        if (!stack.Any()) return;

                        builder.AddLast(cur);
                        stack.Pop();
                        TryConstruct(builder, stack, pos, leftRemove, rightRemove);
                        stack.Push('(');
                        builder.RemoveLast();
                        break;
                    default:
                        builder.AddLast(cur);
                        TryConstruct(builder, stack, pos, leftRemove, rightRemove);
                        builder.RemoveLast();
                        break;
                }
            }
            
            int left = s.Count(ch => ch == '(');
            int right = s.Count(ch => ch == ')');

            int leftRemoveCount = left > right ? left - right : 0;
            int rightRemoveCount = right > left ? right - left : 0;

            while (leftRemoveCount + rightRemoveCount <= left + right)
            {
                TryConstruct(new LinkedList<char>(), new Stack<char>(), 0, leftRemoveCount, rightRemoveCount);

                if (result.Any())
                {
                    return result.ToList();
                }

                leftRemoveCount++;
                rightRemoveCount++;
            }

            return result.ToList();
        }
    }
}