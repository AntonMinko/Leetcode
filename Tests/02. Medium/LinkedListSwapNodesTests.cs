using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;
using System.Collections.Generic;

namespace Tests
{
    public class LinkedListSwapNodesTests : BaseTests
    {
        public LinkedListSwapNodesTests(ITestOutputHelper output) : base(output)
        {
        }

        [Theory]
        [InlineData(1, new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 1, 4, 3, 2, 5 })]
        [InlineData(2, new int[] { 1 }, 1, new int[] { 1 })]
        [InlineData(3, new int[] { 7, 9, 6, 6, 7, 8, 3, 0, 9, 5 }, 5, new int[] { 7, 9, 6, 6, 8, 7, 3, 0, 9, 5 })]
        [InlineData(4, new int[] { 1, 2 }, 1, new int[] { 2, 1 })]
        [InlineData(5, new int[] { 1, 2 }, 2, new int[] { 2, 1 })]
        [InlineData(6, new int[] { 1, 2, 3 }, 2, new int[] { 1, 2, 3 })]
        public void DataDrivenTest(int testId, int[] nums, int k, int[] expected)
        {

            var sut = new LinkedListSwapNodes();
            ListNode actual = MeasureAndExecute(testId, () => sut.SwapNodes(ToLinkedList(nums), k));

            int[] actualArray = ToArray(actual);
            actualArray.Should<int>().BeEquivalentTo(expected);
        }

        [Theory]
        [InlineData(1, new int[] { 1, 2, 3, 4, 5 }, 2, new int[] { 1, 4, 3, 2, 5 })]
        [InlineData(2, new int[] { 1 }, 1, new int[] { 1 })]
        [InlineData(3, new int[] { 7, 9, 6, 6, 7, 8, 3, 0, 9, 5 }, 5, new int[] { 7, 9, 6, 6, 8, 7, 3, 0, 9, 5 })]
        [InlineData(4, new int[] { 1, 2 }, 1, new int[] { 2, 1 })]
        [InlineData(5, new int[] { 1, 2 }, 2, new int[] { 2, 1 })]
        [InlineData(6, new int[] { 1, 2, 3 }, 2, new int[] { 1, 2, 3 })]
        public void DataDrivenTest2(int testId, int[] nums, int k, int[] expected)
        {

            var sut = new LinkedListSwapNodes();
            ListNode actual = MeasureAndExecute(testId, () => sut.SwapNodes2(ToLinkedList(nums), k));

            int[] actualArray = ToArray(actual);
            actualArray.Should<int>().BeEquivalentTo(expected);
        }

        private ListNode ToLinkedList(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return null;
            }

            var head = new ListNode(arr[0]);
            var prev = head;
            for (int i = 1; i < arr.Length; i++)
            {
                var cur = new ListNode(arr[i]);
                prev.next = cur;
                prev = cur;
            }

            return head;
        }

        private int[] ToArray(ListNode head)
        {
            var list = new List<int>();
            while (head != null)
            {
                list.Add(head.val);
                head = head.next;
            }

            return list.ToArray();
        }
    }
}