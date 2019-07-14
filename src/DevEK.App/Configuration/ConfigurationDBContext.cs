using System;
using DevEK.App.Data;
using DevEK.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevEK.App.Configuration
{
    public static class ConfigurationDBContext
    {

        public static IServiceCollection SetupDBContext (this IServiceCollection services, IConfiguration configuration)
        {
            // Setup Identify Context - Identity Tables
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseMySql(configuration.GetConnectionString("DefaultConnection"), builder =>
               builder.MigrationsAssembly("DevEK.App")));

            services.AddDefaultIdentity<IdentityUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<ApplicationDbContext>();


            // Setup App Context - System Tables
            services.AddDbContext<AppDBContext>(options =>
                options.UseMySql(configuration.GetConnectionString("DefaultConnection"), builder =>
                builder.MigrationsAssembly(typeof(AppDBContext).Assembly.FullName)));


            return services;
        }
    }
}
