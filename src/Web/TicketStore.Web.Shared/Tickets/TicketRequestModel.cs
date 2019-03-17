namespace TicketStore.Web.Shared.Tickets
{
    public class TicketRequestModel
    {
        public string Id { get; set; }

        public string PriceCategory { get; set; }

        public decimal Price { get; set; }
    }
}
