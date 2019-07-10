using EfCoreSample.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EfCoreSample.Services;
using EfCoreSample.Infrastructure.Abstraction;
using EfCoreSample.Infrastructure;
using EfCoreSample.Doman;
using FluentValidation.AspNetCore;
using EfCoreSample.Filters;
using Microsoft.OpenApi.Models;
using System;
using System.Reflection;
using System.IO;

namespace EfCoreSample
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

            services.AddMvc(opt =>
            {
                opt.Filters.Add(typeof(ValidatorActionFilter));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "EfCoreSample",
                    Description = "EfCoreSample WebAPI",

                    Contact = new OpenApiContact
                    {
                        Name = "Maltsev Vitalii",
                        Email = "zoro.130898@gmail.com",
                       
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",

                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });


            services.AddTransient<IProjectService, ProjectService>();
            services.AddTransient<IRepository<Project,long>,ProjectRepository>();

            services.AddDbContext<EfCoreSampleDbContext>(options => options.UseMySql(Configuration.GetConnectionString("LocalConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EfCoreSample V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
