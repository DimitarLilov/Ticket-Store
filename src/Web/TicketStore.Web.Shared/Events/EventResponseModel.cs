namespace TicketStore.Web.Shared.Events
{
    using System;
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Models;

    public class EventResponseModel : IMapFrom<Event>
    {
        public string Title { get; set; }

        public string Location { get; set; }

        public string Town { get; set; }

        public DateTime Date { get; set; }
    }
}
