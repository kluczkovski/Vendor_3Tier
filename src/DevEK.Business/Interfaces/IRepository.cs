using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DevEK.Business.Models;

namespace DevEK.Business.Interfaces
{
    // IDisposable, free the memory after used it
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Insert(TEntity entity);

        Task<TEntity> GetById(Guid id);

        Task<List<TEntity>> GetList();

        Task Update(TEntity entity);

        Task Delete(Guid id);

        Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate);

        Task<int> SaveChanges();
    }
}
