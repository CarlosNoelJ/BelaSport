using BelaSport.Models;

namespace BelaSport.Repository.SqlServer
{
    public class EventTitleRepository : Repository<EventTitle>, IEventTitleRepository
    {
        public EventTitleRepository(BelaSportContext bsContext) : base(bsContext)
        {
        }
    }
}
