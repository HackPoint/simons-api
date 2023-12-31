﻿using System.Reflection;
using Application.Common.Behaviours;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection {
    public static IServiceCollection AddApplication(
        this IServiceCollection services
    ) {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddAutoMapper(assembly);
        services.AddValidatorsFromAssembly(assembly);

        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(assembly);

            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(PerformanceBehaviour<,>));
        });
        return services;
    }
}