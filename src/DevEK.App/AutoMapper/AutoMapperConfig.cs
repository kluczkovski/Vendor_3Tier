using System;
using AutoMapper;
using DevEK.App.ViewModels;
using DevEK.Business.Models;

namespace DevEK.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Vendor, VendorViewModel>().ReverseMap();
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Address, AddressViewModel>().ReverseMap();

        }
    }
}
