using Microsoft.EntityFrameworkCore;
using Suportify.Domain.Interfaces.Repositories;
using System.Linq.Expressions;
using Suportify.Infra.Data.EFCore.Context;

namespace Suportify.Infra.Data.EFCore.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly EFContext _context;



        public BaseRepository(EFContext context)
        {
            _context = context;
        }



        public async Task<T> Create(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }


        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }


        public async Task<TEntity?> Get<TEntity, TKey>(List<string>? includes = null, Expression<Func<TEntity, bool>>? where = null, Expression<Func<TEntity, TKey>>? orderBy = null) where TEntity : class
        {
            var collection = _context.Set<TEntity>().AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    collection = collection.Include(include);
                }
            }

            if (where != null)
                collection = collection.Where(where).AsQueryable();

            if (orderBy != null)
                collection = collection.OrderBy(orderBy).AsQueryable();


            return await collection.FirstOrDefaultAsync();
        }


        public async Task<List<TEntity>?> GetAll<TEntity, TKey>(List<string>? includes = null, Expression<Func<TEntity, bool>>? where = null, Expression<Func<TEntity, TKey>>? orderBy = null) where TEntity : class
        {
            var collection = _context.Set<TEntity>().AsQueryable();

            if (includes != null)
            {
                foreach (var include in includes)
                {
                    collection = collection.Include(include);
                }
            }

            if (where != null)
                collection = collection.Where(where).AsQueryable();

            if (orderBy != null)
                collection = collection.OrderBy(orderBy).AsQueryable();


            return await collection.ToListAsync();
        }


        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();

            return entity;
        }


    }
}
