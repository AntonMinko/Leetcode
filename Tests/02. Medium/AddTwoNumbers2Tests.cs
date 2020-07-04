using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;
using System;

namespace Tests
{
    public class AddTwoNumbers2Tests
    {
        private readonly ITestOutputHelper output;

        public AddTwoNumbers2Tests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(new int[] { 0 }, new int[] { 0 }, new int[] { 0 })]
        [InlineData(new int[] { 5 }, new int[] { 5 }, new int[] { 1,0 })]
        [InlineData(new int[] { 0 }, new int[] { 5,2 }, new int[] { 5,2 })]
        [InlineData(new int[] { 7,2,4,3 }, new int[] { 5,6,4 }, new int[] { 7,8,0,7 })]
        public void DataDrivenTest(int[] num1, int[] num2, int[] expected)
        {
            ListNode l1 = ConvertToLinkedList(num1);
            ListNode l2 = ConvertToLinkedList(num2);
            ListNode expectedList = ConvertToLinkedList(expected);

            var sut = new AddTwoNumbers2();
            ListNode actualList = sut.AddTwoNumbers(l1, l2);

            do
            {
                actualList.val.Should().Be(expectedList.val, $"{actualList.val} != {expectedList.val}");
                expectedList = expectedList.next;
                actualList = actualList.next;
            }
            while (expectedList != null);
        }

        private ListNode ConvertToLinkedList(int[] num)
        {
            ListNode head = null, prev = null;
            foreach (int digit in num)
            {
                ListNode l = new ListNode(digit);
                if (prev != null)
                {
                    prev.next = l;
                    prev = l;
                }
                else
                {
                    head = l;
                    prev = l;
                }
            }

            return head;
        }
    }
}