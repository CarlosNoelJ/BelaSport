using System;
using System.Collections.Generic;

namespace BelaSport.Models
{
    public partial class EventType
    {
        public EventType()
        {
            EventTitle = new HashSet<EventTitle>();
        }

        public int EventTypeId { get; set; }
        public string NameEventType { get; set; }

        public virtual ICollection<EventTitle> EventTitle { get; set; }
    }
}
