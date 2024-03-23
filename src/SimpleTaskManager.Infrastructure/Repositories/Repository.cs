using Microsoft.EntityFrameworkCore;
using PWSoftware.BaseDomain.Abstractions;

namespace SimpleTaskManager.Infrastructure.Repositories;

public abstract class Repository<T>(ApplicationDbContext dbContext) where T : Entity
{
    protected readonly ApplicationDbContext DbContext = dbContext;

    public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken) =>
        await DbContext.Set<T>().AsNoTracking().ToListAsync(cancellationToken);

    public async Task<T?> GetByIdOrDefaultAsync(int id, CancellationToken cancellationToken) =>
        await DbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(t => t.Id == id, cancellationToken);

    public virtual void Add(T entity)
    {
        DbContext.Set<T>().Add(entity);
    }

    public virtual void Update(T entity)
    {
        DbContext.Set<T>().Update(entity);
    }

    public virtual void Delete(T id)
    {
        DbContext.Set<T>().Update(id);
    }
}
