using Domain.Contracts;
using Persistance.Data.DataSeeding;
using Persistance.Repositories;
using Persistance;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Extensions
{
    public static class InfrastructureServicesExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services , IConfiguration configuration)
        {
            services.AddScoped<IUniteOfWork, UniteOfWork>();

            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("DefaultConnectionStrings"));
            });
            services.AddScoped<IDbIntializer, DbIntializer>();
            return services;
        }
    }
}
