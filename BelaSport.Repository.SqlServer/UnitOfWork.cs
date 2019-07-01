using System;
using System.Collections.Generic;
using System.Text;
using BelaSport.Models;

namespace BelaSport.Repository.SqlServer
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(BelaSportContext bsContext)
        {
            EventType = new Repository<EventType>(bsContext);
            EventTitle = new Repository<EventTitle>(bsContext);
            Host = new Repository<Host>(bsContext);
        }

        public IRepository<EventTitle> EventTitle { get; }

        public IRepository<Host> Host { get; }

        public IRepository<EventType> EventType { get; }
    }
}
