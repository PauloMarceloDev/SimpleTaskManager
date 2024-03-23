namespace PWSoftware.BaseDomain.Abstractions;

public interface IBaseRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    
    Task<T?> GetByIdOrDefaultAsync(int id, CancellationToken cancellationToken);
    
    void Add(T entity);
    
    void Update(T entity);

    void Delete(T entity);
}
