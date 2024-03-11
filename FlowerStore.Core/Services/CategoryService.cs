using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.Category;
using FlowerStore.Infrastructure.Common;
using FlowerStore.Infrastructure.Data.Models;
using FlowerStore.Infrastructure.Data.Models.Categories;
using Microsoft.EntityFrameworkCore;

namespace FlowerStore.Core.Services
{
    /// <summary>
    /// Service methods for categories.
    /// </summary>

    public class CategoryService : ICategoryService
    {
        private readonly IRepository repository;

        public CategoryService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync(int productId)
        {
            var product = await repository.AllAsReadOnly<Product>().FirstOrDefaultAsync(p => p.Id == productId);

            return await repository.AllAsReadOnly<Category>()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }
    }
}
