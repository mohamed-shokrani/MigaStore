using Microsoft.EntityFrameworkCore;
using SharedProject.Data;
using SharedProject.Interfaces;
using System.Linq.Expressions;

namespace SharedProject.DataAccess;
public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    protected AppDbContext _context;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<IReadOnlyCollection<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await _context.Set<TEntity>().Where(predicate).ToListAsync();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await _context.Set<TEntity>().AddRangeAsync(entities);
        await _context.SaveChangesAsync();
        return entities;
    }

    public async Task RemoveAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
    {
        _context.Set<TEntity>().RemoveRange(entities);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> criteria, params Expression<Func<TEntity, object>>[] includes)
    {
        throw new NotImplementedException();
    }

    public IQueryable<TEntity> GetById(Expression<Func<TEntity, bool>> criteria, params Expression<Func<TEntity, object>>[] includes)
    {
        throw new NotImplementedException();
    }
}
