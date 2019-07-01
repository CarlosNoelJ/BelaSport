using BelaSport.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BelaSport.Repository.SqlServer
{
    public class EventTitleRepository : Repository<EventTitle>, IEventTitleRepository
    {
        public EventTitleRepository(BelaSportContext bsContext) : base(bsContext)
        {
        }
    }
}
