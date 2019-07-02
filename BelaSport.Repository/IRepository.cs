using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelaSport.Repository
{
    public interface IRepository<T> where T:class
    {
        int Add(T entity);
        IEnumerable<T> GetList();
        int Update(T entity);
        int Delete(T entity);
        T GetById(int id);
    }
}
