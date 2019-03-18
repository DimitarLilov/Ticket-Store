namespace TicketStore.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TicketStore.Web.Shared.Categories;

    public interface ICategoriesService
    {
        IEnumerable<CategoryResponseModel> GetAllCategories();
        string GetCategoryNameById(int id);
        Task<int> AddCategory(CategoryRequestModel model);
        CategoryResponseModel GetCategoryById(int id);
        Task<CategoryResponseModel> EditCategory(int id, CategoryRequestModel model);
        Task DeleteCategory(int id);
    }
}
