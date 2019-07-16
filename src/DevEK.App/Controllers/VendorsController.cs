using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DevEK.App.ViewModels;
using DevEK.Business.Interfaces;
using DevEK.Business.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevEK.App.Controllers
{
    public class VendorsController : BaseController
    {
        private readonly IVendorRepository _vendorRep;
        private readonly IAddressRepository _addressRep;
        private readonly IMapper _mapper;

        public VendorsController(IVendorRepository vendorRepository,
                                 IAddressRepository addressRepository,
                                 IMapper mapper)
        {
            _vendorRep = vendorRepository;
            _addressRep = addressRepository;
            _mapper = mapper;
        }


        // GET: List
        public async Task<IActionResult> Index()
        {
            var vendorsFromRep = await _vendorRep.GetList();
            var vendors = _mapper.Map<IEnumerable<VendorViewModel>>(vendorsFromRep);

            return View(vendors);
        }


        // Get: Detail
        public async Task<IActionResult> Details(Guid id)
        {
            var vendorViewModel = await VendorFromRepToViewModel(id);
            if (vendorViewModel == null)
            {
                return NotFound();
            }
            return View(vendorViewModel);
        }


        // Get: Create
        public IActionResult Create()
        {
            return View();
        }

        // Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VendorViewModel vendorView)
        {
            if (!ModelState.IsValid) return View(vendorView);

            var vendor = _mapper.Map<Vendor>(vendorView);
            await _vendorRep.Insert(vendor);
            await _vendorRep.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        // Get: Edit
        public async Task<IActionResult> Edit(Guid id)
        {
            var vendorAllInformationFromRep = await _vendorRep.GetVendorProducsAddress(id);
            var vendorViewModel = _mapper.Map<VendorViewModel>(vendorAllInformationFromRep);
            if (vendorViewModel == null)
            {
                return NotFound();
            }
            return View(vendorViewModel);
        }


        // Post: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, VendorViewModel vendorViewModel)
        {
            if (id != vendorViewModel.Id) return NotFound();


            if (!ModelState.IsValid) return View(vendorViewModel);


            var vendor = _mapper.Map<Vendor>(vendorViewModel);
            await _vendorRep.Update(vendor);
            await _vendorRep.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        // Get: Delete
        public async Task<IActionResult> Delete(Guid id)
        {
            var vendorViewModel = await VendorFromRepToViewModel(id);
            if (vendorViewModel == null)
            {
                return NotFound();
            }

            return View(vendorViewModel);
        }


        // Post: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConFirmed(Guid id)
        {
            var vendorFromRepo = await _vendorRep.GetById(id);
            if (vendorFromRepo == null)
            {
                return NotFound();
            }
            await _vendorRep.Delete(id);
            await _vendorRep.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        // Get: UpdateAddress
        public async Task<IActionResult> UpdateAddress(Guid id)
        {
            var vendor = await VendorFromRepToViewModel(id);
            if (vendor == null) return NotFound();

            return PartialView("_AddressUpdate", new VendorViewModel { Address = vendor.Address });
        }


        // Post: UpdateAddres
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAddress(VendorViewModel vendorView)
        {
            ModelState.Remove("Name");
            ModelState.Remove("IdentifiyDocument");
            if (!ModelState.IsValid)
            {
                return PartialView("_AddressUpdate", new VendorViewModel { Address = vendorView.Address });
            }

            await _addressRep.Update(_mapper.Map<Address>(vendorView.Address));

            var url = Url.Action("GetAddress", "Vendors", new { id = vendorView.Address.VendorId });
            return Json(new { success = true, url}); 
        }


        // Mapper Vendor To ViewModel
        private async Task<VendorViewModel> VendorFromRepToViewModel(Guid id)
        {
            var vendorFromRep = await _vendorRep.GetVendorProducsAddress(id);
            return _mapper.Map<VendorViewModel>(vendorFromRep);
        }


        // Get Address
        public async Task<IActionResult> GetAddress(Guid id)
        {
            var vendor = await VendorFromRepToViewModel(id);
            return PartialView("_AddressDetails", new VendorViewModel { Address = vendor.Address });
        }
    }
}
