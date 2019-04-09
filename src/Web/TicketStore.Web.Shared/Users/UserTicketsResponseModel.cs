namespace TicketStore.Web.Shared.Users
{
    using System.Collections.Generic;
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Models;
    using TicketStore.Web.Shared.Tickets;

    public class UserTicketsResponseModel : IMapFrom<UserTickets>
    {
        public string Id { get; set; }

        public UserNameResponseModel User { get; set; }

        public BaseTicketResponseModel Ticket { get; set; }
    }
}
