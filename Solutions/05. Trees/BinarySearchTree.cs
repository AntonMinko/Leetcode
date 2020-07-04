using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Solutions
{
    public class BinarySearchTree
    {
        private Node _root;
        public BinarySearchTree()
        {
        }

        public void Insert(int value)
        {
            if (_root == null)
            {
                _root = new Node(value);
                return;
            }

            Node current = _root;
            while (current != null)
            {
                switch (current.Value)
                {
                    case int curValue when value < curValue:
                        if (current.Left == null)
                        {
                            current.Left = new Node(value);
                            return;
                        }
                        current = current.Left;
                        break;
                    case int curValue when value > curValue:
                        if (current.Right == null)
                        {
                            current.Right = new Node(value);
                            return;
                        }
                        current = current.Right;
                        break;
                    default:
                        //There is already node with provided value
                        return;
                }
            }
        }

        public Node Lookup(int value)
        {
            if (_root == null) return null;
            Node current = _root;
            while (current != null)
            {
                switch (current.Value)
                {
                    case int curValue when value < curValue:
                        current = current.Left;
                        break;
                    case int curValue when value > curValue:
                        current = current.Right;
                        break;
                    default:
                        return current;
                }
            }
            return null;
        }

        public void Remove(int value)
        {
            Node node = _root;
            Node prev = null;
            while (true)
            {
                if (node == null) return;
                switch (node.Value)
                {
                    case int curValue when value < curValue:
                        prev = node;
                        node = node.Left;
                        break;
                    case int curValue when value > curValue:
                        prev = node;
                        node = node.Right;
                        break;
                    default:
                        // found node to delete
                        if (node.Left == null && node.Right == null)
                        {
                            if (prev == null) _root = null;
                            if (prev.Left == node) prev.Left = null;
                            if (prev.Right == node) prev.Right = null;
                        }
                        else if (node.Left == null)
                        {
                            if (prev == null) _root = node.Right;
                            if (prev.Left == node)
                            {
                                prev.Left = node.Right;
                            }
                            else
                            {
                                prev.Right = node.Right;
                            }
                        }
                        else if (node.Right == null)
                        {
                            if (prev == null) _root = node.Right;
                            if (prev.Left == node)
                            {
                                prev.Left = node.Left;
                            }
                            else
                            {
                                prev.Right = node.Left;
                            }
                        }
                        else
                        {
                            // traverse the right subtree to find the leftmost node
                            Node replacement = node.Right;
                            Node prevReplacement = null;
                            while(replacement.Left != null)
                            {
                                prevReplacement = replacement;
                                replacement = replacement.Left;
                            }
                            if (prevReplacement != null) prevReplacement.Left = replacement.Right;
                            if (prev == null)
                            {
                                _root = replacement;
                            }
                            else if (prev.Left == node)
                            {
                                prev.Left = replacement;
                            }
                            else
                            {
                                prev.Right = replacement;
                            }
                            replacement.Right = replacement == node.Right ? null : node.Right;
                            replacement.Left = node.Left;
                        }
                        return;
                }
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            var nodes = new List<Node>();
            nodes.Add(_root);
            while (nodes.Any(n => n != null))
            {
                var children = new List<Node>();
                for (int i = 0; i < nodes.Count; i++)
                {
                    Node node = nodes[i];
                    sb.Append(node != null ? $"{node.Value,8}" : "    null");
                    Node left = node?.Left;
                    Node right = node?.Right;
                    children.Add(left);
                    children.Add(right);
                }
                sb.AppendLine();
                nodes = children;
            }
            return sb.ToString();
        }
    }
}