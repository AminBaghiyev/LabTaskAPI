using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WorkshopManagement.Core.Entities;

namespace WorkshopManagement.DAL.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Workshop> Workshops { get; set; }
    public DbSet<Participant> Participants { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
