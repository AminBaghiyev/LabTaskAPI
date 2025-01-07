using FluentValidation;
using FluentValidation.AspNetCore;
using HospitalManagement.BL.Services.Abstractions;
using HospitalManagement.BL.Services.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HospitalManagement.BL;

public static class ConfigurationServices
{
    public static void AddBLServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services
            .AddFluentValidationAutoValidation()
            .AddFluentValidationClientsideAdapters()
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddScoped<IInsuranceService, InsuranceService>();
        services.AddScoped<IPatientService, PatientService>();
    }
}
