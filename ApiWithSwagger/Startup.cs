using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
namespace ApiWithSwagger
{
    #pragma warning disable CS1591
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
            services.AddControllers();
            services.AddSwaggerGen(options => {
                options.SwaggerDoc("v1", new OpenApiInfo(){
                    Version = "v1",
                    Title = "API With Swagger",
                    Description = "Net Core API With Swagger",
                    TermsOfService = new Uri("https://google.com"),
                    Contact = new OpenApiContact(){
                        Name = "Zümrüdü Anka",
                        Email = "osmandurdag@hotmail.com",
                        Url = new Uri("https://github.com")
                    },
                    License = new OpenApiLicense(){
                        Name = "Use under MIT",
                        Url = new Uri("https://facebook.com")
                    }
                });

                // options.SwaggerDoc("v2", new OpenApiInfo());

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseStaticFiles();

            app.UseSwagger(options => {
                options.RouteTemplate = "api-docs/{documentName}/swg.json";
            });
            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/api-docs/v1/swg.json","Core API");
                options.DocumentTitle = "Belge Başlığı";
                options.RoutePrefix = "swagger";
                options.InjectStylesheet("/swagger/ui/custom.css");
            });
        }
    }
}
