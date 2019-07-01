using BelaSport.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BelaSport.Repository.SqlServer
{
    public class HostRepository : Repository<Host>, IHostRepository
    {
        public HostRepository(BelaSportContext bsContext) : base(bsContext)
        {
        }
    }
}
