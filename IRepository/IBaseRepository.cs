using EfCoreBaseRepo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreBaseRepo.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAll(int count);

        IQueryable<TEntity> GetbyManyIds(int[] ids);

        Task<TEntity> GetByIdAsync(int id);

        Task CreateAsync(TEntity entity);

        Task CreateManyAsync(IEnumerable<TEntity> entities);

        void Update(int id, TEntity entity);

        void UpdateMany(IEnumerable<TEntity> entities);

        Task DeleteAsync(int id);

        void DeleteMany(IEnumerable<TEntity> entities);

        IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate);

        int ItemCount();

        TEntity GetLast();
    }


}
