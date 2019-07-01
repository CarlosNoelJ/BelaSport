using System;
using System.Collections.Generic;
using System.Text;
using BelaSport.Models;

namespace BelaSport.Repository.SqlServer
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<EventTitle> EventTitle { get; }

        public IRepository<Host> Host { get; }

        public IRepository<EventType> EventType { get; }
    }
}
