using EfCoreBaseRepo.Entities;
using EfCoreBaseRepo.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreBaseRepo.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking()
                    .OrderByDescending(x => x.CreatedAt);
        }

        public IQueryable<TEntity> GetAll(int count)
        {
            return _context.Set<TEntity>().AsNoTracking()
                   .OrderByDescending(x => x.CreatedAt)
                   .Take(count);
        }

        public IQueryable<TEntity> GetbyManyIds(int[] ids)
        {
            return from x in _context.Set<TEntity>()
                   where ids.Contains(x.Id)
                   select x;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task CreateAsync(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task CreateManyAsync(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                item.CreatedAt = DateTime.Now;
            }

            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public void Update(int id, TEntity entity)
        {
            entity.UpdatedAt = DateTime.Now;

            _context.Set<TEntity>().Update(entity);
        }

        public void UpdateMany(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                item.UpdatedAt = DateTime.Now;
            }

            _context.Set<TEntity>().UpdateRange(entities);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            _context.Set<TEntity>().Remove(entity);
        }

        public void DeleteMany(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }

        public IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public int ItemCount()
        {
            return _context.Set<TEntity>().Count();
        }

        public TEntity GetLast()
        {
            return _context.Set<TEntity>().OrderByDescending(x => x.CreatedAt).FirstOrDefault();
        }
    }

}
