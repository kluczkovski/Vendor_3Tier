using System;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;

namespace DevEK.App.Configuration
{
    public static class ConfigurationAutoMapper
    {
        public static IServiceCollection SetupAutomapper (this IServiceCollection services)
        {
            // Setup below, the AutMappar will find which assembly belong to Startup, and will find for any class that implemented the Profile
            services.AddAutoMapper(typeof(Startup));
            return services;
        }
    }
}
