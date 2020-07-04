using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Solutions
{
    /*
    1046. Last Stone Weight

    Link: https://leetcode.com/problems/last-stone-weight/
    
    Difficulty: Easy

    We have a collection of stones, each stone has a positive integer weight.

Each turn, we choose the two heaviest stones and smash them together.  Suppose the stones have weights x and y with x <= y.  The result of this smash is:

    If x == y, both stones are totally destroyed;
    If x != y, the stone of weight x is totally destroyed, and the stone of weight y has new weight y-x.

At the end, there is at most 1 stone left.  Return the weight of this stone (or 0 if there are no stones left.)

    */
    public class LastStoneWeightProblem
    {
        private class SortedIntList
        {
            private readonly LinkedList<int> _list;
            public SortedIntList(int[] array)
            {
                Array.Sort(array);
                _list = new LinkedList<int>(array);
            }

            public void Insert(int i)
            {
                if (_list.Count == 0 || _list.First.Value >= i)
                {
                    _list.AddFirst(i);
                    return;
                }

                var node = _list.First;
                while (node.Next != null && node.Next.Value < i)
                {
                    node = node.Next;
                }

                _list.AddAfter(node, i);
            }

            public int PopMax()
            {
                int result = _list.Last.Value;
                _list.RemoveLast();

                return result;
            }

            public int Count => _list.Count;
        }
        public int LastStoneWeight(int[] stones)
        {
            SortedIntList sortedList = new SortedIntList(stones);
            while (sortedList.Count > 1)
            {
                int stone1 = sortedList.PopMax();
                int stone2 = sortedList.PopMax();
                int diff = Math.Abs(stone1 - stone2);
                if (diff != 0)
                {
                    sortedList.Insert(diff);
                }
            }

            if (sortedList.Count == 1) return sortedList.PopMax();
            return 0;
        }
    }

}