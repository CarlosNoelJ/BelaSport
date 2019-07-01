using System.Collections.Generic;
using System.Threading.Tasks;

namespace BelaSport.Repository
{
    public interface IRepository<T> where T:class
    {
        Task<int> Add(T entity);
        Task<IEnumerable<T>> GetList();
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
    }
}
