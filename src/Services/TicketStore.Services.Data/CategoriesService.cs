namespace TicketStore.Services.Data
{
    using AutoMapper;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TicketStore.Common.Mapping;
    using TicketStore.Data.Common.Repositories;
    using TicketStore.Data.Models;
    using TicketStore.Services.Data.Interfaces;
    using TicketStore.Web.Shared.Categories;

    public class CategoriesService : ICategoriesService
    {
        private readonly IRepository<Category> categoriesRepository; 

        public CategoriesService(IRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public async Task<int> AddCategory(CategoryRequestModel model)
        {
            var category = Mapper.Map<Category>(model);

            await this.categoriesRepository.AddAsync(category);
            await this.categoriesRepository.SaveChangesAsync();

            return category.Id;
        }

        public CategoryResponseModel GetCategoryById(int id)
        {
            var category = this.categoriesRepository.All().Where(e => e.Id == id);

            return category.To<CategoryResponseModel>().FirstOrDefault();
        }

        public async Task<CategoryResponseModel> EditCategory(int id, CategoryRequestModel model)
        {
            var category = Mapper.Map<Category>(model);
            category.Id = id;
            this.categoriesRepository.Update(category);
            await this.categoriesRepository.SaveChangesAsync();

            return Mapper.Map<CategoryResponseModel>(model);
        }

        public IEnumerable<CategoryResponseModel> GetAllCategories()
        {
            return this.categoriesRepository.All().To<CategoryResponseModel>();
        }

        public string GetCategoryNameById(int id)
        {
            return this.categoriesRepository.GetById(id).Name;
        }

        public async Task DeleteCategory(int id)
        {
            var category = this.categoriesRepository.All().FirstOrDefault(i => i.Id == id);

            this.categoriesRepository.Delete(category);

            await this.categoriesRepository.SaveChangesAsync();
        }
    }
}
