using Domain.Contracts;
using WebApplication1.Middelware;

namespace WebApplication1.Extensions
{
    public static class WebApplicationExtensions
    {
        public static async Task<WebApplication> SeedDbAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbintializer = scope.ServiceProvider.GetRequiredService<IDbIntializer>();
            await dbintializer.IntializeAsync();
            return app;
        }
        public static WebApplication CustomMiddleware(this WebApplication app)
        {
            app.UseMiddleware<GlobaleEroorHandlingMiddlware>();
            return app;
        } 
    }
}
