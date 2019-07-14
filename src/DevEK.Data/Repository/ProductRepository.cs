using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevEK.Business.Interfaces;
using DevEK.Business.Models;
using DevEK.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevEK.Data.Repository
{
    public class ProductRepository : Repository<Product> , IProductRepository
    {
       
        public ProductRepository(AppDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Product>> GetAllProductAndVendor()
        {
            return await context.Products
                             .AsNoTracking()
                             .Include(v => v.Vendor)
                             .OrderBy(p => p.Name)
                             .ToListAsync();
        }

        public async  Task<Product> GetProductAndVendor(Guid id)
        {
            return await context.Products
                            .AsNoTracking()
                            .Include(v => v.Vendor)
                            .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Product>> GetProductByVendor(Guid vendorId)
        {
            return await context.Products
                             .AsNoTracking()
                             .Include(v => v.Vendor)
                             .Where(p => p.Vendor.Id == vendorId)
                             .ToListAsync();
        }
    }
}
