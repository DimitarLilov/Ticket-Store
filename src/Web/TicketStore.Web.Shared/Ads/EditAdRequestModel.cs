namespace TicketStore.Web.Shared.Ads
{
    using System;
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Models;

    public class EditAdRequestModel : IMapTo<Ad>
    {
        public int TypeId { get; set; }

        public bool Active { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
