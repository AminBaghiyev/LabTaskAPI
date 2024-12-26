using ECommerce.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DAL.Repositories.Abstractions;

public interface IRepository<T> where T : AuditableEntity, new()
{
    DbSet<T> Table { get; }
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetByIdAsNoTrackingAsync(int id);
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<int> SaveChangesAsync();
}
