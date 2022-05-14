using ClientApi.Service.Service;
using ClienteApi.Domain.SeedWorks.Classes;
using ClienteApi.Domain.SeedWorks.Interfaces;
using ClienteApi.Domain.SeedWorks.Interfaces.Repositories;
using ClienteApi.Domain.SeedWorks.Interfaces.Services;
using ClienteApi.Respotirory.Context;
using ClienteApi.Respotirory.Repositories.General;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ClientWebApi.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {

            services.AddScoped<AppDbContext>();
            

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();

       
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<INotificator, Notificator>();
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

                      
            return services;
        }
    }
}
