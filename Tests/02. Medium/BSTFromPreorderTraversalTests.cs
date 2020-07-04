using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class BSTFromPreorderTraversalTests
    {
        private readonly ITestOutputHelper output;

        public BSTFromPreorderTraversalTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestName()
        {
            //Given
            int[] preorder = new int[] {8,5,1,7,10,12};
            
            //When
            var sut = new BSTFromPreorderTraversal();
            var root = sut.BstFromPreorder(preorder);
            //Then
            Assert.NotNull(root);
        }
    }
}