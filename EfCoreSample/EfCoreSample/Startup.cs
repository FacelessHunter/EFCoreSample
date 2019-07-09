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

            app.UseMvc();
        }
    }
}
