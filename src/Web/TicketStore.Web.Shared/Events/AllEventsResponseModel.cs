namespace TicketStore.Web.Shared.Events
{
    using System.Collections.Generic;

    public class AllEventsResponseModel
    {
        public int Size { get; set; }

        public IEnumerable<EventListItem> Events { get; set; }
    }
}
