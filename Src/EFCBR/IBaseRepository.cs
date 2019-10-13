using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EFCBR
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        TEntity Get(string id);
        IEnumerable<TEntity> GetAll();
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        bool IsEmpty();
        bool IsEmpty(Expression<Func<TEntity, bool>> predicate);
    }


}
