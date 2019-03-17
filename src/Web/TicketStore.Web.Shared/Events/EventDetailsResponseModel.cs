namespace TicketStore.Web.Shared.Events
{
    using System;

    public class EventDetailsResponseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public string Town { get; set; }

        public DateTime Date { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
    }
}
