using FlowerStore.Core.Contracts;
using FlowerStore.Core.Services;
using FlowerStore.Infrastructure.Common;
using FlowerStore.Infrastructure.Data;
using FlowerStore.Infrastructure.Data.Models;
using FlowerStore.Infrastructure.Data.Models.Cart;
using FlowerStore.Infrastructure.Data.Models.Carts;
using FlowerStore.Infrastructure.Data.Models.Roles;
using Microsoft.EntityFrameworkCore;

namespace FlowerStore.Tests.UnitTests
{
    [TestFixture]
    internal class CartServiceTests
    {
        //Dependencies
        private FlowerStoreDbContext dbContext;
        private IRepository repository;
        private IProductService productService;
        private ICartService cartService;

        //Collections
        private IEnumerable<ApplicationUser> users;
        private IEnumerable<Category> categories;
        private IEnumerable<Product> products;
        private IEnumerable<ShoppingCart> carts;

        //Users
        private ApplicationUser firstUser;
        private ApplicationUser secondUser;

        //Categories
        private Category firstCategory;
        private Category secondCategory;

        //Products
        private Product redRose;
        private Product blueOrchid;
        private Product ficusLyrata;

        //Shopping Carts
        private ShoppingCart firstCart;
        private ShoppingCart secondCart;

        [SetUp]
        public async Task Setup()
        {
            firstUser = new ApplicationUser
            {
                Id = "firstUserId",
                UserName = "firstuser@firstuser.com",
                NormalizedUserName = "FIRSTUSER@FIRSTUSER.COM",
                Email = "firstuser@firstuser.com",
                NormalizedEmail = "FIRSTUSER@FIRSTUSER.COM",
                FirstName = "First",
                LastName = "User",
                PhoneNumber = "1234567890"
            };

            secondUser = new ApplicationUser
            {
                Id = "secondUserId",
                UserName = "seconduser@seconduser.com",
                NormalizedUserName = "SECONDUSER@SECONDUSER.COM",
                Email = "seconduser@seconduser.com",
                NormalizedEmail = "SECONDUSER@SECONDUSER.COM",
                FirstName = "Second",
                LastName = "User",
                PhoneNumber = "1234567800"
            };

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
                CategoryId = 1,
                Price = 22.30m,
                DateAdded = DateTime.UtcNow,
                ImageUrl = "https://cdn.webshopapp.com/shops/30495/files/448237057/ficus-lyrata-xl-fiddle-leaf-fig-pot-21cm-height-80.jpg",
                Availability = true,
                FullDescription = "Test description about ficys lyrata",
                FlowersCount = 4
            };

            firstCart = new ShoppingCart
            {
                Id = 1,
                UserId = firstUser.Id,
                ProductsCounter = 1,
                TotalPrice = 4.00m,
                ShoppingCartProducts = new List<ShoppingCartProduct>
                {
                    new ShoppingCartProduct
                    {
                        ProductId = 1,
                        ShoppingCartId = 1,
                        Quantity = 1,
                        Price = redRose.Price //4.00
                    }
                }
            };

            secondCart = new ShoppingCart
            {
                Id = 2,
                UserId = secondUser.Id,
                ProductsCounter = 2,
                TotalPrice = 39.80m,
                ShoppingCartProducts = new List<ShoppingCartProduct>
                {
                    new ShoppingCartProduct
                    {
                        ProductId = 2,
                        ShoppingCartId = 2,
                        Quantity = 1,
                        Price = blueOrchid.Price //17.50
                    },
                    new ShoppingCartProduct
                    {
                        ProductId = 3,
                        ShoppingCartId = 2,
                        Quantity = 1,
                        Price = ficusLyrata.Price  //22.30
                    }
                }.ToList(),
            };

            users = new List<ApplicationUser>() { firstUser, secondUser };
            categories = new List<Category>() { firstCategory, secondCategory };
            products = new List<Product>() { redRose, blueOrchid, ficusLyrata };
            carts = new List<ShoppingCart> { firstCart, secondCart };

