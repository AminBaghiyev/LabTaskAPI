using HospitalManagement.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.DL.Repositories.Abstractions;

public interface IRepository<T> where T : BaseAuditableEntity, new()
{
    DbSet<T> Table { get; }
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetByIdAsNoTrackingAsync(int id);
    Task CreateAsync(T entity);
    void Update(T entity);
    void Recover(T entity);
    void SoftDelete(T entity);
    void HardDelete(T entity);
    Task<int> SaveChangesAsync();
}
