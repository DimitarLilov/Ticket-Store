namespace TicketStore.Data.Models
{
    using System;
    using TicketStore.Data.Common.Models;

    public class UserTickets : BaseModel<string>
    {
        public UserTickets()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int TicketId { get; set; }

        public virtual Ticket Ticket { get; set; }

        public bool Active { get; set; }
    }
}
