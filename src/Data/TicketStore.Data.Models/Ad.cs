namespace TicketStore.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using TicketStore.Data.Common.Models;

    public class Ad : BaseModel<int>
    {
        [Required]
        [ForeignKey("Type")]
        public int TypeId { get; set; }

        [Required]
        public AdType Type { get; set; }

        [Required]
        [ForeignKey("Event")]
        public int EventId { get; set; }

        [Required]
        public Event Event { get; set; }

        public bool Active { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
