using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DevEK.Business.Interfaces;
using DevEK.Business.Models;
using DevEK.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevEK.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly AppDBContext context;
        protected readonly DbSet<TEntity> dbSet;

        public Repository(AppDBContext Context)
        {
            context = Context;
            dbSet = context.Set<TEntity>();
        }

        // Virtual-> allowed to override the method
        public virtual async Task Insert(TEntity entity)
        {
            // without DBSET
            //context.Set<TEntity>().Add(entity);
            dbSet.Add(entity);
            await SaveChanges();
            
        }

        public virtual async Task Update(TEntity entity)
        {
            dbSet.Update(entity);
            await SaveChanges();
        }


        public virtual async Task Delete(Guid id)
        {
            var entity = await GetById(id);

            dbSet.Remove(entity);
            await SaveChanges();
        }


        public async Task<int> SaveChanges()
        {
            return await context.SaveChangesAsync();
        }


        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> GetList()
        {
            return await dbSet.ToListAsync();
        }

     
        public virtual async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

 
        public void Dispose()
        {
            context?.Dispose();
        }

    }
}
