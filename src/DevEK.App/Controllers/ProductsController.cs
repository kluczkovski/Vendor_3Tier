using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DevEK.App.ViewModels;
using DevEK.Business.Interfaces;
using DevEK.Business.Models;
using DevEK.Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DevEK.App.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IProductRepository _productRep;
        private readonly IVendorRepository _vendorRep;
        private readonly IMapper _mapper;

        public ProductsController(IProductRepository productRepository,
                                  IProductService productService,
                                  IMapper mapper,
                                  IVendorRepository vendorRepository, 
                                  INotify notify) : base(notify)
        {
            _productRep = productRepository;
            _productService = productService;
            _mapper = mapper;
            _vendorRep = vendorRepository;
        }


        // GET: List
        public async Task<IActionResult> Index()
        {
            var productsFromRep = await _productRep.GetAllProductAndVendor();
            var products = _mapper.Map<IEnumerable<ProductViewModel>>(productsFromRep);

            return View(products);
        }


        // Get: Detail
        public async Task<IActionResult> Details(Guid id)
        {
            var productViewModel = await ProductFromRepToViewModel(id);
            if (productViewModel == null)
            {
                return NotFound();
            }
            return View(productViewModel);
        }


        // Get: Create
        public async Task<IActionResult> Create()
        {
            var productViewModel = await ListOfVendor(new ProductViewModel());
            return View(productViewModel);
        }


        // Post: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel productViewModel)
        {

            if (!ModelState.IsValid)
            {
                productViewModel = await ListOfVendor(productViewModel);
                return View(productViewModel);
            }

            var imgPrefixo = Guid.NewGuid() + "_";
            if (! await UploadFile(productViewModel.ImageUpload, imgPrefixo))
            {
                productViewModel = await ListOfVendor(productViewModel);
                return View(productViewModel);
            }
            productViewModel.Image = imgPrefixo + productViewModel.ImageUpload.FileName;

            var product = _mapper.Map<Product>(productViewModel);
            await _productService.Add(product);
            if (!OperationIsValid())
            {
                return View(productViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

    
        // Get: Edit
        public async Task<IActionResult> Edit(Guid id)
        {
            var productViewModel = await ProductFromRepToViewModel(id);
            if (productViewModel == null)
            {
                return NotFound();
            }
            return View(productViewModel);
        }


        // Post: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ProductViewModel productViewModel)
        {
            if (id != productViewModel.Id) return NotFound();

            if (!ModelState.IsValid)
            {
                productViewModel = await ProductFromRepToViewModel(id);
                View(productViewModel);
            }

            if (productViewModel.ImageUpload != null)
            {
                DeleteUploadFile(productViewModel.Image);
                var imgPrefixo = Guid.NewGuid() + "_";
                if (!await UploadFile(productViewModel.ImageUpload, imgPrefixo))
                {
                    productViewModel = await ListOfVendor(productViewModel);
                    return View(productViewModel);
                }
                productViewModel.Image = imgPrefixo + productViewModel.ImageUpload.FileName;
            }
         

            var product = _mapper.Map<Product>(productViewModel);
            await _productService.Update(product);
            if (!OperationIsValid())
            {
                return View(productViewModel);
            }

            return RedirectToAction(nameof(Index));
        }

       


        // Get: Delete
        public async Task<IActionResult> Delete(Guid id)
        {
            var productView = await ProductFromRepToViewModel(id);
            if (productView == null)
            {
                return NotFound();
            }

            return View(productView);
        }


        // Post: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConFirmed(Guid id)
        {
            var productFromRepo = await ProductFromRepToViewModel(id);
            if (productFromRepo == null)
            {
                return NotFound();
            }
            DeleteUploadFile(productFromRepo.Image);
            await _productService.Remove(id);
            if (!OperationIsValid())
            {
                return View(productFromRepo);
            }

            TempData["Sucesso"] = "The Product was deleted.";
            return RedirectToAction(nameof(Index));
        }


        // Mapper Product To ViewModel
        private async Task<ProductViewModel> ProductFromRepToViewModel(Guid id)
        {
            var productFromRep = await _productRep.GetProductAndVendor(id);
            ProductViewModel productViewModel = _mapper.Map<ProductViewModel>(productFromRep);
            return await ListOfVendor(productViewModel); 
        }


        // Get All Vendor
        private async Task<ProductViewModel> ListOfVendor(ProductViewModel productViewModel)
        {
            var vendors = await _vendorRep.GetList();
            productViewModel.Vendors = _mapper.Map<IEnumerable<VendorViewModel>>(vendors);
            return productViewModel;
        }


        // Write image in the image folder
        private async Task<bool> UploadFile(IFormFile imageUpload, string imgPrefixo)
        {
            if (imageUpload.Length <= 0)
            {
                ModelState.AddModelError(string.Empty, "You must inform one image");
                return false;
            }

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imgPrefixo + imageUpload.FileName);
            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "The file already exist with this name");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imageUpload.CopyToAsync(stream);
            }

            return true;
        }


        // Delete Image Uploaded
        private void DeleteUploadFile(string image)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", image);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }

    }
}
