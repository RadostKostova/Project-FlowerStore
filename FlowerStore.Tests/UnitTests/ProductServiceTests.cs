using FlowerStore.Core.Contracts;
using FlowerStore.Core.Services;
using FlowerStore.Infrastructure.Common;
using FlowerStore.Infrastructure.Data;
using FlowerStore.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FlowerStore.Tests.UnitTests
{
    [TestFixture]
    internal class ProductServiceTests
    {
        //Dependencies
        private FlowerStoreDbContext dbContext;
        private IRepository repository;
        private IProductService productService;

        //Collections
        private IEnumerable<Category> categories;
        private IEnumerable<Product> products;

        //Categories
        private Category firstCategory;
        private Category secondCategory;
        private Category thirdCategory;

        //Products
        private Product redRose;
        private Product blueOrchid;
        private Product ficusLyrata;
        private Product orangeTagetes;

        [SetUp]
        public async Task Setup()
        {
            firstCategory = new Category
            {
                Id = 1,
                Name = "First Category"
            };

            secondCategory = new Category
            {
                Id = 2,
                Name = "Second Category"
            };

            thirdCategory = new Category
            {
                Id = 3,
                Name = "Third Category"
            };

            redRose = new Product
            {
                Id = 1,
                Name = "Red Rose",
                CategoryId = 1,
                Price = 4.00m,
                DateAdded = DateTime.UtcNow,
                ImageUrl = "https://img.freepik.com/premium-photo/red-roses-pot-isolated-white-background_511010-2090.jpg",
                Availability = true,
                FullDescription = "Test description about red roses",
                FlowersCount = 3
            };

            blueOrchid = new Product
            {
                Id = 2,
                Name = "Blue Orchid",
                CategoryId = 2,
                Price = 17.50m,
                DateAdded = DateTime.UtcNow,
                ImageUrl = "https://i.pinimg.com/736x/3e/14/88/3e148876fc1b8d1b4063a6695a7ebc9a.jpg",
                Availability = true,
                FullDescription = "Test description about blue orchid",
                FlowersCount = 7
            };

            ficusLyrata = new Product
            {
                Id = 3,
                Name = "Ficus Lyrata",
                CategoryId = 3,
                Price = 22.30m,
                DateAdded = DateTime.UtcNow,
                ImageUrl = "https://cdn.webshopapp.com/shops/30495/files/448237057/ficus-lyrata-xl-fiddle-leaf-fig-pot-21cm-height-80.jpg",
                Availability = true,
                FullDescription = "Test description about ficys lyrata",
                FlowersCount = 4
            };

            orangeTagetes = new Product
            {
                Id = 4,
                Name = "Orange Tagetes",
                CategoryId = 1,
                Price = 12.00m,
                DateAdded = DateTime.UtcNow,
                ImageUrl = "https://skgarden.bg/media/18/326.jpg",
                Availability = true,
                FullDescription = "Test description about ficys lyrata",
                FlowersCount = 5
            };

            categories = new List<Category>() { firstCategory, secondCategory, thirdCategory };
            products = new List<Product>() { redRose, blueOrchid, ficusLyrata, orangeTagetes };

            //Config of in-memory db
            var dbOptions = new DbContextOptionsBuilder<FlowerStoreDbContext>()
               .UseInMemoryDatabase("FlowerStoreTestDb" + Guid.NewGuid().ToString())
               .Options;

            dbContext = new FlowerStoreDbContext(dbOptions);

            // Seed data
            await dbContext.AddRangeAsync(categories);
            await dbContext.AddRangeAsync(products);
            await dbContext.SaveChangesAsync();

            //Repository initialization
            repository = new Repository(dbContext);

            //ProductService initialization
            productService = new ProductService(repository);
        }

        //Clean db after each test
        [TearDown]
        public async Task Teardown()
        {
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.DisposeAsync();
        }


        //GetPaginatedProductsAsync Tests
        [Test]
        public async Task GetPaginatedProductsAsync_WithoutSorting_ReturnsDefaultPaginatedProducts()
        {
            var result = await productService.GetPaginatedProductsAsync(1, 2, ""); //page, pageSize, sorting

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.CurrentPage, Is.EqualTo(1));
                Assert.That(result.TotalPages, Is.EqualTo(2)); //4 products, 2 per page -> 2 pages
                Assert.That(result.Products.Count, Is.EqualTo(2));
                Assert.That(result.Products.First().Name, Is.EqualTo("Red Rose")); //default sort (by seed order)
            });
        }

        [Test]
        public async Task GetPaginatedProductsAsync_WithoutSorting_ReturnsProductsAtSecondPageCorrectly()
        {
            var result = await productService.GetPaginatedProductsAsync(2, 2, "");

            Assert.That(result.CurrentPage, Is.EqualTo(2));
            Assert.That(result.Products.Count, Is.EqualTo(2));
            Assert.That(result.Products.First().Name, Is.EqualTo("Ficus Lyrata")); //3rd product 
            Assert.That(result.Products.Last().Name, Is.EqualTo("Orange Tagetes")); //4th product
        }

        [Test]
        public async Task GetPaginatedProductsAsync_SortByPriceAscending_ReturnsSortedProductsCorrectly()
        {
            var result = await productService.GetPaginatedProductsAsync(1, 4, "Price Ascending");

            Assert.That(result.Products.Count, Is.EqualTo(4));
            Assert.That(result.Products.First().Price, Is.EqualTo(4.00m));
            Assert.That(result.Products.Last().Price, Is.EqualTo(22.30m));
        }

        [Test]
        public async Task GetPaginatedProductsAsync_SortByNameDescending_ReturnsSortedProductsCorrectly()
        {
            var result = await productService.GetPaginatedProductsAsync(1, 4, "Name Descending");

            Assert.That(result.Products.Count, Is.EqualTo(4));
            Assert.That(result.Products.First().Name, Is.EqualTo("Red Rose"));
            Assert.That(result.Products.Last().Name, Is.EqualTo("Blue Orchid"));
        }

        [Test]
        public async Task GetPaginatedProductsAsync_WhenNoProductsAreInLastPage_ReturnsEmptyResult()
        {
            var result = await productService.GetPaginatedProductsAsync(3, 2, "");

            Assert.That(result.CurrentPage, Is.EqualTo(3));
            Assert.That(result.Products, Is.Empty);
            Assert.That(result.TotalPages, Is.EqualTo(2));
        }


        //ProductByIdExistAsync Tests
        [Test]
        public async Task ProductByIdExistAsync_WhenProductExists_ReturnsProductProperly()
        {
            var result = await productService.ProductByIdExistAsync(redRose.Id);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Id, Is.EqualTo(redRose.Id));
                Assert.That(result.Name, Is.EqualTo(redRose.Name));
                Assert.That(result.Price, Is.EqualTo(redRose.Price));
                Assert.That(result.CategoryId, Is.EqualTo(redRose.CategoryId));
            });
        }

        [Test]
        public async Task ProductByIdExistAsync_WhenProductDoesntExist_ReturnsNull()
        {
            var result = await productService.ProductByIdExistAsync(9999);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task ProductByIdExistAsync_WhenProductIdIsInvalid_ReturnsNull()
        {
            var result = await productService.ProductByIdExistAsync(0);

            Assert.That(result, Is.Null);
        }

        //GetProductDetailsAsync tests
        [Test]
        public async Task GetProductDetailsAsync_WhenProductExists_ReturnsProductDetailsViewModel()
        {
            var result = await productService.GetProductDetailsAsync(redRose.Id);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Id, Is.EqualTo(redRose.Id));
                Assert.That(result.Name, Is.EqualTo(redRose.Name));
                Assert.That(result.Price, Is.EqualTo(redRose.Price));
                Assert.That(result.DateAdded, Is.EqualTo(redRose.DateAdded));
                Assert.That(result.FlowersCount, Is.EqualTo(redRose.FlowersCount));
                Assert.That(result.Category, Is.EqualTo("First Category"));
            });
        }

        [Test]
        public void GetProductDetailsAsync_WhenProductDoesntExist_ThrowsException()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await productService.GetProductDetailsAsync(8678));
        }

        [Test]
        public async Task GetProductDetailsAsync_WhenCategoryDoesntExist_ThrowsNullException()
        {
            var testProduct = new Product
            {
                Id = 10,
                Name = "Test",
                CategoryId = 5673,
                Price = 10.00m,
                DateAdded = DateTime.UtcNow,
                FlowersCount = 1,
                ImageUrl = "https://invalidtesturl.com/test.jpg",
                Availability = true,
                FullDescription = "Random invalid product description",
            };

            await dbContext.Products.AddAsync(testProduct);
            await dbContext.SaveChangesAsync();

            Assert.ThrowsAsync<NullReferenceException>(async () =>
                await productService.GetProductDetailsAsync(10));
        }


        //GetProductPriceAsync tests
        [Test]
        public async Task GetProductPriceAsync_WhenProductExists_ReturnsCorrectPrice()
        {
            var result = await productService.GetProductPriceAsync(redRose.Id);

            Assert.That(result, Is.EqualTo(redRose.Price));
        }

        [Test]
        public async Task GetProductPriceAsync_WhenProductDoesNotExist_ReturnsNull()
        {
            var result = await productService.GetProductPriceAsync(9999);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetProductPriceAsync_WhenProductIdIsZero_ReturnsNull()
        {
            var result = await productService.GetProductPriceAsync(0);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetProductPriceAsync_WhenProductIdIsNegative_ReturnsNull()
        {
            var result = await productService.GetProductPriceAsync(-378);

            Assert.That(result, Is.Null);
        }


        //SearchProductAsync tests
        [Test]
        public async Task SearchProductAsync_WhenProductsExistAndMatch_ReturnsCorrectProducts()
        {
            var searchString = "Rose";

            var results = (await productService.SearchProductAsync(searchString)).ToList();

            Assert.Multiple(() =>
            {
                Assert.That(results, Is.Not.Null);
                Assert.That(results, Has.Count.EqualTo(1));
                Assert.That(results[0].Id, Is.EqualTo(redRose.Id));
                Assert.That(results[0].Name, Is.EqualTo(redRose.Name));
                Assert.That(results[0].Price, Is.EqualTo(redRose.Price));
                Assert.That(results[0].Category, Is.EqualTo("First Category"));
            });
        }

        [Test]
        public async Task SearchProductAsync_WhenMatchingMultiple_ReturnsAllMatchingProducts()
        {
            var searchString = "First"; //should match category (redRose and orangeTagetes)

            var results = (await productService.SearchProductAsync(searchString)).ToList();

            Assert.That(results.Count, Is.EqualTo(2));
            Assert.That(results.Any(p => p.Id == redRose.Id));
            Assert.That(results.Any(p => p.Id == orangeTagetes.Id));
        }

        [Test]
        public async Task SearchProductAsync_WhenIsCaseInsensitive_ReturnsCorrectProduct()
        {
            var searchString = "rose"; //Lowercase

            var results = (await productService.SearchProductAsync(searchString)).ToList();

            Assert.Multiple(() =>
            {
                Assert.That(results, Is.Not.Null);
                Assert.That(results.Count, Is.EqualTo(1));
                Assert.That(results[0].Name, Is.EqualTo(redRose.Name));
            });
        }

        [Test]
        public async Task SearchProductAsync_WhenNoMatch_ReturnsEmptyList()
        {
            var searchString = "TestString";

            var results = (await productService.SearchProductAsync(searchString)).ToList();

            Assert.That(results, Is.Not.Null);
            Assert.That(results, Is.Empty);
        }


        //GetAllCategoriesAsync tests
        [Test]
        public async Task GetAllCategoriesAsync_WhenCategoriesExists_ReturnsAllCategories()
        {
            var categories = (await productService.GetAllCategoriesAsync()).ToList();

            Assert.That(categories, Is.Not.Null);
            Assert.That(categories.Count, Is.EqualTo(3));

            Assert.Multiple(() => //skip second
            {
                Assert.That(categories[0].Id, Is.EqualTo(firstCategory.Id));
                Assert.That(categories[0].Name, Is.EqualTo(firstCategory.Name));

                Assert.That(categories[2].Id, Is.EqualTo(thirdCategory.Id));
                Assert.That(categories[2].Name, Is.EqualTo(thirdCategory.Name));
            });
        }

        [Test]
        public async Task GetAllCategoriesAsync_WhenCategoriesDoesntExists_ReturnsEmptyList()
        {
            dbContext.Categories.RemoveRange(dbContext.Categories); //clear categories in db
            await dbContext.SaveChangesAsync();

            var categories = (await productService.GetAllCategoriesAsync()).ToList();

            Assert.That(categories, Is.Not.Null);
            Assert.That(categories, Is.Empty);
        }


        //UpdateProductStockAsync tests
        [Test]
        public async Task UpdateProductStockAsync_WhenStockIsEnough_UpdatesStockAndAvailability()
        {
            //initial quantity 7, decrease with 5
            await productService.UpdateProductStockAsync(blueOrchid.Id, 5);

            var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == blueOrchid.Id);

            Assert.That(product!.FlowersCount, Is.EqualTo(2)); //7 - 5
            Assert.That(product.Availability, Is.True);
        }

        [Test]
        public async Task UpdateProductStockAsync_WhenStockIsZero_SetsAvailabilityToFalse()
        {
            //initial quantity 5, decrease with 5
            await productService.UpdateProductStockAsync(orangeTagetes.Id, 5);

            var product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == orangeTagetes.Id);

            Assert.That(product, Is.Not.Null);
            Assert.That(product!.FlowersCount, Is.EqualTo(0));
            Assert.That(product.Availability, Is.False);
        }

        [Test]
        public void UpdateProductStockAsync_WhenProductDoesntExist_ThrowsException()
        {
            Assert.ThrowsAsync<ArgumentException>(async () =>
                await productService.UpdateProductStockAsync(4353, 1)); 
        }

        [Test]
        public void UpdateProductStockAsync_WhenStockIsNotEnough_ThrowsException()
        {
            //decreasing red roses (3 qty) with 10
            Assert.ThrowsAsync<ArgumentException>(async () =>
                await productService.UpdateProductStockAsync(redRose.Id, 10)); 
        }
    }
}
