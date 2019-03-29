namespace TicketStore.Web.Shared.Tickets
{
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Models;

    public class TicketResponseModel : IMapFrom<Ticket>, IMapFrom<TicketRequestModel>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
