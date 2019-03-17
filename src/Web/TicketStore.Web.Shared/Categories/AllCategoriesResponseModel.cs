namespace TicketStore.Web.Shared.Categories
{
    using System.Collections.Generic;

    public class AllCategoriesResponseModel
    {
        public IEnumerable<CategoryResponseModel> Categories { get; set; }
    }
}
