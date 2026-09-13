# Todo List API

A small REST API built with ASP.NET Core as a demonstration project for coding challenge.

## Features

- Create todo items
- List all todo items
- Retrieve a todo item by ID
- Delete a todo item
- Input validation using data annotations
- Centralized error handling with RFC 7807-style problem details
- Unit tests for service behavior

## Technology

- C#, .NET 10, Web API
- xUnit for unit testing
- `ConcurrentDictionary` for thread-safe in-memory storage

## Getting Started

### Prerequisites

- .NET 10 SDK

### Run the API

```bash
dotnet run --project TodoList.Api.csproj
```
