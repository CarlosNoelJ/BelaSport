using BelaSport.Models;
using BelaSport.Models.ApplicationSettings;
using BelaSport.Models.FluentValidator;
using BelaSport.Repository;
using BelaSport.Repository.SqlServer;
using BelaSport.WebApi.ApiConventions;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

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
            // INject AppSettings
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddTransient(option => new BelaSportContext(new DbContextOptionsBuilder<BelaSportContext>().UseSqlServer(Configuration.GetConnectionString("BelaSport")).Options));

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<BelaSportContext>();


            // Validator
            services.AddTransient<IValidator<Host>, HostValidator>();
            services.AddTransient<IValidator<EventType>,EventTypeValidator>();

            services.AddCors();

            services.AddSwaggerGen(c =>{
                c.SwaggerDoc("v1", new OpenApiInfo{
                    Title = "BelaSport API",
                    Version = "v1"
                });
                c.CustomSchemaIds(x => x.FullName);
            });

            // JWT

            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());

            services.AddAuthentication(x =>{
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>{
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
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

            app.UseAuthentication();

            app.UseCors(builder => 
            builder.WithOrigins(Configuration["ApplicationSettings:Client_URL"].ToString())
            .AllowAnyHeader()
            .AllowAnyMethod());

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BelaSport API v1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
