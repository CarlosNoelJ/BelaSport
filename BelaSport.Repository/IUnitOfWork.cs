using BelaSport.Models;

namespace BelaSport.Repository
{
    public interface IUnitOfWork
    {
        IRepository<EventTitle> EventTitle {get;}
        IRepository<EventType> EventType { get; }
        IRepository<Host> Host { get; }
    }
}