            //Config of in-memory db
            var dbOptions = new DbContextOptionsBuilder<FlowerStoreDbContext>()
               .UseInMemoryDatabase("FlowerStoreTestDb" + Guid.NewGuid().ToString())
               .Options;

            dbContext = new FlowerStoreDbContext(dbOptions);

            // Seed data
            await dbContext.AddRangeAsync(users);
            await dbContext.AddRangeAsync(categories);
            await dbContext.AddRangeAsync(products);
            await dbContext.AddRangeAsync(carts);
            await dbContext.SaveChangesAsync();

            //Repository initialization
            repository = new Repository(dbContext);

            //CartService and PRoductService initialization
            productService = new ProductService(repository);
            cartService = new CartService(repository, productService);
        }

        //Clean db after each test
        [TearDown]
        public async Task Teardown()
        {
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.DisposeAsync();
        }


        //ShoppingCartExistByUserIdAsync tests
        [Test]
        public async Task ShoppingCartExistByUserIdAsync_WhenCartExists_ReturnsCorrectCart()
        {
            var cart = await cartService.ShoppingCartExistByUserIdAsync(firstUser.Id);

            Assert.Multiple(() =>
            {
                Assert.That(cart, Is.Not.Null);
                Assert.That(cart.Id, Is.EqualTo(firstCart.Id));
                Assert.That(cart.UserId, Is.EqualTo(firstCart.UserId));
                Assert.That(cart.TotalPrice, Is.EqualTo(firstCart.TotalPrice));
                Assert.That(cart.ShoppingCartProducts.Count, Is.EqualTo(1));
            });
        }

        [Test]
        public async Task ShoppingCartExistByUserIdAsync_WhenCartDoesNotExist_ReturnsNull()
        {
            var cart = await cartService.ShoppingCartExistByUserIdAsync("nonExistingUserId");

            Assert.That(cart, Is.Null);
        }

        [Test]
        public async Task ShoppingCartExistByUserIdAsync_WhenUserIdIsEmpty_ReturnsNull()
        {
            var cart = await cartService.ShoppingCartExistByUserIdAsync("");

            Assert.That(cart, Is.Null);
        }


        //GetShoppingCartByUserIdAsync Tests
        [Test]
        public async Task GetShoppingCartByUserIdAsync_WhenCartExists_ReturnsProperCartViewModel()
        {
            var model = await cartService.GetShoppingCartByUserIdAsync(secondUser.Id);

            Assert.Multiple(() => //Testing the cart with its products
            {
                Assert.That(model, Is.Not.Null);
                Assert.That(model.Id, Is.EqualTo(secondCart.Id));
                Assert.That(model.UserId, Is.EqualTo(secondUser.Id));
                Assert.That(model.ProductsCounter, Is.EqualTo(secondCart.ProductsCounter));
                Assert.That(model.TotalPrice, Is.EqualTo(secondCart.TotalPrice));
                Assert.That(model.ShoppingCartProducts.First().ProductId == 2); //test if the first product is there
                Assert.That(model.ShoppingCartProducts.Count, Is.EqualTo(2));

                var secondProductInCart = model.ShoppingCartProducts.FirstOrDefault(p => p.ProductId == 3); //ficus Id = 3

                //more comparison for the second product (just in case)
                Assert.That(secondProductInCart!.ProductId, Is.EqualTo(ficusLyrata.Id));
                Assert.That(secondProductInCart.Name, Is.EqualTo(ficusLyrata.Name));
                Assert.That(secondProductInCart.UnitPrice, Is.EqualTo(ficusLyrata.Price));
                Assert.That(secondProductInCart.Quantity, Is.EqualTo(1));
                Assert.That(secondProductInCart.Category, Is.EqualTo("First Category"));
            });
        }

