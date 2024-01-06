using Grpc.Net.Client;
using GrpcClient.Protos;

// The port number must match the port of the gRPC server.
using var channel = GrpcChannel.ForAddress("https://localhost:7288");

var greeterClient = new Greeter.GreeterClient(channel);
var greeterReply = await greeterClient.SayHelloAsync(request: new HelloRequest { Name = "Shaun Evans" });
Console.WriteLine("Greeting: " + greeterReply.Message);

var productClient = new Product.ProductClient(channel);
var productReply = await productClient.GetProductsInformationAsync(request: new GetProductDetail { ProductId = 3 });
Console.WriteLine($"{productReply.ProductName} | {productReply.ProductDescription} | {productReply.ProductPrice} | {productReply.ProductStock}");

Console.WriteLine("Press any key to exit...");
Console.ReadKey();