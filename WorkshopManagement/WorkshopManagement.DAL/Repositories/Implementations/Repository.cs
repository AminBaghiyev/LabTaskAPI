using Microsoft.EntityFrameworkCore;
using WorkshopManagement.Core.Entities.Base;
using WorkshopManagement.DAL.Contexts;
using WorkshopManagement.DAL.Repositories.Abstractions;

namespace WorkshopManagement.DAL.Repositories.Implementations;

public class Repository<T> : IRepository<T> where T : BaseEntity, new()
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task<T> CreateAsync(T entity)
    {
        await Table.AddAsync(entity);
        return entity;
    }

    public void Delete(T entity)
    {
        Table.Remove(entity);
    }

    public async Task<ICollection<T>> GetAllAsync() => await Table.ToListAsync();

    public async Task<T> GetByIdAsync(int id) => await Table.FindAsync(id);

    public T Update(T entity)
    {
        Table.Update(entity);
        return entity;
    }

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

    public async Task<bool> IsExistsAsync(int id) => await Table.AnyAsync(x => x.Id == id);
}
