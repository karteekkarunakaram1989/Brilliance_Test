using Brilliance_Test.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTests
{
    public class ArrayCalcControllerTests : ControllerBase
    {
        protected Mock<IProductService> productServiceMock;
        protected ArrayCalcController sut;

        public ArrayCalcControllerTests()
        {
            productServiceMock = new Mock<IProductService>();


            sut = new ArrayCalcController(productServiceMock.Object);
        }
    }

    public class ArrayCalcController_Reverse_Tests : ArrayCalcControllerTests
    {
        [Fact]
        public void Test_Calls_ProductService_ArrayReverse()
        {
            //Arrange
            var input = new int[] { 3, 2, 1 };

            //Act
            sut.Reverse(input);

            //Assert
            productServiceMock.Verify(p => p.ArrayReverse(input), Times.Once());
        }

        [Fact]
        public void Test_Returns_Response_From_ProductService_ArrayReverse()
        {
            //Arrange
            var input = new int[] { 3, 2, 1 };
            var output = new int[] { 1, 2, 3 };
            productServiceMock.Setup(p => p.ArrayReverse(It.IsAny<int[]>())).Returns(output);

            //Act
            var result = sut.Reverse(input);

            //Assert
            Assert.Equal(output, result);
        }
    }

    public class ArrayCalcController_DeletePart_Tests : ArrayCalcControllerTests
    {
        [Fact]
        public void Test_Calls_ProductService_ArrayRemoveAt()
        {
            //Arrange
            var inputPosition = 2;
            var inputIds = new int[] { 3, 2, 1 };

            //Act
            sut.DeletePart(inputPosition, inputIds);

            //Assert
            productServiceMock.Verify(p => p.ArrayRemoveAt(inputIds, inputPosition), Times.Once());
        }

        [Fact]
        public void Test_Returns_Response_From_ProductService_ArrayReverse()
        {
            //Arrange
            var inputPosition = 2;
            var inputIds = new int[] { 3, 2, 1 };
            var output = new int[] { 3, 2 };
            productServiceMock.Setup(p => p.ArrayRemoveAt(It.IsAny<int[]>(), It.IsAny<int>())).Returns(output);

            //Act
            var result = sut.DeletePart(inputPosition, inputIds);

            //Assert
            Assert.Equal(output, result.Value);
        }

        [Fact]
        public void Test_Returns_StatusCode500_When_ProductService_ArrayReverse_Throws_Exception()
        {
            //Arrange
            var inputPosition = 100;
            var inputIds = new int[] { 3, 2, 1 };
            var exception = new Exception("Position out of the index");
            productServiceMock.Setup(p => p.ArrayRemoveAt(It.IsAny<int[]>(), It.IsAny<int>())).Throws(exception);
            var expectedResult = StatusCode(500, "Position out of the index");

            //Act
            var result = sut.DeletePart(inputPosition, inputIds);

            //Assert
            var actualResult = Assert.IsType<ObjectResult>(result.Result);
            Assert.Equal(expectedResult.StatusCode, actualResult.StatusCode);
            Assert.Equal(expectedResult.Value, actualResult.Value);
        }
    }
}
