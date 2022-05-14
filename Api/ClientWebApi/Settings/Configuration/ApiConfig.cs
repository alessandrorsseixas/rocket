using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Compression;


namespace ClientWebApi.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection WebApiConfig(this IServiceCollection services)
        {
            services.Configure<GzipCompressionProviderOptions>(options => options.Level = CompressionLevel.Optimal);
            services.AddResponseCompression(options => { options.Providers.Add<GzipCompressionProvider>(); });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>()
            .AddScoped<IUrlHelper>(x => x.GetRequiredService<IUrlHelperFactory>()
            .GetUrlHelper(x.GetRequiredService<IActionContextAccessor>().ActionContext));


            //.AddJsonOptions(opcoes =>
            // {
            //     opcoes.SerializerSettings.NullValueHandling =
            //         NullValueHandling.Ignore;
            // }); ;

            //services.AddOData();
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;

            });

            // services.AddRouting
            //services.AddCors(options =>
            //{
            //    options.AddPolicy("Development",
            //        builder =>
            //            builder
            //            .AllowAnyOrigin()
            //            .AllowAnyMethod()
            //            .AllowAnyHeader()
            //            .AllowCredentials());

            //    options.AddPolicy("Staging",
            //       builder =>
            //           builder
            //           .AllowAnyOrigin()
            //           .AllowAnyMethod()
            //           .AllowAnyHeader()
            //           .AllowCredentials());


            //    options.AddPolicy("Production",
            //        builder =>
            //            builder
            //                .WithMethods("GET")
            //                .WithOrigins("inserir dominio")
            //                .SetIsOriginAllowedToAllowWildcardSubdomains()
            //                .WithHeaders(HeaderNames.ContentType, "x-custom-header")
            //                .AllowAnyHeader());
            //});



            return services;
        }

        public static IApplicationBuilder UseMvcConfiguration(this IApplicationBuilder app)
        {
            app.UseResponseCompression();
            app.UseHttpsRedirection();
            app.UseMvc();

            return app;
        }


    }
}
