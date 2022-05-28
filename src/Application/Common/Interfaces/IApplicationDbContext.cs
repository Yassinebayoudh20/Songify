using projects.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace projects.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<Artist> Artists { get; }

    DbSet<Album> Albums { get; }

    DbSet<Song> Songs { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
