namespace TicketStore.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TicketStore.Web.Shared.Categories;
    using TicketStore.Web.Shared.Events;

    public interface ICategoriesService
    {
        IEnumerable<CategoryResponseModel> GetAllCategories();
        string GetCategoryNameById(int id);
        Task<int> AddCategory(CategoryRequestModel model);
        CategoryResponseModel GetCategoryById(int id);
        Task<CategoryRequestModel> EditCategory(int id, CategoryRequestModel model);
        Task DeleteCategory(int id);
    }
}
