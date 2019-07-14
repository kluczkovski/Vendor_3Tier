using System;
using System.Threading.Tasks;
using DevEK.Business.Models;

namespace DevEK.Business.Interfaces
{
    public interface IAddressRepository : IRepository<Address>
    {
        Task<Address> GetAddressByVendor(Guid vendorId);
    }
}
