namespace TicketStore.Web.Shared.Tickets
{
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Models;

    public class BuyTicketRequestModel : IMapTo<Ticket>, IMapFrom<Ticket>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int EventId { get; set; }

    }
}
