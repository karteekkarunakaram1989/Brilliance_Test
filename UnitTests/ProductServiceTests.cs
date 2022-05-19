using Service;
using System;
using Xunit;

namespace UnitTests
{
    public class ProductServiceTests
    {
        protected ProductService sut;

        public ProductServiceTests()
        {
            sut = new ProductService();
        }

    }
    public class ProductService_ArrayRemoveAt_Tests : ProductServiceTests
    {
        [Theory]
        [InlineData(4, new int[] { 3, 5, 7, 5, 9 }, new int[] { 3, 5, 7, 5 })]
        [InlineData(3, new int[] { 2, 6, 4, 8, 1, 7 }, new int[] { 2, 6, 4, 1, 7 })]
        [InlineData(0, new int[] { 1 }, new int[] {})]
        [InlineData(1, new int[] { 4, 7 }, new int[] { 4 })]
        public void ArrayRemoveAt_Test_HappyPaths(int position, int[] productIds, int[] expectedResult)
        {
            //Arrange

            //Act
            var actualResult = sut.ArrayRemoveAt(productIds, position);

            //Assert
            Assert.Equal(expectedResult.Length, productIds.Length - 1);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(-1, new int[] { 3, 5, 7, 5, 9 })]
        [InlineData(6, new int[] { 2, 6, 4, 8, 1, 7 })]
        [InlineData(100, new int[] { 2, 6, 4, 8, 1, 7 })]
        public void ArrayRemoveAt_Test_Throws_Exception_When_Position_IsOutOfRange(int position, int[] productIds)
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<Exception>(() => sut.ArrayRemoveAt(productIds, position));
        }
    }

    public class ProductService_ArrayReverse_Tests : ProductServiceTests
    {
        [Theory]
        [InlineData(new int[] { 3, 5, 7, 5, 9 }, new int[] { 9, 5, 7, 5, 3 })]
        [InlineData(new int[] { 2, 6, 4, 8, 1, 7 }, new int[] { 7, 1, 8, 4, 6, 2 })]
        [InlineData(new int[] { 1 }, new int[] { 1 })]
        [InlineData(new int[] { 4, 7 }, new int[] { 7, 4 })]
        public void ArrayReverse_Test_Verify_Result(int[] productIds, int[] expectedResult)
        {
            //Arrange

            //Act
            var actualResult = sut.ArrayReverse(productIds);

            //Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
