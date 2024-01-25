using GrpcService.Services;

const string gRPCClientCreationUrl = "https://go.microsoft.com/fwlink/?linkid=2086909";

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit macOSConfigurationUrl

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
