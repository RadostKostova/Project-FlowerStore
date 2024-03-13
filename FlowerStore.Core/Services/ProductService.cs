﻿using FlowerStore.Core.Contracts;
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
                    ImageUrl = p.ImageUrl
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

        //Get details of product (return viewModel)
        public async Task<ProductDetailsViewModel> GetProductDetailsAsync(int productId)
        {
            var productFound = await repository
                .AllAsReadOnly<Product>()
                .FirstOrDefaultAsync(p => p.Id == productId);

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

        public async Task<int> AddProductAsync(ProductAddViewModel model)
        {
            //should have condition if == "Admin" (later)

            var product = new Product()
            {
                Name = model.Name,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                FullDescription = model.FullDescription,
                FlowersCount = model.FlowersCount,
                Availability = model.Availability, 
                CategoryId = model.CategoryId
            };

            await repository.AddAsync(product);
            await repository.SaveChangesAsync();

            return product.Id;
        }

        //Search for product
        public Task<IEnumerable<ProductAllViewModel>> SearchProductAsync(string input)
        {
            throw new NotImplementedException();
        }
    }
}
