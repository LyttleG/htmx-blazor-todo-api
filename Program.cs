var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents();

var app = builder.Build();

app.MapToRootEndpoint();
app.MapTodoEndpoints();

app.Run();