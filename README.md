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

## Known issues and further improvements
- Currently unit tests only covered TodoService. The test files for GlobalExceptionHandler and Repository has been added but need to add test cases.
- Pagination is not implemented for all todo retrieval.
- Currently adding todo items with the same title is allowed. De-duplication can be implemented when the scope of requirements are confirmed.

## Getting Started

### Prerequisites

- .NET 10 SDK

### Run the API

```bash
dotnet run --project TodoList.Api.csproj
```

### API endpoints
- **GET** -  `/api/todo` - Load all todos
- **GET** -  `/api/todo/{guid}` - Load all todos
- **POST** -  `/api/todo` - Create a todos
- **DELETE** -  `/api/todo/{guid}` - Delete a todos
