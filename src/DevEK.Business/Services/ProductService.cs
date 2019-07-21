using System;
using System.Threading.Tasks;
using DevEK.Business.Interfaces;
using DevEK.Business.Models;
using DevEK.Business.Models.Validations;

namespace DevEK.Business.Services
{
    public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, INotify notify) : base (notify)
        {
            _productRepository = productRepository; 
        }

        public async Task Add(Product product)
        {
            if (!RunValidation(new ProductValidation(), product)) return;

            await _productRepository.Insert(product);
        }

  
        public async Task Update(Product product)
        {
            if (!RunValidation(new ProductValidation(), product)) return;

            await _productRepository.Update(product);
        }

        public async Task Remove(Guid id)
        {
            await _productRepository.Delete(id);
        }

        public void Dispose()
        {
            _productRepository?.Dispose();
        }
    }
}
