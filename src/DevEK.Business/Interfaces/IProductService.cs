using System;
using System.Threading.Tasks;
using DevEK.Business.Models;

namespace DevEK.Business.Services
{
    public interface IProductService : IDisposable
    {
        Task Add(Product product);

        Task Update(Product product);

        Task Remove(Guid id);
 
    }
}