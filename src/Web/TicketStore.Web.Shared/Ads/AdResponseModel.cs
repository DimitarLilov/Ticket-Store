namespace TicketStore.Web.Shared.Ads
{
    using System;
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Models;
    using TicketStore.Web.Shared.Events;

    public class AdResponseModel : IMapFrom<Ad>
    {
        public EventResponseModel Event { get; set; }

        public AdTypeResponseModel Type { get; set; }

        public bool Active { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
