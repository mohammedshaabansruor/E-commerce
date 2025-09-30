
using Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;
using Persistance.Data.DataSeeding;
using Persistance.Repositories;
using Services;
using Services_Abstraction;
using WebApplication1.Extensions;
using WebApplication1.Factories;
using WebApplication1.Middelware;

namespace WebApplication1
{
    public class Program
    {
        public static async Task Main(string[] args) 
        {
            #region Services
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            // Presentation service
            builder.Services.AddPresentationServices();

            // Core service 
            builder.Services.AddCoreServices();

            // infrastructure service
            builder.Services.AddInfrastructureServices(builder.Configuration);

            //resolve for some dependcies => create scope  
            var app = builder.Build(); 
            #endregion

            #region Pipeline / Middleware
            app.UseMiddleware<GlobaleEroorHandlingMiddlware>();
            app.CustomMiddleware();
            await app.SeedDbAsync();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();

            #endregion


        }
    }
}
