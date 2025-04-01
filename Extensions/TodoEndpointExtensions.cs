namespace TodoApi.Extensions;

/// <summary>
/// Extension methods for the Todo endpoints.
/// </summary>
public static class TodoEndpointExtensions
{
    private const string TodosRoute = "/todos";

    private static readonly List<TodoItemModel> todos =
    [
        new() { Id = Guid.NewGuid(), Content = "Buy some salad", IsCompleted = true },
        new() { Id = Guid.NewGuid(), Content = "Rent a car", IsCompleted = false },
    ];

    /// <summary>
    /// Map the root endpoint to the Htmx component.
    /// </summary>
    /// <param name="app">The <see cref="IEndpointRouteBuilder"/> instance.</param>
    public static void MapToRootEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/", () =>
        {
            return new RazorComponentResult<Htmx>();
        });
    }

    /// <summary>
    /// Map the Todo endpoints.
    /// </summary>
    /// <param name="app">The <see cref="IEndpointRouteBuilder"/> instance.</param>
    public static void MapTodoEndpoints(this IEndpointRouteBuilder app)
    {
        var route = app.MapGroup(TodosRoute);

        // GET (load all)
        route.MapGet("/", () => new RazorComponentResult<TodoItems>(new
        {
            Model = todos
        }));

        // TOGGLE
        route.MapPost("/{todoId}/toggle", (string todoId) =>
        {
            var todo = todos.First(t => t.Id.ToString() == todoId);
            todo.IsCompleted = !todo.IsCompleted;

            return new RazorComponentResult<TodoItem>(new
            {
                Model = todo
            });
        });

        // DELETE
        route.MapDelete("/{todoId}", (string todoId) =>
        {
            todos.Remove(todos.First(t => t.Id.ToString() == todoId));
        });

        // ADD new
        route.MapPost("/", (AddTodoItem item) =>
        {
            var todo = new TodoItemModel
            {
                Id = Guid.NewGuid(),
                Content = item.Content,
                IsCompleted = false
            };

            todos.Add(todo);

            return new RazorComponentResult<TodoItem>(new
            {
                Model = todo
            });
        });
    }
}