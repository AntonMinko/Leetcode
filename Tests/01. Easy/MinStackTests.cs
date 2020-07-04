using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;

namespace Tests
{
    public class MinStackTests
    {
        private readonly ITestOutputHelper output;

        public MinStackTests(ITestOutputHelper output)
        {
            this.output = output;
        }
        
        [Fact]
        public void TestName()
        {
            MinStack minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            int min = minStack.GetMin();
            Assert.Equal(-3, min);
            minStack.Pop();
            int top = minStack.Top();
            Assert.Equal(0, top);
            min = minStack.GetMin();
            Assert.Equal(-2, min);
        }
    }
}