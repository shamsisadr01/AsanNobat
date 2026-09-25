using AsanNobat.Domain.Common.DDD;

namespace AsanNobat.Domain.Entities;

public class TodoList : BaseEntity
{
    public string? Title { get; set; }

    public Colour Colour { get; set; } = Colour.Grey;

    public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
}
