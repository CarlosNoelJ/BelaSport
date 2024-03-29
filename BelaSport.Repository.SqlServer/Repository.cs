﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BelaSport.Repository.SqlServer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly BelaSportContext _bsContext;

        public Repository(BelaSportContext bsContext)
        {
            _bsContext = bsContext;
        }

        public T GetById(int id)
        {
            return _bsContext.Find<T>(id);
        }

        int IRepository<T>.Add(T entity)
        {
            _bsContext.Add(entity);
            return _bsContext.SaveChanges();
        }

        int IRepository<T>.Delete(T entity)
        {
            _bsContext.Remove(entity);
            return _bsContext.SaveChanges();
        }

        IEnumerable<T> IRepository<T>.GetList()
        {
            return _bsContext.Set<T>().AsNoTracking().ToList();
        }

        int IRepository<T>.Update(T entity)
        {
            _bsContext.Update(entity);
            return _bsContext.SaveChanges();
        }
    }
}
