using BelaSport.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BelaSport.Repository.SqlServer
{
    public class EventTypeRepository: Repository<EventType>, IEventTypeRepository
    {
        public EventTypeRepository(BelaSportContext bsContext) : base(bsContext)
        {
        }
    }
}
