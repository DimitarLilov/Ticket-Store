namespace TicketStore.Web.Shared.Events
{
    using System;
    using System.Collections.Generic;
    using TicketStore.Web.Shared.Categories;
    using TicketStore.Web.Shared.Tickets;

    public class EventDetailsResponseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public string Town { get; set; }

        public DateTime Date { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public CategoryResponseModel Category { get; set; }

        public IEnumerable<TicketResponseModel> Tickets { get; set; }
    }
}
