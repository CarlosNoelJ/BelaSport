using BelaSport.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BelaSport.Repository.SqlServer
{
    public class EventTitleRepository : Repository<EventTitle>, IEventTitle
    {
        public EventTitleRepository(BelaSportContext bsContext) : base(bsContext)
        {
        }
    }
}
