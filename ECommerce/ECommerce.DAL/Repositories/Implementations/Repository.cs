using ECommerce.Core.Entities.Base;
using ECommerce.DAL.Contexts;
using ECommerce.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.DAL.Repositories.Implementations;

public class Repository<T> : IRepository<T> where T : AuditableEntity, new()
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

    public void Delete(T entity)
    {
        Table.Remove(entity);
    }

    public async Task<List<T>> GetAllAsync() => await Table.ToListAsync();

    public async Task<T?> GetByIdAsNoTrackingAsync(int id) => await Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

    public async Task<T?> GetByIdAsync(int id) => await Table.FindAsync(id);

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}
