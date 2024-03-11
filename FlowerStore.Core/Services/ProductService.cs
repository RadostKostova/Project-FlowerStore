using FlowerStore.Core.Contracts;
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


        public async Task<IEnumerable<ProductAllViewModel>> ShowAllProductsAsync()
        {
            return await repository
                .AllAsReadOnly<Product>()
                .Select(p => new ProductAllViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl
                })
                .ToListAsync();
        }

        public async Task<Product> ProductByIdExistAsync(int productId)
        {
            var productFound = await repository
                .AllAsReadOnly<Product>()
                .FirstOrDefaultAsync(p => p.Id == productId);

            return productFound;
        }

        public async Task<int> GetProductCountAsync(int productId)
        {
            var product = await repository
                .AllAsReadOnly<Product>()
                .FirstOrDefaultAsync(p => p.Id == productId);

            return product.FlowersCount;
        }

        public async Task<bool> GetAvailabilityAsync(int productId)
        {
            var product = await repository.AllAsReadOnly<Product>()
                                    .FirstOrDefaultAsync(p => p.Id == productId);

            return product.Availability;
        }

        public async Task<ProductDetailsViewModel> GetProductDetailsAsync(int productId)
        {
            var productFound = await repository.AllAsReadOnly<Product>().FirstOrDefaultAsync(p => p.Id == productId);

            var product = new ProductDetailsViewModel()
            {
                Id = productFound.Id,
                Name = productFound.Name,
                Price = productFound.Price,
                ImageUrl = productFound.ImageUrl,
                Availability = productFound.Availability,
                FullDescription = productFound.FullDescription,
                FlowersCount = productFound.FlowersCount
            };

            return product;
        }

        public Task<IEnumerable<ProductAllViewModel>> SearchProductAsync(string input)
        {
            throw new NotImplementedException();
        }
    }
}
