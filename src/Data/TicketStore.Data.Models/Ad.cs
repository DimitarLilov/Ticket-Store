namespace TicketStore.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using TicketStore.Data.Common.Models;

    public class Ad : BaseModel<int>
    {
        [Required]
        public string Type { get; set; }

        [ForeignKey("Event")]
        public int EveentId { get; set; }

        public bool Active { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public virtual Event Event { get; set; }
    }
}
