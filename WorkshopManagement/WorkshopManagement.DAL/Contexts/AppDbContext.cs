using Microsoft.EntityFrameworkCore;
using WorkshopManagement.Core.Entities;

namespace WorkshopManagement.DAL.Contexts;

public class AppDbContext : DbContext
{
    public DbSet<Workshop> Workshops { get; set; }
    public DbSet<Participant> Participants { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
