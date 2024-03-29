using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchExample.Domain.MappingProfiles;
using CleanArchExample.IoC;
using CleanArchExample.Repository.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CleanArchExample.Api
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
            services.AddDbContext<ApplicationDBContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));
            RegisterServices(services);
            RegisterAutoMapper(services);
            services.AddSwaggerGen(a =>
            {
                a.SwaggerDoc("V1", new Microsoft.OpenApi.Models.OpenApiInfo { Title="Clean Arch Example", Version="V1" });
                a.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwagger();
            app.UseSwaggerUI(s => {
                
                s.SwaggerEndpoint("../swagger/v1/swagger.json", "MySite");
               
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();        



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }

        public static void RegisterAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(CleanArchExample.Domain.MappingProfiles.AutoMapperConfiguration));
            AutoMapperConfiguration.RegisterMapping();
        }
    }
}
