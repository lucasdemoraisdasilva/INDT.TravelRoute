using INDT.TravelRoute.Domain.Interfaces.Repositories;
using INDT.TravelRoute.Domain.Interfaces.UoW;
using INDT.TravelRoute.Infrastructure.SqlServer.Repositories;
using INDT.TravelRoute.Infrastructure.SqlServer.UoW;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace INDT.TravelRoute.Infrastructure.SqlServer.DependencyInjection.Extensions
{
    public static class SqlServerExtensions
    {
        public static IServiceCollection AddSqlServerDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var config = configuration.GetSection(nameof(ConnectionStrings));
            services.Configure<ConnectionStrings>(config.Bind);

            services.AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDapperDbContext, DapperDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRouteCrudRepository, RouteCrudRepository>();
            services.AddScoped<ITravelRouteRepository, TravelRouteRepository>();

            return services;
        }
    }
}
