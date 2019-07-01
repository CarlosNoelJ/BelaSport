using BelaSport.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BelaSport.Repository
{
    public interface IUnitOfWork
    {
        IRepository<EventTitle> EventTitle {get;}
        IRepository<EventType> EventType { get; }
        IRepository<Host> Host { get; }
    }
}
