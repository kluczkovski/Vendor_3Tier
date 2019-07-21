using System;
using System.Threading.Tasks;
using DevEK.Business.Models;

namespace DevEK.Business.Services
{
    public interface IVendorService : IDisposable
    {
        Task Add(Vendor vendor);

        Task Update(Vendor vendor);

        Task Remove(Guid id);

        Task UpdateAddress(Address address);

    }
}