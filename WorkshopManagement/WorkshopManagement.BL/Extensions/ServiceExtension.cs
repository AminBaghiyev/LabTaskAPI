using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WorkshopManagement.BL.Services.Abstractions;
using WorkshopManagement.BL.Services.Implementations;
using WorkshopManagement.BL.Utilities;
using WorkshopManagement.Core.Entities;
using WorkshopManagement.DAL.Contexts;
using WorkshopManagement.DAL.Repositories.Abstractions;
using WorkshopManagement.DAL.Repositories.Implementations;

namespace WorkshopManagement.BL.Extensions;

public static class ServiceExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(Connection.GetConnectionStr());
        });

        services.AddScoped<IRepository<Workshop>, Repository<Workshop>>();
        services.AddScoped<IRepository<Participant>, Repository<Participant>>();
        services.AddScoped<IWorkshopService, WorkshopService>();
        services.AddScoped<IParticipantService, ParticipantService>();
    }
}
