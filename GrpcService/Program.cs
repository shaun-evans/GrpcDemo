using GrpcService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
RegisterServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
ConfigureRequestPipeline(app);

app.Run();

void RegisterServices(IServiceCollection services)
{
    services.AddGrpc();
}

void ConfigureRequestPipeline(WebApplication app)
{
    app.MapGrpcService<GreeterService>();
    app.MapGrpcService<ProductService>();
    app.MapGet("/", () => $"Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: {gRPCClientCreationUrl}");
}
