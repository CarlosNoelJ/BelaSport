using BelaSport.Models;

namespace BelaSport.Repository.SqlServer
{
    public class EventTypeRepository: Repository<EventType>, IEventTypeRepository
    {
        public EventTypeRepository(BelaSportContext bsContext) : base(bsContext)
        {
        }
    }
}
