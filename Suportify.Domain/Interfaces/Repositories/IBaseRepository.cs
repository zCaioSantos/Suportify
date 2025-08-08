using System.Linq.Expressions;

namespace Suportify.Domain.Interfaces.Repositories
{
    public partial interface IBaseRepository<T> where T : class
    {
        Task<T> Create(T entity);
        Task Delete(T entity);
        Task<TEntity?> Get<TEntity, TKey>(List<string>? includes = null, Expression<Func<TEntity, bool>>? where = null, Expression<Func<TEntity, TKey>>? orderBy = null) where TEntity : class;
        Task<List<TEntity>?> GetAll<TEntity, TKey>(List<string>? includes = null, Expression<Func<TEntity, bool>>? where = null, Expression<Func<TEntity, TKey>>? orderBy = null) where TEntity : class;
        Task<T> Update(T entity);
    }
}
