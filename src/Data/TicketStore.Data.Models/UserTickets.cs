using TicketStore.Data.Common.Models;

namespace TicketStore.Data.Models
{
    public class UserTickets : BaseModel<string> 
    {
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string TicketId { get; set; }

        public Ticket Ticket { get; set; }


    }
}
