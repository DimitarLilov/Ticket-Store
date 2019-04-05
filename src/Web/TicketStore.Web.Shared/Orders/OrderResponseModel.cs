namespace TicketStore.Web.Shared.Orders
{
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Models;
    using TicketStore.Web.Shared.Tickets;
    using TicketStore.Web.Shared.Users;

    public class OrderResponseModel : IMapFrom<UserTickets>
    {
        public string ID { get; set; }

        public UserResponseModel User { get; set; }

        public TicketDetailsResponseModel Ticket { get; set; }

        public bool Active { get; set; }
    }
}
