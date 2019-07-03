using BelaSport.Repository;
using BelaSport.Repository.SqlServer;
using BelaSport.WebApi.ApiConventions;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

[assembly: ApiConventionType(typeof(BelaSportApiConventions))]
namespace BelaSport.WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddFluentValidation();

            services.AddTransient(option => new BelaSportContext(new DbContextOptionsBuilder<BelaSportContext>().UseSqlServer(Configuration.GetConnectionString("BelaSport")).Options));

            services.AddEntityFrameworkSqlServer()
               .AddDbContextPool<BelaSportContext>(
                opt => opt.UseSqlServer(Configuration.GetConnectionString("BelaSport"),
                b => b.MigrationsAssembly("BelaSport.WebApi")))
               .BuildServiceProvider();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddSwaggerGen(c =>{
                c.SwaggerDoc("v1", new OpenApiInfo{
                    Title = "BelaSport API",
                    Version = "v1"
                });
                c.CustomSchemaIds(x => x.FullName);
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BelaSport API v1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
