namespace TicketStore.Web.Shared.Events
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Models;

    public class CreateEventRequestModel : IMapTo<Event>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Town { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
