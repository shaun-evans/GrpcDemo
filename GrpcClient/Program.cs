using Grpc.Net.Client;
using GrpcClient;
using GrpcClient.Protos;

static class Program
{
    static async Task Main()
    {
        var config = new Configuration();
        var serverAddress = config.ServerAddress;

        using var channel = GrpcChannel.ForAddress(serverAddress);

        await Greet(channel, "Shaun Evans");
        await GetProductDetails(channel, 3);

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    private static async Task Greet(GrpcChannel channel, string name)
    {
        var greeterClient = new Greeter.GreeterClient(channel);
        var greeterReply = await greeterClient.SayHelloAsync(request: new HelloRequest { Name = name });
        Console.WriteLine("Greeting: " + greeterReply.Message);
    }

    private static async Task GetProductDetails(GrpcChannel channel, int productId)
    {
        var productClient = new Product.ProductClient(channel);
        var productReply = await productClient.GetProductsInformationAsync(request: new GetProductDetail { ProductId = productId });
        Console.WriteLine($"{productReply.ProductName} | {productReply.ProductDescription} | {productReply.ProductPrice} | {productReply.ProductStock}");
    }
}
