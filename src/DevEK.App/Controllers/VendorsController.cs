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
        private readonly IMapper _mapper;

        public VendorsController(IVendorRepository vendorRepository,
                                 IMapper mapper)
        {
            _vendorRep = vendorRepository;
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


        // Mapper Vendor To ViewModel
        private async Task<VendorViewModel> VendorFromRepToViewModel(Guid id)
        {
            var vendorFromRep = await _vendorRep.GetVendorAddress(id);
            return _mapper.Map<VendorViewModel>(vendorFromRep);
        }


    }
}
