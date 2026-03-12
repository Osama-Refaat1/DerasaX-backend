using DerasaX.Domain.Entities.Base;
using DerasaX.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Domain.Interfaces.RepositoriesInterfaces
{
    public interface IGenericRepository<TEntity,TKey> where TEntity:BaseEntity<TKey>
    {
        Task<TEntity> GetByIdAsync(TKey id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        //specification methods
        Task<IEnumerable<TEntity>> GetAllWithSpecAsync(ISpecification<TEntity, TKey> specification);
        Task<TEntity> GetByIdWithSpecAsync(ISpecification<TEntity, TKey> specification);
        Task<int> CountAsync(ISpecification<TEntity, TKey> specification);
    }
}
