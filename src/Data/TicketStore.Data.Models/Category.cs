namespace TicketStore.Data.Models
{
    using System.Collections.Generic;
    using TicketStore.Data.Common.Models;

    public class Category : BaseModel<string>
    {
        public Category()
        {
            this.Events = new HashSet<Event>();
        }
        public string Name { get; set; }

        public virtual ICollection<Event> Events { get; set; }
    }
}
