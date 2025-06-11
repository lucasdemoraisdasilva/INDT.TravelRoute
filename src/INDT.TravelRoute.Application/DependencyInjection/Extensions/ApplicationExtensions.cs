namespace INDT.TravelRoute.Application.DependencyInjection.Extensions;

using FluentValidation;
using INDT.TravelRoute.Application.Interfaces.Services;
using INDT.TravelRoute.Application.Interfaces.UseCases;
using INDT.TravelRoute.Application.Models;
using INDT.TravelRoute.Application.Services;
using INDT.TravelRoute.Application.UseCases;
using INDT.TravelRoute.Application.Validators;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddConfiguration(configuration);

        services.AddServices();

        services.AddUseCases();

        services.AddValidator();

        return services;
    }

    public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var section = configuration.GetSection(nameof(ApplicationConfig));
        var config = configuration.GetSection(nameof(ApplicationConfig)).Get<ApplicationConfig>();

        services.Configure<ApplicationConfig>(section.Bind);

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBestTravelRouteService, BestTravelRouteService>();

        return services;
    }

    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<ICreateRouteUseCase, CreateRouteUseCase>();
        services.AddScoped<IDeleteRouteUseCase, DeleteRouteUseCase>();
        services.AddScoped<IGetAllRoutesUseCase, GetAllRoutesUseCase>();
        services.AddScoped<IGetRouteByIdUseCase, GetRouteByIdUseCase>();
        services.AddScoped<IGetBestTravelRouteUseCase, GetBestTravelRouteUseCase>();
        services.AddScoped<IUpdateRouteUseCase, UpdateRouteUseCase>();

        return services;
    }

    public static IServiceCollection AddValidator(this IServiceCollection services)
    {
        services.AddScoped<IValidator<RouteInputDto>, RouteInputValidator>();

        return services;
    }
}
