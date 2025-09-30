using Services;
using Services_Abstraction;

namespace WebApplication1.Extensions
{
    public static class CoreServicesExtensions
    {
        // builder.service // extension method 
        public static IServiceCollection AddCoreServices(this IServiceCollection services) 
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddAutoMapper(typeof(Services.AssembleyReference).Assembly);
            return services;

        }
    }
}
