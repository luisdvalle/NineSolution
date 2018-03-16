using DataService.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NineWebService.Models;
using NineWebService.Services;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;

namespace NineWebService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Register DI mapping
            services.AddScoped<IDataProcessor<Payload>, RequestDataProcessor>();

            // Register Swagger generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Nine Solution API",
                    Version = "v1",
                    Description = "An ASP.NET Core Web API to process Shows data",
                    Contact = new Contact { Name = "Luis Del Valle", Email = "luis@luis-delvalle.com" }
                });

                // Set the comments path for the Swagger JSON and UI.
                var basePath = AppContext.BaseDirectory;
                var xmlPath = Path.Combine(basePath, "NineWebService.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Adding middleware to the pipeline
            app.UseStaticFiles();

            // Swagger middlewre
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nine Solution API V1");
            });

            app.UseMvcWithDefaultRoute();
        }
    }
}
