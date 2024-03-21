using System.Linq.Expressions;

namespace SharedProject.Interfaces;
public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetByIdAsync(int id);
    Task<IReadOnlyCollection<TEntity>> GetAllAsync();
    Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> AddAsync(TEntity entity);
    Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
    Task RemoveAsync(TEntity entity);
    Task RemoveRangeAsync(IEnumerable<TEntity> entities);
    Task UpdateAsync(TEntity entity);
    IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> criteria, params Expression<Func<TEntity, object>>[] includes);
    IQueryable<TEntity> GetById(Expression<Func<TEntity, bool>> criteria, params Expression<Func<TEntity, object>>[] includes);

}
