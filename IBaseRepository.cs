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

        void Create(TEntity entity);

        Task CreateAsync(TEntity entity);

        Task CreateManyAsync(IEnumerable<TEntity> entities);

        void Update(int id, TEntity entity);

        void UpdateMany(IEnumerable<TEntity> entities);

        Task DeleteAsync(int id);

        void DeleteMany(IEnumerable<TEntity> entities);

        IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate);

        int ItemCount();

        int ItemCount(Expression<Func<TEntity, bool>> predicate);

        bool ItemCheck();

        bool ItemCheck(Expression<Func<TEntity, bool>> predicate);

        TEntity GetLast();
    }


}
