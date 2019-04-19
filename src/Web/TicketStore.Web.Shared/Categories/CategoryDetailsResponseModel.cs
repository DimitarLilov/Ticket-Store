namespace TicketStore.Web.Shared.Categories
{
    using System.Collections.Generic;
    using TicketStore.Web.Shared.Events;

    public class CategoryDetailsResponseModel
    {
        public string Name { get; set; }

        public AllEventsResponseModel Events { get; set; }
    }
}
