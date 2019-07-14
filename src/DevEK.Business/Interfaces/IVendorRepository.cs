using System;
using System.Threading.Tasks;
using DevEK.Business.Models;

namespace DevEK.Business.Interfaces
{
    public interface IVendorRepository : IRepository<Vendor>
    {
        Task<Vendor> GetVendorAddress(Guid id);

        Task<Vendor> GetVendorProducsAddress(Guid id);
    }
}
