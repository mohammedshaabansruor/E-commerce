using Microsoft.AspNetCore.Mvc;
using WebApplication1.Factories;

namespace WebApplication1.Extensions
{
    public static class PresentationServiceExtension
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services) 
        {
            services.AddControllers().AddApplicationPart(typeof(Presentation.AssembleyReference).Assembly);
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.Configure<ApiBehaviorOptions>(option =>
            {
                option.InvalidModelStateResponseFactory = ApiResponseFactory.CustomValidationErrorResponse;// Func => return IActionResult , ActionContext
            });
            return services;
        }
    }
}
