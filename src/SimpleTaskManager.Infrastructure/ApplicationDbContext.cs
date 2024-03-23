using Microsoft.EntityFrameworkCore;
using PWSoftware.BaseDomain.Abstractions;

namespace SimpleTaskManager.Infrastructure;

public sealed class ApplicationDbContext(
    DbContextOptions options)
    : DbContext(options), IUnitOfWork
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
