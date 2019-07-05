using System.Collections.Generic;

namespace BelaSport.Models
{
    public partial class Host
    {
        public Host()
        {
            EventTitle = new HashSet<EventTitle>();
        }

        public int DniHost { get; set; }
        public string NameHost { get; set; }
        public string LastNameHost { get; set; }
        public string PasswordHost { get; set; }

        public virtual ICollection<EventTitle> EventTitle { get; set; }
    }
}
