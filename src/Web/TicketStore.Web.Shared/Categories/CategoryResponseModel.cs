using TicketStore.Common.Mapping;
using TicketStore.Data.Models;

namespace TicketStore.Web.Shared.Categories
{
    public class CategoryResponseModel : IMapTo<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
