using FlowerStore.Core.Contracts;
using FlowerStore.Core.ViewModels.Category;
using FlowerStore.Core.ViewModels.Product;
using FlowerStore.Infrastructure.Common;
using FlowerStore.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowerStore.Core.Services
{
    /// <summary>
    /// Product services implemented for more code reusability.
    /// </summary>

    public class ProductService : IProductService
    {
        private readonly IRepository repository;

        public ProductService(IRepository _repository)
        {
            repository = _repository;
        }


        //Show all products (catalog)
        public async Task<IEnumerable<ProductAllViewModel>> ShowAllProductsAsync()
        {
            return await repository
                .AllAsReadOnly<Product>()
                .Select(p => new ProductAllViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    Category = p.Category.Name
                })
                .ToListAsync();
        }

        //Check if Product exist by id and return it as Product
        public async Task<Product> ProductByIdExistAsync(int productId)
        {
            var productFound = await repository
                .AllAsReadOnly<Product>()
                .FirstOrDefaultAsync(p => p.Id == productId);

            return productFound;
        }

        //Add product to store
        public async Task<int> AddProductAsync(ProductAddViewModel model)
        {
            //should have condition if == "Admin" (later)

            var product = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                FullDescription = model.FullDescription,
                DateAdded = DateTime.UtcNow,
                FlowersCount = model.FlowersCount,
                Availability = model.Availability,
                CategoryId = model.CategoryId
            };

            await repository.AddAsync(product);
            await repository.SaveChangesAsync();
            return product.Id;
        }

        //Get details of product (return viewModel)
        public async Task<ProductDetailsViewModel> GetProductDetailsAsync(int productId)
        {
            var productFound = await repository
                .AllAsReadOnly<Product>()
                .FirstOrDefaultAsync(p => p.Id == productId);

            var categoryFound = await repository
                .AllAsReadOnly<Category>()
                .FirstOrDefaultAsync(c => c.Id == productFound.CategoryId);

            var product = new ProductDetailsViewModel()
            {
                Id = productFound.Id,
                Name = productFound.Name,
                Price = productFound.Price,
                ImageUrl = productFound.ImageUrl,
                Availability = productFound.Availability,
                FullDescription = productFound.FullDescription,
                DateAdded = productFound.DateAdded,
                FlowersCount = productFound.FlowersCount,
                Category = categoryFound.Name
            };

            return product;
        }

        //Get edit form of product
        public async Task<ProductEditViewModel> GetEditProductAsync(int productId)
        {
            var product = await repository.All<Product>()
                .FirstOrDefaultAsync(p => p.Id == productId);

          

            var model = new ProductEditViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                FullDescription = product.FullDescription,
                DateAdded = product.DateAdded,
                FlowersCount = product.FlowersCount,
                Availability = product.Availability,
                CategoryId = product.CategoryId
            };

            model.Categories = await GetAllCategoriesAsync();
            return model;
        }

        //Post edit form of product
        public async Task<ProductEditViewModel> PostEditProductAsync(ProductEditViewModel model)
        {
            var product = await repository.All<Product>()
                .Where(p => p.Id == model.Id)
                .FirstOrDefaultAsync();

            product.Name = model.Name;
            product.Price = model.Price;
            product.ImageUrl = model.ImageUrl;
            product.FullDescription = model.FullDescription;
            product.DateAdded = model.DateAdded;
            product.FlowersCount = model.FlowersCount;
            product.Availability = model.Availability;
            product.CategoryId = model.CategoryId;

            await repository.SaveChangesAsync();
            return model;
        }

        //Search for product
        public async Task<IEnumerable<ProductAllViewModel>> SearchProductAsync(string searchString)
        {
            var searchToLower = searchString.ToLower();

            var products = await repository.AllAsReadOnly<Product>()
                   .Where(p => p.Name.ToLower().Contains(searchToLower) ||
                               p.Category.Name.ToLower().Contains(searchToLower))
                   .Select(p => new ProductAllViewModel()
                   {
                       Id = p.Id,
                       Name = p.Name,
                       Price = p.Price,
                       ImageUrl = p.ImageUrl,
                       Category = p.Category.Name
                   })
                   .ToListAsync();

            return products;
        }

        //Get all categories from database
        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {
            return await repository.AllAsReadOnly<Category>()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        public async Task<ProductDeleteViewModel> DeleteProductAsync(int productId)
        {
            var product = await repository
                .AllAsReadOnly<Product>()
                .Where(p => p.Id == productId)
                .FirstOrDefaultAsync();

            var model = new ProductDeleteViewModel()
            {
                Id = product.Id,
                Name = product.Name
            };

            return model;
        }

        public async Task<int> ConfirmDeleteAsync(int productId)
        {
            var product = await repository
                .AllAsReadOnly<Product>()
                .Where (p => p.Id == productId)
                .FirstOrDefaultAsync();

            //should remove from each entity
            await repository.RemoveAsync(product);
            await repository.SaveChangesAsync();
            return product.Id;
        }
    }
}
