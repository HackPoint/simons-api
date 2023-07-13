using Application.Common.Interfaces;
using Infrastructure.Common.Helpers;
using Infrastructure.Persistence;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection {
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration
    ) {
        try {
            services.AddDbContext<ApplicationDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("Default")));
        }
        catch (Exception e) {
            Console.WriteLine($"DB Configuration error: {e.Message}");
        }

        Console.WriteLine($"Connection String: {configuration["Default"]}");
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddSingleton<MetricReporter>();
        return services;
    }
}