using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class BinaryTreeMaxPathSumTests
    {
        private readonly ITestOutputHelper output;

        public BinaryTreeMaxPathSumTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test1()
        {
            //Given
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node1 = new TreeNode(1, node2, node3);

            //When
            var sut = new BinaryTreeMaxPathSum();
            int sum = sut.MaxPathSum(node1);

            //Then
            sum.Should().Be(6);
        }

        [Fact]
        public void Test2()
        {
            // Input: [-10,9,20,null,null,15,7]
            //      -10
            //      / \
            //     9  20
            //       / \
            //      15  7
            // Output: 42
            var node15 = new TreeNode(15);
            var node7 = new TreeNode(7);
            var node20 = new TreeNode(20, node15, node7);
            var node9 = new TreeNode(9);
            var nodeM10 = new TreeNode(-10, node9, node20);

            var sut = new BinaryTreeMaxPathSum();
            int sum = sut.MaxPathSum(nodeM10);
            sum.Should().Be(42);
        }

        [Fact]
        public void Test3()
        {
            // Input: [-10,9,20,null,null,15,7]
            //      -10
            //      / \
            //     9  20
            //    /    \
            //   15     7
            // Output: 42
            var node15 = new TreeNode(15);
            var node9 = new TreeNode(9, node15);
            var node7 = new TreeNode(7);
            var node20 = new TreeNode(20, null, node7);
            var nodeM10 = new TreeNode(-10, node9, node20);

            var sut = new BinaryTreeMaxPathSum();
            int sum = sut.MaxPathSum(nodeM10);
            sum.Should().Be(41);
        }

        [Fact]
        public void Test4()
        {
            //Given
            var nodeM1 = new TreeNode(-1);
            var node2 = new TreeNode(2, nodeM1);

            //When
            var sut = new BinaryTreeMaxPathSum();
            int sum = sut.MaxPathSum(node2);

            //Then
            sum.Should().Be(2);
        }

        [Fact]
        public void Test5()
        {
            //Given
            var nodeM1 = new TreeNode(-1);

            //When
            var sut = new BinaryTreeMaxPathSum();
            int sum = sut.MaxPathSum(nodeM1);

            //Then
            sum.Should().Be(-1);
        }
    }
}