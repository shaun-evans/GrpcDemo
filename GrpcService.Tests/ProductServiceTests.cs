using Grpc.Core;
using GrpcService.Protos;
using GrpcService.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace GrpcService.Tests
{
    public class ProductServiceTests
    {
        private readonly ProductService service;
        private readonly ServerCallContext context;

        public ProductServiceTests()
        {
            var loggerMock = new Mock<ILogger<ProductService>>();
            service = new ProductService(loggerMock.Object);
            context = new Mock<ServerCallContext>().Object;
        }

        [Fact]
        public async Task GetProductsInformation_ReturnsCorrectProductForId1()
        {
            // Arrange
            var request = new GetProductDetail { ProductId = 1 };

            // Act
            var response = await service.GetProductsInformation(request, context);

            // Assert
            Assert.Equal("Samsung TV", response.ProductName);
            Assert.Equal("Smart TV", response.ProductDescription);
            Assert.Equal(35000, response.ProductPrice);
            Assert.Equal(10, response.ProductStock);
        }

        [Fact]
        public async Task GetProductsInformation_ReturnsCorrectProductForId2()
        {
            // Arrange
            var request = new GetProductDetail { ProductId = 2 };

            // Act
            var response = await service.GetProductsInformation(request, context);

            // Assert
            Assert.Equal("HP Laptop", response.ProductName);
            Assert.Equal("HP Pavilion", response.ProductDescription);
            Assert.Equal(55000, response.ProductPrice);
            Assert.Equal(20, response.ProductStock);
        }

        [Fact]
        public async Task GetProductsInformation_ReturnsCorrectProductForId3()
        {
            // Arrange
            var request = new GetProductDetail { ProductId = 3 };

            // Act
            var response = await service.GetProductsInformation(request, context);

            // Assert
            Assert.Equal("IPhone", response.ProductName);
            Assert.Equal("IPhone 12", response.ProductDescription);
            Assert.Equal(65000, response.ProductPrice);
            Assert.Equal(30, response.ProductStock);
        }

    }
}