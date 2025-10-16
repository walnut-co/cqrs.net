# CQRS.Net

[![NuGet Version](https://img.shields.io/nuget/v/Walnut.CQRS.Net.svg)](https://www.nuget.org/packages/Walnut.CQRS.Net/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Walnut.CQRS.Net.svg)](https://www.nuget.org/packages/Walnut.CQRS.Net/)

A lightweight CQRS (Command Query Responsibility Segregation) implementation for .NET projects.

## Features

- Simple and clean CQRS pattern implementation
- Request/Response handling with strongly typed interfaces
- Built-in dependency injection integration
- Pipeline behavior support for cross-cutting concerns
- Minimal setup required

## Installation

```bash
dotnet add package Walnut.CQRS.Net
```

## Usage

### 1. Register services in your DI container

```csharp
services.AddCQRS();
```

### 2. Define your commands and queries

```csharp
public class SayHelloCommand : IRequest<string>
{
    public string Name { get; set; }
}
```

### 3. Inject and use the dispatcher

```csharp
public class MyController : ControllerBase
{
    private readonly IRequestDispatcher _dispatcher;
    
    public MyController(IRequestDispatcher dispatcher)
    {
        _dispatcher = dispatcher;
    }
    
    [HttpPost]
    public async Task<string> SayHello([FromBody] SayHelloCommand command)
    {
        return await _dispatcher.Send(command);
    }
}
```

## License

This project is licensed under the Apache License.
