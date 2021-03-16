using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    536. Construct Binary Tree from String

    Link: https://leetcode.com/problems/construct-binary-tree-from-string/
    
    Difficulty: Medium

You need to construct a binary tree from a string consisting of parenthesis and integers.
The whole input represents a binary tree. It contains an integer followed by zero, one or two pairs of parenthesis. 
The integer represents the root's value and a pair of parenthesis contains a child binary tree with the same structure.
You always start to construct the left child node of the parent first if it exists.

Example 1:
Input: s = "4(2(3)(1))(6(5))"
Output: [4,2,6,3,1,5]

Example 2:
Input: s = "4(2(3)(1))(6(5)(7))"
Output: [4,2,6,3,1,5,7]

Example 3:
Input: s = "-4(2(3)(1))(6(5)(7))"
Output: [-4,2,6,3,1,5,7]

Constraints:
    0 <= s.length <= 3 * 104
    s consists of digits, '(', ')', and '-' only.
    
    Complexity:
        O(n) time complexity
        O(n) space complexity
    */
    public class BinaryTreeFromString
    {
        private record Token(bool IsOpenBracket = false, bool IsCloseBracket = false, bool IsNumber = false, int Number = 0);

        public TreeNode Str2tree(string s)
        {
            var tokens = GetTokens(s);
            if (!tokens.Any())
            {
                return null;
            }

            TreeNode ProcessNode()
            {
                Token GetNextToken()
                {
                    return tokens.Any()
                        ? tokens.Dequeue()
                        : new Token();
                }

                var token = GetNextToken();
                if (!token.IsNumber)
                {
                    return null;
                }

                var node = new TreeNode(token.Number);

                token = GetNextToken();
                if (token.IsCloseBracket)
                {
                    return node;
                }
                else
                {
                    node.left = ProcessNode();
                }

                token = GetNextToken();
                if (token.IsCloseBracket)
                {
                    return node;
                }
                else
                {
                    node.right = ProcessNode();
                }

                token = GetNextToken();

                return node;
            }

            var root = ProcessNode();

            return root;
        }

        private Queue<Token> GetTokens(string s)
        {
            var list = new Queue<Token>();

            int numStart = -1;
            bool isNumber = false;
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (isNumber)
                {
                    if (c == '(' || c == ')')
                    {
                        string numberStr = s.Substring(numStart, i - numStart);
                        list.Enqueue(new Token(IsNumber: true, Number: int.Parse(numberStr)));
                        isNumber = false;
                    }
                    else
                    {
                        continue;
                    }
                }

                switch (c)
                {
                    case '(':
                        list.Enqueue(new Token(IsOpenBracket: true));
                        break;
                    case ')':
                        list.Enqueue(new Token(IsCloseBracket: true));
                        break;
                    default:
                        isNumber = true;
                        numStart = i;
                        break;
                }
            }

            if (isNumber)
            {
                string numberStr = s.Substring(numStart);
                list.Enqueue(new Token(IsNumber: true, Number: int.Parse(numberStr)));
            }

            return list;
        }
    }

}