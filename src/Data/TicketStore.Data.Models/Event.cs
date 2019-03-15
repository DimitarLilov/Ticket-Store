
namespace TicketStore.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using TicketStore.Data.Common.Models;


    public class Event : BaseModel<int>
    {
        public Event()
        {
            this.Tickets = new HashSet<Ticket>();
        }
        [Required]
        public string Title { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Town { get; set; }

        [Required]
        public string Detail { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Required]
        public Category Category { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
