using Xunit;
using Moq;
using Grpc.Core;
using GrpcClient.Protos;
using System.Threading.Tasks;

public class GrpcClientTests
{
    private Mock<Greeter.GreeterClient> _mockGreeterClient;
    private Mock<Product.ProductClient> _mockProductClient;

    public GrpcClientTests()
    {
        _mockGreeterClient = new Mock<Greeter.GreeterClient>(MockBehavior.Strict);
        _mockProductClient = new Mock<Product.ProductClient>(MockBehavior.Strict);
    }

    [Fact]
    public async Task TestSayHelloAsync()
    {
        // Arrange
        var expectedReply = new HelloReply { Message = "Hello Shaun Evans" };
        _mockGreeterClient.Setup(x => x.SayHelloAsync(It.IsAny<HelloRequest>(), null, null, default))
            .Returns(new AsyncUnaryCall<HelloReply>(
                Task.FromResult(expectedReply), // response
                Task.FromResult(new Metadata()), // headers
                () => Status.DefaultSuccess, // status
                () => new Metadata(), // trailers
                () => { })); // disposal action

        // Act
        var greeterReply = await _mockGreeterClient.Object.SayHelloAsync(new HelloRequest { Name = "Shaun Evans" });

        // Assert
        Assert.Equal(expectedReply.Message, greeterReply.Message);
        _mockGreeterClient.Verify(x => x.SayHelloAsync(It.IsAny<HelloRequest>(), null, null, default), Times.Once);
    }

    [Fact]
    public async Task TestGetProductsInformationAsync()
    {
        // Arrange
        var expectedReply = new ProductModel
        {
            ProductName = "Product Name",
            ProductDescription = "Product Description",
            ProductPrice = 100,
            ProductStock = 10
        };
        _mockProductClient.Setup(x => x.GetProductsInformationAsync(It.IsAny<GetProductDetail>(), null, null, default))
            .Returns(new AsyncUnaryCall<ProductModel>(
                Task.FromResult(expectedReply), // response
                Task.FromResult(new Metadata()), // headers
                () => Status.DefaultSuccess, // status
                () => new Metadata(), // trailers
                () => { })); // disposal action

        // Act
        var productReply = await _mockProductClient.Object.GetProductsInformationAsync(new GetProductDetail { ProductId = 3 });

        // Assert
        Assert.Equal(expectedReply.ProductName, productReply.ProductName);
        Assert.Equal(expectedReply.ProductDescription, productReply.ProductDescription);
        Assert.Equal(expectedReply.ProductPrice, productReply.ProductPrice);
        Assert.Equal(expectedReply.ProductStock, productReply.ProductStock);
        _mockProductClient.Verify(x => x.GetProductsInformationAsync(It.IsAny<GetProductDetail>(), null, null, default), Times.Once);
    }
}
