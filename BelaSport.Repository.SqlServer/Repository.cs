using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelaSport.Repository.SqlServer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly BelaSportContext _bsContext;

        public Repository(BelaSportContext bsContext)
        {
            _bsContext = bsContext;
        }

        public async Task<int> Add(T entity)
        {
            await _bsContext.AddAsync(entity);
            return await _bsContext.SaveChangesAsync();
        }

        public async Task<bool> Delete(T entity)
        {
            _bsContext.Remove(entity);
            return await _bsContext.SaveChangesAsync()>0;
        }

        public async Task<IEnumerable<T>> GetList()
        {
            return await _bsContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<bool> Update(T entity)
        {
            _bsContext.Update(entity);
            return await _bsContext.SaveChangesAsync() > 0;
        }
    }
}
