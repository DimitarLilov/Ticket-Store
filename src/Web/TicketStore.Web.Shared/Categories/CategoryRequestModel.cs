namespace TicketStore.Web.Shared.Categories
{
    using System.ComponentModel.DataAnnotations;
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Models;

    public class CategoryRequestModel : IMapTo<Category>
    {
        [Required]
        public string Name { get; set; }
    }
}
