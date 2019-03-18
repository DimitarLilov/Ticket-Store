namespace TicketStore.Web.Shared.Events
{
    using System;
    using TicketStore.Common.Mapping;

    public class EditEventResponseModel : IMapFrom<EditEventRequestModel>
    {

        public string Title { get; set; }

        public string Location { get; set; }

        public string Town { get; set; }

        public DateTime Date { get; set; }
        
        public string Image { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }
    }
}
