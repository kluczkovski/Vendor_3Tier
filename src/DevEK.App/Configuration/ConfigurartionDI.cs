using System;
using DevEK.Business.Interfaces;
using DevEK.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DevEK.App.Configuration
{
    public static class ConfigurartionDI
    {
        public static IServiceCollection SetupDI (this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IVendorRepository, VendorRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            return services;
        }
    }
}
