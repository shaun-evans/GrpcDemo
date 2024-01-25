using Grpc.Core;
using GrpcService.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace GrpcService.Tests
{
    public class GreeterServiceTests
    {
        [Fact]
        public async Task SayHello_ReturnsCorrectMessage()
        {
            // Arrange
            var loggerMock = new Mock<ILogger<GreeterService>>();
            var service = new GreeterService(loggerMock.Object);
            var request = new HelloRequest { Name = "Test" };
            var context = new Mock<ServerCallContext>().Object;

            // Act
            var response = await service.SayHello(request, context);

            // Assert
            Assert.Equal("Hello Test", response.Message);
        }
    }
}