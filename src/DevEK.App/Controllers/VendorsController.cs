using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DevEK.App.Extensions;
using DevEK.App.ViewModels;
using DevEK.Business.Interfaces;
using DevEK.Business.Models;
using DevEK.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevEK.App.Controllers
{
    [Authorize]
    public class VendorsController : BaseController
    {
        private readonly IVendorRepository _vendorRep;
        private readonly IVendorService _vendorService;
        private readonly IMapper _mapper;

        public VendorsController(IVendorRepository vendorRepository,
                                 IVendorService vendorService,
                                 IMapper mapper,
                                 INotify notify) :base(notify)
        {
            _vendorRep = vendorRepository;
            _vendorService = vendorService;
            _mapper = mapper;
        }


        // GET: List
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var vendorsFromRep = await _vendorRep.GetList();
            var vendors = _mapper.Map<IEnumerable<VendorViewModel>>(vendorsFromRep);

            return View(vendors);
        }


        // Get: Detail
        [AllowAnonymous]
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
        [ClaimsAuthorize("Vendor","Add")]
        public IActionResult Create()
        {
            return View();
        }

        // Post: Create
        [ClaimsAuthorize("Vendor", "Add")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VendorViewModel vendorView)
        {
            if (!ModelState.IsValid) return View(vendorView);

            var vendor = _mapper.Map<Vendor>(vendorView);

            await _vendorService.Add(vendor);
            if (!OperationIsValid())
            {
                return View(vendorView);
            }
            return RedirectToAction(nameof(Index));
        }


        // Get: Edit
        [ClaimsAuthorize("Vendor", "Edit")]
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
        [ClaimsAuthorize("Vendor", "Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, VendorViewModel vendorViewModel)
        {
            if (id != vendorViewModel.Id) return NotFound();


            if (!ModelState.IsValid) return View(vendorViewModel);


            var vendor = _mapper.Map<Vendor>(vendorViewModel);
            await _vendorService.Update(vendor);
            if (!OperationIsValid())
            {
                return View(vendorViewModel);
            }
            return RedirectToAction(nameof(Index));
        }


        // Get: Delete
        [ClaimsAuthorize("Vendor", "Delete")]
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
        [ClaimsAuthorize("Vendor", "Delete")]
        public async Task<IActionResult> DeleteConFirmed(Guid id)
        {
            var vendorFromRepo = await VendorFromRepToViewModel(id);
            if (vendorFromRepo == null)
            {
                return NotFound();
            }
            await _vendorService.Remove(id);
            if (!OperationIsValid())
            {
                return View(vendorFromRepo);
            }
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

            await _vendorService.UpdateAddress(_mapper.Map<Address>(vendorView.Address));

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
