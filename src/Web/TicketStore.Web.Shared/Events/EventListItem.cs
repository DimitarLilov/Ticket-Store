namespace TicketStore.Web.Shared.Events
{
    using System;
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Models;

    public class EventListItem : IMapFrom<Event>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public string Town { get; set; }

        public DateTime Date { get; set; }

        public string Image { get; set; }
    }
}
