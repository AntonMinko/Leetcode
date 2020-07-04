using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    155. Min Stack

    Link: https://leetcode.com/problems/min-stack/
    
    Difficulty: Easy

    Design a stack that supports push, pop, top, and retrieving the minimum element in constant time.

    push(x) -- Push element x onto stack.
    pop() -- Removes the element on top of the stack.
    top() -- Get the top element.
    getMin() -- Retrieve the minimum element in the stack.

 Example:

MinStack minStack = new MinStack();
minStack.push(-2);
minStack.push(0);
minStack.push(-3);
minStack.getMin();   --> Returns -3.
minStack.pop();
minStack.top();      --> Returns 0.
minStack.getMin();   --> Returns -2.

    */
    public class MinStack
    {
        private readonly LinkedList<int> _list = new LinkedList<int>();
        private int? _min = null;

        public MinStack()
        {
        }

        public void Push(int x)
        {
            if (_list.Count == 0)
            {
                _min = x;
            }
            else if (_min != null)
            {
                _min = Math.Min(_min.Value, x);
            }

            _list.AddLast(x);
        }

        public void Pop()
        {
            if (_list.Last != null)
            {
                if (_min == _list.Last.Value)
                {
                    _min = null;
                }

                _list.RemoveLast();
            }
        }

        public int Top()
        {
            return _list.Last != null ? _list.Last.Value : int.MinValue;
        }

        public int GetMin()
        {
            if (_min == null)
            {
                foreach (int x in _list)
                {
                    if (_min == null || _min.Value > x)
                    {
                        _min = x;
                    }
                }
            }
            return _min.Value;
        }
    }

}