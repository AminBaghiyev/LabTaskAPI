using HospitalManagement.Core.Entities.Base;
using HospitalManagement.DL.Contexts;
using HospitalManagement.DL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.DL.Repositories.Implementations;

public class Repository<T> : IRepository<T> where T : BaseAuditableEntity, new()
{
    protected readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task CreateAsync(T entity)
    {
        entity.CreatedAt = DateTime.UtcNow.AddHours(4);
        await Table.AddAsync(entity);
    }

    public void Update(T entity)
    {
        entity.UpdatedAt = DateTime.UtcNow.AddHours(4);
        Table.Update(entity);
    }

    public void Recover(T entity)
    {
        entity.DeletedAt = null;
        entity.IsDeleted = false;
    }

    public void SoftDelete(T entity)
    {
        entity.DeletedAt = DateTime.UtcNow.AddHours(4);
        entity.IsDeleted = true;
    }

    public void HardDelete(T entity)
    {
        Table.Remove(entity);
    }

    public async Task<List<T>> GetAllAsync() => await Table.ToListAsync();

    public virtual async Task<T?> GetByIdAsNoTrackingAsync(int id) => await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public virtual async Task<T?> GetByIdAsync(int id) => await Table.FindAsync(id);

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}
