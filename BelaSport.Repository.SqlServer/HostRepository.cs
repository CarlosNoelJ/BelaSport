using BelaSport.Models;

namespace BelaSport.Repository.SqlServer
{
    public class HostRepository : Repository<Host>, IHostRepository
    {
        public HostRepository(BelaSportContext bsContext) : base(bsContext)
        {
        }
    }
}
