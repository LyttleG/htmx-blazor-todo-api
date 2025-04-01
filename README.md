# TodoApi in HTMX

`TodoApi in HTMX` provides methods for mapping endpoints related to Todo items in an ASP.NET Core application using HTMX. This simplifies the process of setting up routes for CRUD operations on Todo items.

## Features

- Maps the root endpoint to an Htmx Blazor component.
- Maps endpoints for loading, toggling, deleting, and adding Todo items.
- Uses in-memory storage for Todo items.

## Usage

### Prerequisites

- ASP.NET Core application.
- Razor components for rendering UI.

### Installation

1. Ensure you have the necessary dependencies for Razor components and endpoint routing.

### Example

```csharp
using TodoApi.Extensions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Map the root endpoint to the Htmx Blazor component
app.MapToRootEndpoint();

// Map the Todo endpoints
app.MapTodoEndpoints();

app.Run();
```

## Methods

### `MapToRootEndpoint`

Maps the root endpoint (`"/"`) to an Htmx Blazor component.

```csharp
public static void MapToRootEndpoint(this IEndpointRouteBuilder app)
```

- **Parameters:**
  - `app`: The `IEndpointRouteBuilder` instance.

### `MapTodoEndpoints`

Maps the Todo endpoints for CRUD operations.

```csharp
public static void MapTodoEndpoints(this IEndpointRouteBuilder app)
```

- **Parameters:**
  - `app`: The `IEndpointRouteBuilder` instance.

#### Endpoints

- **GET `/todos`**: Loads all Todo items.
- **POST `/todos/{todoId}/toggle`**: Toggles the completion status of a Todo item.
- **DELETE `/todos/{todoId}`**: Deletes a Todo item.
- **POST `/todos`**: Adds a new Todo item.

## Models

### `TodoItemModel`

Represents a Todo item.

```csharp
public class TodoItemModel
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public bool IsCompleted { get; set; }
}
```

### `AddTodoItem`

Represents a model for adding a new Todo item.

```csharp
public class AddTodoItem
{
    public string Content { get; set; }
}
```

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

Created by [**Gérôme Guillemin**](https://github.com/LyttleG/) on *April 1st, 2025*  

## License

MIT