        [Test]
        public async Task GetShoppingCartByUserIdAsync_WhenCartDoesNotExist_ReturnsNull()
        {
            var result = await cartService.GetShoppingCartByUserIdAsync("nonExisingUserId");

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetShoppingCartByUserIdAsync_WhenCartIsEmpty_ReturnsProperViewModel()
        {
            var emptyCart = new ShoppingCart
            {
                Id = 3,
                UserId = "randomUser",
                ProductsCounter = 0,
                TotalPrice = 0,
                ShoppingCartProducts = new List<ShoppingCartProduct>()
            };
            await dbContext.AddAsync(emptyCart);
            await dbContext.SaveChangesAsync();

            var result = await cartService.GetShoppingCartByUserIdAsync(emptyCart.UserId);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Id, Is.EqualTo(emptyCart.Id));
                Assert.That(result.UserId, Is.EqualTo(emptyCart.UserId));
                Assert.That(result.ProductsCounter, Is.EqualTo(0));
                Assert.That(result.TotalPrice, Is.EqualTo(0));
                Assert.That(result.ShoppingCartProducts, Is.Empty);
            });
        }


        //CreateShoppingCartAsync Tests
        [Test]
        public async Task CreateShoppingCartAsync_WhenCalled_CreatesAndReturnsNewCart()
        {
            var newCart = await cartService.CreateShoppingCartAsync("newUserId");

            Assert.Multiple(() =>
            {
                Assert.That(newCart, Is.Not.Null);
                Assert.That(newCart.UserId, Is.EqualTo("newUserId"));
                Assert.That(newCart.ProductsCounter, Is.EqualTo(0));
                Assert.That(newCart.TotalPrice, Is.EqualTo(0));
                Assert.That(newCart.ShoppingCartProducts, Is.Empty);
            });

            var newCartInDb = await dbContext.ShoppingCarts.FirstOrDefaultAsync(c => c.UserId == "newUserId");

            Assert.Multiple(() =>
            {
                Assert.That(newCartInDb, Is.Not.Null);
                Assert.That(newCartInDb!.Id, Is.EqualTo(newCart.Id));
                Assert.That(newCartInDb.ProductsCounter, Is.EqualTo(newCart.ProductsCounter));
                Assert.That(newCartInDb.TotalPrice, Is.EqualTo(newCart.TotalPrice));
                Assert.That(newCartInDb.ShoppingCartProducts.Count, Is.EqualTo(newCart.ShoppingCartProducts.Count));
            });
        }
        //Tests for null or empty userId are unnecessary,
        //because i handle such cases in the controllers and in db with data validations (but still will be considered)


        //AddProductToCartAsync tests
        [Test]
        public async Task AddProductToCartAsync_WhenProductIsntInCart_AddsProductProperly()
        {
            await cartService.AddProductToCartAsync(firstUser.Id, blueOrchid.Id, 1); //1 is added quantity

            var cart = await cartService.ShoppingCartExistByUserIdAsync(firstUser.Id);
            var productAdded = cart.ShoppingCartProducts.First(p => p.ProductId == blueOrchid.Id);

            Assert.Multiple(() =>
            {
                Assert.That(cart.TotalPrice, Is.EqualTo(firstCart.TotalPrice));
                Assert.That(cart.ProductsCounter, Is.EqualTo(firstCart.ProductsCounter));

                Assert.That(productAdded, Is.Not.Null);
                Assert.That(productAdded.Quantity, Is.EqualTo(1));
                Assert.That(productAdded.Price, Is.EqualTo(blueOrchid.Price));
            });
        }

        [Test]
        public async Task AddProductToCartAsync_WhenProductAlreadyInCart_IncreasesQuantityProperly()
        {
            int oldQuantity = 1;
            int addedQuantity = 1;

            await cartService.AddProductToCartAsync(firstUser.Id, redRose.Id, addedQuantity);

            var cart = await cartService.ShoppingCartExistByUserIdAsync(firstUser.Id);
            var productInCart = cart.ShoppingCartProducts.FirstOrDefault(p => p.ProductId == redRose.Id);

            Assert.That(productInCart!.Quantity, Is.EqualTo(oldQuantity + addedQuantity));
            Assert.That(cart.TotalPrice, Is.EqualTo(redRose.Price * (oldQuantity + addedQuantity)));
            Assert.That(cart.ProductsCounter, Is.EqualTo(oldQuantity + addedQuantity));
        }

        [Test]
        public async Task AddProductToCartAsync_WhenCartDoesntExist_CreatesCartAndAddsProduct()
        {
            await cartService.AddProductToCartAsync("newUserId", redRose.Id, 1);

            var newCart = await cartService.ShoppingCartExistByUserIdAsync("newUserId");
            var productInCart = newCart.ShoppingCartProducts.FirstOrDefault(p => p.ProductId == redRose.Id);

            Assert.Multiple(() =>
            {
                Assert.That(newCart, Is.Not.Null);
                Assert.That(productInCart, Is.Not.Null);

                Assert.That(productInCart!.Quantity, Is.EqualTo(1));
                Assert.That(productInCart.Price, Is.EqualTo(redRose.Price));
                Assert.That(newCart.TotalPrice, Is.EqualTo(redRose.Price * 1));
                Assert.That(newCart.ProductsCounter, Is.EqualTo(1));
            });
        }

        [Test]
        public void AddProductToCartAsync_WhenProductIsInvalid_ThrowsException()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await cartService.AddProductToCartAsync("newUserId", 8657567, 1));
        }


        //RemoveProductFromCartAsync tests (shouldn't throw exceptions if it fails - just false)
        [Test]
        public async Task RemoveProductFromCartAsync_WhenProductInCartExists_RemovesProductSuccessfully()
        {
            var result = await cartService.RemoveProductFromCartAsync(firstUser.Id, redRose.Id);

            var cart = await dbContext.ShoppingCarts
                .Include(sc => sc.ShoppingCartProducts)
                .FirstOrDefaultAsync(sc => sc.Id == firstCart.Id);

            Assert.That(result, Is.True);
            Assert.That(cart!.ProductsCounter, Is.EqualTo(0));
        }

        [Test]
        public async Task RemoveProductFromCartAsync_WhenCartDoesNotExist_ReturnsFalse()
        {
            var result = await cartService.RemoveProductFromCartAsync("nonExistentUserId", redRose.Id);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task RemoveProductFromCartAsync_WhenProductDoesnttExistInCart_ReturnsFalse()
        {
            var result = await cartService.RemoveProductFromCartAsync(firstUser.Id, ficusLyrata.Id);

            var cart = await dbContext.ShoppingCarts
                    .Include(sc => sc.ShoppingCartProducts)
                    .FirstAsync(sc => sc.Id == firstCart.Id);

            Assert.That(result, Is.False);
            Assert.That(cart.TotalPrice, Is.EqualTo(4.00m)); //no changes
            Assert.That(cart.ProductsCounter, Is.EqualTo(1));
        }

        [Test]
        public async Task RemoveProductFromCartAsync_WhenProductDoesntExistAtAll_ReturnsFalse()
        {
            var result = await cartService.RemoveProductFromCartAsync(firstUser.Id, 567);

            Assert.That(result, Is.False);
        }


        //GetProductInCartByIdAsync Tests
        [Test]
        public async Task GetProductInCartByIdAsync_WhenProductIsInCart_ReturnsProductSuccessfully()
        {
            var product = await cartService.GetProductInCartByIdAsync(firstCart.Id, redRose.Id);

            Assert.Multiple(() =>
            {
                Assert.That(product, Is.Not.Null);
                Assert.That(product!.ProductId, Is.EqualTo(redRose.Id));
                Assert.That(product.Name, Is.EqualTo(redRose.Name));
                Assert.That(product.Quantity, Is.EqualTo(1));
                Assert.That(product.UnitPrice, Is.EqualTo(redRose.Price));
            });
        }

        [Test]
        public async Task GetProductInCartByIdAsync_WhenProductDoesntExistInCart_ReturnsNull()
        {
            var product = await cartService.GetProductInCartByIdAsync(secondCart.Id, redRose.Id);

            Assert.That(product, Is.Null);
        }

        [Test]
        public async Task GetProductInCartByIdAsync_WhenProductDoesntExistAtAll_ReturnsNull()
        {
            var product = await cartService.GetProductInCartByIdAsync(secondCart.Id, 999);

            Assert.That(product, Is.Null);
        }

        [Test]
        public async Task GetProductInCartByIdAsync_WhenCartDoesntExist_ReturnsNull()
        {
            var product = await cartService.GetProductInCartByIdAsync(999, redRose.Id);

            Assert.That(product, Is.Null);
        }


        //ClearCartAsycn Tests
        [Test]
        public async Task ClearCartAsync_WhenProductsAreInCart_ClearsTheCart()
        {
            await cartService.ClearCartAsync(secondUser.Id);

            var cart = await dbContext.ShoppingCarts
                .Include(c => c.ShoppingCartProducts)
                .FirstOrDefaultAsync(c => c.UserId == secondUser.Id);

            Assert.That(cart, Is.Not.Null);
            Assert.That(cart!.ShoppingCartProducts, Is.Empty);
            Assert.That(cart.TotalPrice, Is.EqualTo(0));
            Assert.That(cart.ProductsCounter, Is.EqualTo(0));
        }

        [Test]
        public async Task ClearCartAsync_WhenCartIsAlreadyEmpty_DoesNothing()
        {          
            var emptyCart = new ShoppingCart  //create empty cart 
            {
                Id = 3,                 
                UserId = "newUserId",
                ProductsCounter = 0,
                TotalPrice = 0m,
                ShoppingCartProducts = new List<ShoppingCartProduct>()
            };

            await dbContext.ShoppingCarts.AddAsync(emptyCart); //add to db
            await dbContext.SaveChangesAsync();

            await cartService.ClearCartAsync("newUserId"); 

            var cart = await dbContext.ShoppingCarts
                .Include(c => c.ShoppingCartProducts)
                .FirstOrDefaultAsync(c => c.UserId == "newUserId");

            Assert.That(cart, Is.Not.Null);
            Assert.That(cart!.ShoppingCartProducts, Is.Empty);
            Assert.That(cart.ProductsCounter, Is.EqualTo(0));
        }

        [Test]
        public async Task ClearCartAsync_WhenCartDoesNotExist_DoesNothing()
        {
            await cartService.ClearCartAsync("nonExistingUserId");

            var allCarts = await dbContext.ShoppingCarts.CountAsync();

            Assert.That(allCarts, Is.EqualTo(2));
        }


        //IsShoppingCartEmpty tests
        [Test]
        public async Task IsShoppingCartEmpty_WhenCartHasProducts_ReturnsFalse()
        {
            var result = await cartService.IsShoppingCartEmpty(secondUser.Id);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task IsShoppingCartEmpty_WhenCartIsEmpty_ReturnsTrue()
        {
            var emptyCart = new ShoppingCart
            {
                Id = 3,
                UserId = "newUserId",
                ProductsCounter = 0,
                TotalPrice = 0m,
                ShoppingCartProducts = new List<ShoppingCartProduct>()
            };

            await dbContext.ShoppingCarts.AddAsync(emptyCart);
            await dbContext.SaveChangesAsync();

            var result = await cartService.IsShoppingCartEmpty("newUserId");

            Assert.That(result, Is.True);
        }

        [Test]
        public async Task IsShoppingCartEmpty_WhenCartDoesntExist_ThrowsNullException()
        {
            Assert.ThrowsAsync<NullReferenceException>(async () =>
               await cartService.IsShoppingCartEmpty("nonExistingUserId"));
        }
    }
}
