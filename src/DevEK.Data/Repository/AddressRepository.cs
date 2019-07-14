using System;
using System.Linq;
using System.Threading.Tasks;
using DevEK.Business.Interfaces;
using DevEK.Business.Models;
using DevEK.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevEK.Data.Repository
{
    public class AddressRepository : Repository<Address> , IAddressRepository
    {
        public AddressRepository(AppDBContext context) :base (context)
        {
        }

        public async Task<Address> GetAddressByVendor(Guid vendorId)
        {
            return await context.Addresses
                            .AsNoTracking()
                            .Include(v => v.Vendor)
                            .Where(a => a.Vendor.Id == vendorId)
                            .FirstOrDefaultAsync();
        }
    }
}
