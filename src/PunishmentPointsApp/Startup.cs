using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PunishmentPointsApp.Repositories;

namespace PunishmentPointsApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<PunishmentContext>(options => 
                DatabaseConfiguration.choose(Configuration).use(options)
            );

            services
                .AddMvcCore()
                .AddCors()
                .AddJsonFormatters();

            services.AddLogging(builder => builder.AddConsole());
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {   
            app.UseDefaultFiles();
            app.UseStaticFiles();
            
            app.UseCors(builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            );
            app.UseMvcWithDefaultRoute();
        }
    }
}