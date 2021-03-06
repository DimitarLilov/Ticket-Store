﻿namespace TicketStore.Web.Shared.Tickets
{
    using TicketStore.Web.Shared.Events;

    public class TicketDetailsResponseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public EventListItem Event { get; set; }
    }
}
