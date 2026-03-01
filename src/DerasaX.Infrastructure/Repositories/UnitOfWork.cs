using DerasaX.Domain.Entities.Base;
using DerasaX.Domain.Interfaces;
using DerasaX.Domain.Interfaces.RepositoriesInterfaces;
using DerasaX.Infrastructure.DbHelper.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DerasaX.Infrastructure.Repositories
{
    public class UnitOfWork :IUnitOfWork
    {
        private readonly DerasaXDbContext _context;
        private readonly Hashtable _repositories = new Hashtable();
        public UnitOfWork(DerasaXDbContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }
        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var type = typeof(TEntity).Name;
            if (!_repositories.ContainsKey(type))
            {
                var repository = new GenericRepository<TEntity, TKey>(_context);
                _repositories.Add(type, repository);
            }
            return (IGenericRepository<TEntity, TKey>)_repositories[type];

        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
