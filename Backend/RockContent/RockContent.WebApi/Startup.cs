using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using RockContent.Application.AutoMapper;
using RockContent.Application.Interfaces;
using RockContent.Application.Services;
using RockContent.Domain.Interfaces;
using RockContent.Domain.Validations;
using RockContent.Infra.Data.Repository;

namespace RockContent.WebApi
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddScoped<IArticleAppService, ArticleAppService>();
            services.AddAutoMapper(typeof(Mapping));

            services.AddControllers();
            services.AddCors();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TESTE ROCKCONTENT API", Version = "v1" });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            string swaggerUrl;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                swaggerUrl = "/swagger/v1/swagger.json";
            }
            else
            {
                app.UseDeveloperExceptionPage();
                swaggerUrl = "/api/swagger/v1/swagger.json";
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(swaggerUrl, "TESTE ROCKCONTENT API");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();
            app.UseCors(options =>
            {
                options
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
