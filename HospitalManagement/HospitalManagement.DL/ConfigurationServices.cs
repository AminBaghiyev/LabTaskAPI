using HospitalManagement.Core.Entities;
using HospitalManagement.DL.Contexts;
using HospitalManagement.DL.Repositories.Abstractions;
using HospitalManagement.DL.Repositories.Implementations;
using HospitalManagement.DL.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HospitalManagement.DL;

public static class ConfigurationServices
{
    public static void AddDLServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>
        (
            options => options.UseSqlServer(Connection.GetConnectionString())
        );

        services.AddScoped<IRepository<Patient>, Repository<Patient>>();
        services.AddScoped<IInsuranceRepository, InsuranceRepository>();
    }
}
