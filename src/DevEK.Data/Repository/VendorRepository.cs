using System;
using System.Threading.Tasks;
using DevEK.Business.Interfaces;
using DevEK.Business.Models;
using DevEK.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevEK.Data.Repository
{
    public class VendorRepository : Repository<Vendor> , IVendorRepository
    {
        public VendorRepository(AppDBContext context) : base(context)
        {
        }

        public async Task<Vendor> GetVendorAddress(Guid id)
        {
            return await context.Vendors
                            .AsNoTracking()
                            .Include(a => a.Address)
                            .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<Vendor> GetVendorProducsAddress(Guid id)
        {
            return await context.Vendors
                            .AsNoTracking()
                            .Include(a => a.Address)
                            .Include(p => p.Products)
                            .FirstOrDefaultAsync(v => v.Id == id);
        }
    }
}
