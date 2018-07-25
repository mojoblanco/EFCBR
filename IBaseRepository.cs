using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EfCoreBaseRepo
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAll(int count);

        IQueryable<TEntity> GetbyManyIds(int[] ids);

        TEntity GetById(int id);

        Task<TEntity> GetByIdAsync(int id);

        TEntity Create(TEntity entity);

        Task<TEntity> CreateAsync(TEntity entity);

        void Create(IEnumerable<TEntity> entities);

        Task CreateManyAsync(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);

        void UpdateMany(IEnumerable<TEntity> entities);

        Task DeleteAsync(int id);

        void DeleteMany(IEnumerable<TEntity> entities);

        IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate);

        int ItemCount();

        TEntity GetLast();
    }


}
