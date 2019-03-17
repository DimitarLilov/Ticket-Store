namespace TicketStore.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using TicketStore.Data.Common.Models;

    public class Ticket: BaseModel<string>
    {
        public Ticket()
        {
            this.Users = new HashSet<UserTickets>();
        }

        [Required]
        public string PriceCategory { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int TicketCounts { get; set; }

        [Required]
        [ForeignKey("Event")]
        public int EventId { get; set; }

        [Required]
        public Event Event { get; set; }

        public virtual ICollection<UserTickets> Users { get; set; }
    }
}
