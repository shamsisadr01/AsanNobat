using AsanNobat.Domain.BusinessAgg;
using AsanNobat.Domain.Entities;

namespace AsanNobat.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Business> Businesses { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
