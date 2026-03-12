using DerasaX.Domain.Entities.Base;
using DerasaX.Domain.Interfaces.RepositoriesInterfaces;
using DerasaX.Domain.Specification;
using DerasaX.Infrastructure.DbHelper.Context;
using DerasaX.Infrastructure.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Infrastructure.Repositories
{
    public class GenericRepository<TEntity,TKey>:IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly DerasaXDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(DerasaXDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task AddAsync(TEntity entity) => await _dbSet.AddAsync(entity);
        public async Task AddRangeAsync(IEnumerable<TEntity> entities) => await _dbSet.AddRangeAsync(entities);
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(TKey id) => await _dbSet.FindAsync(id);
        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(TEntity entity)
        {
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }
        // Specification methods
        public async Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecification<TEntity, TKey> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }
        public async Task<TEntity> GetByIdWithSpecAsync(ISpecification<TEntity, TKey> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }
        public async Task<int> CountAsync(ISpecification<TEntity, TKey> specification)
        {
            return await ApplySpecification(specification).CountAsync();
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity, TKey> specification)
        {
            return SpecificationEvaluator<TEntity, TKey>.GetQuery(_dbSet.AsQueryable(), specification);
        }
    }
}
