using System;
using DevEK.Business.Interfaces;
using DevEK.Business.Notifications;
using DevEK.Business.Services;
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

            services.AddScoped<INotify, Notify>();
            services.AddScoped<IVendorService, VendorService>();
            services.AddScoped<IProductService, ProductService>();

            return services;
        }
    }
}
