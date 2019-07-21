using System;
using System.Linq;
using System.Threading.Tasks;
using DevEK.Business.Interfaces;
using DevEK.Business.Models;
using DevEK.Business.Models.Validations;


namespace DevEK.Business.Services
{
    public class VendorService : BaseService, IVendorService
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IAddressRepository _addressRepository;

        public VendorService(IVendorRepository vendorRepository, IAddressRepository addressRepository, INotify notify) : base(notify)
        {
            _vendorRepository = vendorRepository;
            _addressRepository = addressRepository;
        }

        public async Task Add(Vendor vendor)
        {
            if (!RunValidation(new VendorValidation(), vendor)
                || !RunValidation(new AddressValidation(), vendor.Address)) return;

            if (_vendorRepository.Search(v => v.IdentifiyDocument == vendor.IdentifiyDocument).Result.Any())
            {
                Notification("Identify Document already exits for another Vendor!.");
                return;
            }

            await _vendorRepository.Insert(vendor);
        }

     
        public async Task Remove(Guid id)
        {
            if (_vendorRepository.GetVendorProducsAddress(id).Result.Products.Any())
            {
                Notification("The Vendor has Products linked to its");
                return;
            }
            await _vendorRepository.Delete(id);
        }

        public async Task Update(Vendor vendor)
        {
            if (!RunValidation(new VendorValidation(), vendor)) return;

            if (_vendorRepository.Search(v => v.IdentifiyDocument == vendor.IdentifiyDocument && v.Id != vendor.Id).Result.Any())
            {
                Notification("Identify Document already exits for another Vendor!.");
                return;
            }

            await _vendorRepository.Update(vendor);
        }

        public async Task UpdateAddress(Address address)
        {
            if (!RunValidation(new AddressValidation(), address)) return;
            await _addressRepository.Update(address);
        }


        public void Dispose()
        {
            _vendorRepository?.Dispose();
            _addressRepository?.Dispose();
        }
    }
}
