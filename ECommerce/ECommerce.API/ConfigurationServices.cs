using ECommerce.BL.Utilities;
using ECommerce.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API;

public static class ConfigurationServices
{
    public static void AddAPIServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(Connection.GetConnectionString());
        });
    }
}
