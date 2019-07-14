using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevEK.Business.Models;

namespace DevEK.Business.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductByVendor(Guid vendorId);

        Task<IEnumerable<Product>> GetAllProductAndVendor();

        Task<Product> GetProductAndVendor(Guid id);

    }
}
