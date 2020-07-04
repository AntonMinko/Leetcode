using Solutions;
using Xunit;
using Xunit.Abstractions;
using System.Text;
using System.Diagnostics;
using FluentAssertions;

namespace Tests
{
    public class ProductOfArrayExceptSelfTests
    {
        private readonly ITestOutputHelper output;

        public ProductOfArrayExceptSelfTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Test1()
        {
        //Given
        int[] nums = new int[] {1,2,3,4};
        
        //When
        var sut = new ProductOfArrayExceptSelf();
        int[] result = sut.ProductExceptSelf(nums);
        
        //Then
        int[] expected = new int[] {24,12,8,6};
        result.Should().Equal(expected);
        }

         [Fact]
        public void Test2()
        {
        //Given
        int[] nums = new int[] {1,2,0,4};
        
        //When
        var sut = new ProductOfArrayExceptSelf();
        int[] result = sut.ProductExceptSelf(nums);
        
        //Then
        int[] expected = new int[] {0,0,8,0};
        result.Should().Equal(expected);
        }

         [Fact]
        public void Test3()
        {
        //Given
        int[] nums = new int[] {3,4};
        
        //When
        var sut = new ProductOfArrayExceptSelf();
        int[] result = sut.ProductExceptSelf(nums);
        
        //Then
        int[] expected = new int[] {4,3};
        result.Should().Equal(expected);
        }
    }
}