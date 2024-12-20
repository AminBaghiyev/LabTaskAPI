using Microsoft.EntityFrameworkCore;
using WorkshopManagement.Core.Entities.Base;

namespace WorkshopManagement.DAL.Repositories.Abstractions;

public interface IRepository<T> where T : BaseEntity, new()
{
    DbSet<T> Table { get; }
    Task<T> GetByIdAsync(int id, params string[] includes);
    Task<T> GetByIdAsNoTrackingAsync(int id, params string[] includes);
    Task<ICollection<T>> GetAllAsync();
    Task<T> CreateAsync(T entity);
    T Update(T entity);
    void Delete(T entity);
    Task<int> SaveChangesAsync();
    Task<bool> IsExistsAsync(int id);
}
