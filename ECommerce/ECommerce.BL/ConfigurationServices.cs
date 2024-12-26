using ECommerce.BL.Services.Abstractions;
using ECommerce.BL.Services.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerce.BL;

public static class ConfigurationServices
{
    public static void AddBLServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<IProductService, ProductService>();
    }
}
