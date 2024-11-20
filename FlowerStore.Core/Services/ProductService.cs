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

        //Check if product exist by id 
        public async Task<Product> ProductByIdExistAsync(int productId)
        {
            var productFound = await repository
                .AllAsReadOnly<Product>()
                .FirstOrDefaultAsync(p => p.Id == productId);

            return productFound;
        }        

        //Get details of product (return viewModel)
        public async Task<ProductDetailsViewModel> GetProductDetailsAsync(int productId)
        {
            var productFound = await ProductByIdExistAsync(productId);

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

        //Get price of product
        public async Task<decimal?> GetProductPriceAsync(int productId)
        {
            var product = await repository
                .AllAsReadOnly<Product>()
                .FirstOrDefaultAsync(p => p.Id == productId);

            return product?.Price;
        }

        //Search product
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
            return await repository
                .AllAsReadOnly<Category>()
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }

        //Update the product stock after placed order
        public async Task UpdateProductStockAsync(int productId, int quantity)
        {
            var product = await repository
                .All<Product>() 
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (product == null || product.FlowersCount < quantity)
            {
                throw new ArgumentException("Something went wrong.");
            }

            product.FlowersCount -= quantity;
            product.Availability = product.FlowersCount > 0;
            await repository.SaveChangesAsync();
        }
    }
}

