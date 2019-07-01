using BelaSport.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BelaSport.Repository
{
    public interface IUnitOfWork
    {
        IRepository<EventTitle> EventTitle {get;}
        IRepository<EventHandler> EventHandler { get; }
        IRepository<Host> Host { get; }
    }
}
