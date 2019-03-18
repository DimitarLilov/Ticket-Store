namespace TicketStore.Web.Shared.Categories
{
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Models;

    public class CategoryResponseModel : IMapFrom<Category>, IMapFrom<CategoryRequestModel>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
