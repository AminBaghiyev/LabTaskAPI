using ECommerce.Core.Entities;
using ECommerce.DAL.Repositories.Abstractions;
using ECommerce.DAL.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.DAL;

public static class ConfigurationServices
{
    public static void AddDALServices(this IServiceCollection services)
    {
        services.AddScoped<IRepository<Product>, Repository<Product>>();
        services.AddScoped<IRepository<Order>, Repository<Order>>();
        services.AddScoped<IRepository<OrderItem>, Repository<OrderItem>>();
    }
}
