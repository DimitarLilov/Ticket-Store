namespace TicketStore.Web.Shared.Tickets
{
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Models;
    using TicketStore.Web.Shared.Events;

    public class BaseTicketResponseModel : IMapFrom<Ticket>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public EventResponseModel Event { get; set; }
    }
}
