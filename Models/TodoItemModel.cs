namespace TodoApi.Models;

public class TodoItemModel
{
    public Guid Id { get; set; }
    public bool IsCompleted { get; set; }
    public string? Content { get; set; }
};
