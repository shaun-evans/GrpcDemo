# GrpcDemo

## GrpcClient

This is a simple gRPC client application written in C#. It communicates with a gRPC server to perform operations like greeting a user and fetching product details.

### Getting Started

To run this application, you need to have .NET 5.0 or later installed on your machine.

### Usage

The application performs two main operations:

1. **Greet**: This operation sends a greeting request to the gRPC server with a specified name and prints the response message from the server.

2. **GetProductDetails**: This operation sends a request to the gRPC server to fetch the details of a product with a specified product ID. It then prints the product details received from the server.

### Code Structure

The `Program` class contains the `Main` method which is the entry point of the application. It creates a gRPC channel with the server address specified in the `Configuration` class.

The `Greet` method creates a `GreeterClient` and sends a `HelloRequest` to the server. The response message from the server is then printed to the console.

The `GetProductDetails` method creates a `ProductClient` and sends a `GetProductDetail` request to the server. The product details received from the server are then printed to the console.

### Running the Application

To run the application, navigate to the project directory in your terminal and run the following command:

```
dotnet run
```

The application will then send a greeting request and a product details request to the gRPC server and print the responses.

### Note

Please ensure that the gRPC server is running and accessible at the address specified in the `Configuration` class before running the client application.

## GrpcService

This is a simple gRPC service application written in C#. It provides two services: a greeting service and a product service.

### Getting Started

To run this application, you need to have .NET 5.0 or later installed on your machine.

### Services

The application provides two main services:

1. **GreeterService**: This service provides a method to greet a user with a specified name.

2. **ProductService**: This service provides a method to fetch the details of a product with a specified product ID.

### Code Structure

The `Program` class contains the `Main` method which is the entry point of the application. It creates a web application builder, registers the services, and configures the HTTP request pipeline.

The `RegisterServices` method adds gRPC to the service collection.

The `ConfigureRequestPipeline` method maps the gRPC services and a GET endpoint to the web application.

### Running the Application

To run the application, navigate to the project directory in your terminal and run the following command:

```
dotnet run
```

The application will then start and listen for incoming requests.

### Note

Please ensure that a gRPC client is set up to communicate with this service. Direct communication with the gRPC endpoints must be made through a gRPC client.
