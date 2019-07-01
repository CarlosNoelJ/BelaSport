using System;
using System.Collections.Generic;

namespace BelaSport.Models
{
    public partial class EventTitle
    {
        public int EventId { get; set; }
        public string NameEvent { get; set; }
        public int DniHost { get; set; }
        public int EventTypeId { get; set; }

        public virtual Host DniHostNavigation { get; set; }
        public virtual EventType EventType { get; set; }
    }
}
