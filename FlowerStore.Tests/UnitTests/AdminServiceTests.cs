using FlowerStore.Core.Contracts;
using FlowerStore.Core.Services;
using FlowerStore.Core.ViewModels.Product;
using FlowerStore.Infrastructure.Common;
using FlowerStore.Infrastructure.Data;
using FlowerStore.Infrastructure.Data.Models;
using FlowerStore.Infrastructure.Data.Models.Orders.Order;
using FlowerStore.Infrastructure.Data.Models.Payment;
using FlowerStore.Infrastructure.Data.Models.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FlowerStore.Tests.UnitTests
{
    [TestFixture]
    internal class AdminServiceTests
    {
        //Dependencies
        private FlowerStoreDbContext dbContext;
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;
        private IRepository repository;
        private IProductService productService;
        private IAdminService adminService;

        //Collections
        private IEnumerable<ApplicationUser> users;
        private IEnumerable<Category> categories;
        private IEnumerable<Product> products;
        private IEnumerable<OrderStatus> orderStatuses;
        private IEnumerable<PaymentMethod> payments;
        private IEnumerable<Order> orders;

        //Users
        private ApplicationUser firstUser;
        private ApplicationUser secondUser;
        private ApplicationUser thirdUser;

        //Categories
        private Category firstCategory;
        private Category secondCategory;

        //Products
        private Product redRose;
        private Product blueOrchid;
        private Product ficusLyrata;

        //Order Statuses
        private OrderStatus pendingStatus;
        private OrderStatus shippedStatus;
        private OrderStatus deliveredStatus;

        //Payment methods
        private PaymentMethod cashPayment;
        private PaymentMethod cardPayment;

        //Orders
        private Order firstOrder;
        private Order secondOrder;
        private Order thirdOrder;

        [SetUp]
        public async Task Setup()
        {
            #region Users

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

            thirdUser = new ApplicationUser
            {
                Id = "thirdUserId",
                UserName = "thirduser@thirduser.com",
                NormalizedUserName = "THIRDUSER@SECONDTHIRDUSER.COM",
                Email = "thirduser@thirduser.com",
                NormalizedEmail = "THIRDUSER@SECONDTHIRDUSER.COM",
                FirstName = "Third",
                LastName = "User",
                PhoneNumber = "1234567000"
            };

            #endregion

            #region Categories

            firstCategory = new Category
            {
                Id = 1,
                Name = "First category"
            };

            secondCategory = new Category
            {
                Id = 2,
                Name = "Second category"
            };

            #endregion

            #region Products

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

            #endregion

            #region Order Statuses

            pendingStatus = new OrderStatus
            {
                Id = 1,
                OrderStatusName = "Pending"
            };

            shippedStatus = new OrderStatus
            {
                Id = 2,
                OrderStatusName = "Shipped"
            };

            deliveredStatus = new OrderStatus
            {
                Id = 3,
                OrderStatusName = "Delivered"
            };

            #endregion

            #region Payment Methods

            cashPayment = new PaymentMethod
            {
                Id = 1,
                Name = "Cash"
            };

            cardPayment = new PaymentMethod
            {
                Id = 2,
                Name = "Card"
            };

            #endregion

            #region Orders

            firstOrder = new Order
            {
                Id = 1,
                UserId = firstUser.Id,
                FirstName = firstUser.FirstName,
                LastName = firstUser.LastName,
                Email = firstUser.Email,
                PhoneNumber = firstUser.PhoneNumber,
                ShoppingCartId = 1,   //First cart
                TotalPrice = 4.00m,
                OrderDetails = "",
                OrderDate = DateTime.UtcNow.AddDays(-5),
                OrderStatusId = deliveredStatus.Id,
                PaymentMethodId = cashPayment.Id,
                ShippingAddress = "First user address",
                OrderProducts = new List<OrderProduct>
                {
                    new OrderProduct
                    {
                        OrderId = 1,
                        ProductId = 1,
                        Price = redRose.Price,
                        Quantity = 1,
                        ProductName = redRose.Name
                    }
                }
            };

            secondOrder = new Order
            {
                Id = 2,
                UserId = secondUser.Id,
                FirstName = secondUser.FirstName,
                LastName = secondUser.LastName,
                Email = secondUser.Email,
                PhoneNumber = secondUser.PhoneNumber,
                ShoppingCartId = 2,  //second cart
                TotalPrice = 39.80m,
                OrderDetails = "",
                OrderDate = DateTime.UtcNow.AddDays(-3),
                OrderStatusId = shippedStatus.Id,
                PaymentMethodId = cardPayment.Id,
                ShippingAddress = "Second user address",
                CardDetailsId = 1,
                CardDetails = new CardDetails
                {
                    Id = 1,
                    UserId = secondUser.Id,
                    CardHolderName = "First User",
                    CardNumber = "1234567890123456",
                    ExpirationDate = "03/35",
                    CVV = "123"
                },
                OrderProducts = new List<OrderProduct>
                {
                    new OrderProduct
                    {
                        OrderId = 2,
                        ProductId = 2,
                        Price = blueOrchid.Price,
                        Quantity = 1,
                        ProductName = blueOrchid.Name
                    },
                    new OrderProduct
                    {
                        OrderId = 2,
                        ProductId = 3,
                        Price = ficusLyrata.Price,
                        Quantity = 1,
                        ProductName = ficusLyrata.Name
                    }
                }
            };

            thirdOrder = new Order
            {
                Id = 3,
                UserId = thirdUser.Id,
                FirstName = thirdUser.FirstName,
                LastName = thirdUser.LastName,
                Email = thirdUser.Email,
                PhoneNumber = thirdUser.PhoneNumber,
                ShoppingCartId = 3,    //third cart
                TotalPrice = 26.30m,
                OrderDetails = "",
                OrderDate = DateTime.UtcNow.AddDays(-2),
                OrderStatusId = pendingStatus.Id,
                PaymentMethodId = cashPayment.Id,
                ShippingAddress = "Third user address",
                OrderProducts = new List<OrderProduct>
                {
                    new OrderProduct
                    {
                        OrderId = 3,
                        ProductId = 1,
                        Price = redRose.Price,
                        Quantity = 1,
                        ProductName = redRose.Name
                    },
                    new OrderProduct
                    {
                        OrderId= 3,
                        ProductId = 3,
                        Price = ficusLyrata.Price,
                        Quantity = 1,
                        ProductName = ficusLyrata.Name
                    }
                }
            };

            #endregion

            users = new List<ApplicationUser>() { firstUser, secondUser, thirdUser };
            categories = new List<Category>() { firstCategory, secondCategory };
            products = new List<Product>() { redRose, blueOrchid, ficusLyrata };
            orderStatuses = new List<OrderStatus>() { pendingStatus, shippedStatus, deliveredStatus };
            payments = new List<PaymentMethod>() { cashPayment, cardPayment };
            orders = new List<Order>() { firstOrder, secondOrder, thirdOrder };

            //Configuration of in-memory db
            var dbOptions = new DbContextOptionsBuilder<FlowerStoreDbContext>()
               .UseInMemoryDatabase("FlowerStoreTestDb" + Guid.NewGuid().ToString())
               .Options;

            dbContext = new FlowerStoreDbContext(dbOptions);

            // Seed data
            await dbContext.AddRangeAsync(users);
            await dbContext.AddRangeAsync(categories);
            await dbContext.AddRangeAsync(products);
            await dbContext.AddRangeAsync(orderStatuses);
            await dbContext.AddRangeAsync(payments);
            await dbContext.AddRangeAsync(orders);
            await dbContext.SaveChangesAsync();

            //Repository initialization
            repository = new Repository(dbContext);

            //UserManager initalization
            var userStore = new UserStore<ApplicationUser>(dbContext);
            var passHash = new PasswordHasher<ApplicationUser>();
            var userManagerOptions = Options.Create(new IdentityOptions());

            userManager = new UserManager<ApplicationUser>(
                userStore,
                userManagerOptions,
                passHash,
                null,
                null,
                null,
                null,
                null,
                null);

            //RoleManager initialization
            var roleStore = new RoleStore<IdentityRole>(dbContext);

            roleManager = new RoleManager<IdentityRole>(
               roleStore,
               null,
               null,
               null,
               null
           );

            //Create roles
            await roleManager.CreateAsync(new IdentityRole { Name = "Administrator" });

            //Assign roles
            await userManager.AddToRoleAsync(firstUser, "Administrator");

            //AdminService initialization
            productService = new ProductService(repository);
            adminService = new AdminService(repository, productService, userManager);
        }

        //Clean db after each test
        [TearDown]
        public async Task Teardown()
        {
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.DisposeAsync();
        }


        //GetPaginatedOrdersAsync tests
        [Test]
        public async Task GetPaginatedOrdersAsync_WhenOrdersAreLessThanPageSize_ReturnsAllOrdersAtSinglePage()
        {
            int page = 1;
            int pageSize = 5; //the seeded orders are 3

            var result = await adminService.GetPaginatedOrdersAsync(page, pageSize);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Orders.Count, Is.EqualTo(3));
                Assert.That(result.CurrentPage, Is.EqualTo(1));
                Assert.That(result.TotalPages, Is.EqualTo(1));
                Assert.That(result.Orders.First().Id, Is.EqualTo(3)); //newest order
                Assert.That(result.Orders.Last().Id, Is.EqualTo(1)); //oldest order
            });
        }

        [Test]
        public async Task GetPaginatedOrdersAsync_WhenOrdersExceedsPageSize_ReturnsOrdersAtNewPage()
        {
            int page = 1;
            int pageSize = 2; //3 orders seeded

            var result = await adminService.GetPaginatedOrdersAsync(page, pageSize);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Orders.Count, Is.EqualTo(2));
                Assert.That(result.CurrentPage, Is.EqualTo(1));
                Assert.That(result.TotalPages, Is.EqualTo(2));
                Assert.That(result.Orders.First().Id, Is.EqualTo(3));
                Assert.That(result.Orders.Last().Id, Is.EqualTo(2));
            });
        }

        [Test]
        public async Task GetPaginatedOrdersAsync_WhenPageNumberExceedsTotalPages_ReturnsEmptyList()
        {
            int page = 5; //too many pages for 3 orders
            int pageSize = 2;

            var result = await adminService.GetPaginatedOrdersAsync(page, pageSize);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Orders, Is.Empty);
                Assert.That(result.CurrentPage, Is.EqualTo(5));
                Assert.That(result.TotalPages, Is.EqualTo(2)); //orders are at 2 pages
            });
        }

        [Test]
        public async Task GetPaginatedOrdersAsync_WhenNoOrdersExist_ReturnsEmptyResult()
        {
            dbContext.RemoveRange(await dbContext.Orders.ToListAsync()); //clear orders
            await dbContext.SaveChangesAsync();

            int page = 1;
            int pageSize = 5;

            var result = await adminService.GetPaginatedOrdersAsync(page, pageSize);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.Orders, Is.Empty);
                Assert.That(result.CurrentPage, Is.EqualTo(1));
                Assert.That(result.TotalPages, Is.EqualTo(0));
            });
        }

        //GetAllOrdersAsync tests
        [Test]
        public async Task GetAllOrdersAsync_WhenOrdersExist_ReturnsAllOrders()
        {
            var result = await adminService.GetAllOrdersAsync();

            var orders = result.ToList();
            var firstOrder = orders.First(o => o.Id == 1);
            var lastOrder = orders.First(o => o.Id == 3);

            Assert.Multiple(() =>  //checking only first and last
            {
                Assert.That(result.Count(), Is.EqualTo(3));

                Assert.That(firstOrder.Id, Is.EqualTo(1));
                Assert.That(firstOrder.UserId, Is.EqualTo(firstUser.Id));
                Assert.That(firstOrder.TotalPrice, Is.EqualTo(4.00m));
                Assert.That(firstOrder.PaymentMethod, Is.EqualTo("Cash"));
                Assert.That(firstOrder.OrderStatus, Is.EqualTo("Delivered"));

                Assert.That(lastOrder.Id, Is.EqualTo(3));
                Assert.That(lastOrder.UserId, Is.EqualTo(thirdUser.Id));
                Assert.That(lastOrder.TotalPrice, Is.EqualTo(26.30m));
                Assert.That(lastOrder.OrderStatus, Is.EqualTo("Pending"));
            });
        }

        [Test]
        public async Task GetAllOrdersAsync_WhenNoOrdersExist_ReturnsEmptyList()
        {
            dbContext.Orders.RemoveRange(dbContext.Orders); //clear orders from db
            await dbContext.SaveChangesAsync();

            var result = await adminService.GetAllOrdersAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        //GetOrderByIdAsync tests
        [Test]
        public async Task GetOrderByIdAsync_WhenOrderExists_ReturnsCorrectOrder()
        {
            var result = await adminService.GetOrderByIdAsync(1); //first order

            Assert.Multiple(() =>
            {
                Assert.That(result.OrderId, Is.EqualTo(1));
                Assert.That(result.UserId, Is.EqualTo(firstUser.Id));
                Assert.That(result.Email, Is.EqualTo(firstUser.Email));
                Assert.That(result.TotalPrice, Is.EqualTo(4.00m));
                Assert.That(result.PaymentMethod, Is.EqualTo("Cash"));
                Assert.That(result.OrderStatus, Is.EqualTo("Delivered"));
                Assert.That(result.OrderDate, Is.EqualTo(firstOrder.OrderDate));
                Assert.That(result.ShippingAddress, Is.EqualTo("First user address"));
                Assert.That(result.OrderProducts.Count, Is.EqualTo(1));
                Assert.That(result.OrderProducts.First().ProductId, Is.EqualTo(1)); //red rose
            });
        }

        [Test]
        public void GetOrderByIdAsync_WhenOrderDoesntExist_ReturnsNull()
        {
            Assert.ThrowsAsync<NullReferenceException>(async () =>
               await adminService.GetOrderByIdAsync(4353));
        }

        [Test]
        public void GetOrderByIdAsync_WhenOrderIdIsInvalid_ThrowsNullException()
        {
            Assert.ThrowsAsync<NullReferenceException>(async () =>
                await adminService.GetOrderByIdAsync(-567));
        }

        [Test]
        public async Task GetOrderByIdAsync_WhenWithNoProducts_ReturnsEmptyOrderProducts()
        {
            var orderWithNoProducts = new Order
            {
                Id = 4,
                UserId = firstUser.Id,
                OrderDate = DateTime.UtcNow,
                TotalPrice = 0.00m,
                OrderStatus = orderStatuses.First(),
                PaymentMethod = cashPayment,
                OrderProducts = new List<OrderProduct>() //empty
            };
            await repository.AddAsync(orderWithNoProducts);
            await repository.SaveChangesAsync();

            var result = await adminService.GetOrderByIdAsync(orderWithNoProducts.Id);

            Assert.That(result.OrderId, Is.EqualTo(orderWithNoProducts.Id));
            Assert.That(result.OrderProducts, Is.Not.Null.And.Empty); 
        }     

        //GetAllOrderStatusesAsync tests
        [Test]
        public async Task GetAllOrderStatusesAsync_WhenOrderStatusesExist_ReturnsAllStatuses()
        {
            var result = await adminService.GetAllOrderStatusesAsync();

            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result.Any(os => os.Id == pendingStatus.Id && os.OrderStatusName == pendingStatus.OrderStatusName));
            Assert.That(result.Any(os => os.Id == shippedStatus.Id && os.OrderStatusName == shippedStatus.OrderStatusName));
            Assert.That(result.Any(os => os.Id == deliveredStatus.Id && os.OrderStatusName == deliveredStatus.OrderStatusName));
        }

        [Test]
        public async Task GetAllOrderStatusesAsync_WhenOrderStatusesDoesntExist_ReturnsEmptyCollection()
        {
            dbContext.OrderStatuses.RemoveRange(orderStatuses); //clear statuses frm db
            await dbContext.SaveChangesAsync();

            var result = await adminService.GetAllOrderStatusesAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Empty);
        }

        //GetOrderForStatusEditingAsync tests
        [Test]
        public async Task GetOrderForStatusEditingAsync_WhenOrderExists_ReturnsCorrectViewModel()
        {
            var result = await adminService.GetOrderForStatusEditingAsync(firstOrder.Id);

            Assert.That(result.OrderId, Is.EqualTo(firstOrder.Id));
            Assert.That(result.CurrentStatus, Is.EqualTo(deliveredStatus.OrderStatusName));
            Assert.That(result.OrderStatuses.Count(), Is.EqualTo(3));
            Assert.That(result.OrderStatuses.Any(os => os.Id == deliveredStatus.Id && os.OrderStatusName == deliveredStatus.OrderStatusName));  //checking just one status
        }

        [Test]
        public void GetOrderForStatusEditingAsync_WhenOrderDoesntExist_ThrowsNullException()
        {
            Assert.ThrowsAsync<NullReferenceException>(async () =>
                await adminService.GetOrderForStatusEditingAsync(-567));
        }

        [Test]
        public async Task GetOrderForStatusEditingAsync_WhenNoOrderStatusesExist_ThrowsNullException()
        {
            dbContext.OrderStatuses.RemoveRange(orderStatuses); //clear statuses from db
            await dbContext.SaveChangesAsync();

            Assert.ThrowsAsync<NullReferenceException>(async () =>
                await adminService.GetOrderForStatusEditingAsync(firstOrder.Id));
        }

        //EditStatusAsync tests
        [Test]
        public async Task EditStatusAsync_WhenOrderExists_UpdatesStatusAndReturnsTrue()
        {
            //change status from shipped to delivered of the second order
            var result = await adminService.EditStatusAsync(secondOrder.Id, deliveredStatus.Id);

            var updatedOrder = await dbContext.Orders.FirstOrDefaultAsync(o => o.Id == secondOrder.Id);

            Assert.That(result, Is.True);
            Assert.That(updatedOrder!.OrderStatusId, Is.EqualTo(deliveredStatus.Id));
        }

        [Test]
        public async Task EditStatusAsync_WhenOrderDoesntExist_ReturnsFalse()
        {
            var result = await adminService.EditStatusAsync(43534, shippedStatus.Id);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task EditStatusAsync_WhenStatusIdIsInvalid_ThrowsInvalidOperationException()
        {
            var result = await adminService.EditStatusAsync(firstOrder.Id, 4848);

            Assert.That(result, Is.False);
        }

        [Test]
        public async Task EditStatusAsync_WhenStatusIsUnchanged_ChangesNothing()
        {
            var result = await adminService.EditStatusAsync(firstOrder.Id, deliveredStatus.Id);

            var updatedOrder = await dbContext.Orders.FirstOrDefaultAsync(o => o.Id == firstOrder.Id);

            Assert.That(updatedOrder!.OrderStatusId, Is.EqualTo(deliveredStatus.Id));
        }

        //GetAllUsersAsync Tests
        [Test]
        public async Task GetAllUsersAsync_WhenUsersExists_ReturnsAllUsersWithTheirRoles()
        {
            var result = await adminService.GetAllUsersAsync();

            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result.Any(u => u.IsAdmin && u.Username == firstUser.UserName), Is.True);
            Assert.That(result.Any(u => !u.IsAdmin && u.Username == secondUser.UserName), Is.True);
            Assert.That(result.Any(u => !u.IsAdmin && u.Username == thirdUser.UserName), Is.True);
        }

        [Test]
        public async Task GetAllUsersAsync_WhenNoUsersExists_ReturnsEmptyList()
        {
            var allUsers = await dbContext.Users.ToListAsync();

            dbContext.Users.RemoveRange(users); //clear all users from db
            await dbContext.SaveChangesAsync();

            var result = await adminService.GetAllUsersAsync();

            Assert.That(result, Is.Empty);
        }

        [Test]
        public async Task GetAllUsersAsync_WhenUsersAreWithoutAdminRoles_IsAdminIsFalse()
        {
            var result = await adminService.GetAllUsersAsync();

            Assert.That(result.Any(u => u.Username == secondUser.UserName && u.IsAdmin), Is.False);
            Assert.That(result.Any(u => u.Username == thirdUser.UserName && u.IsAdmin), Is.False);
        }

        [Test]
        public async Task GetAllUsersAsync_WhenMultipleAdminsExists_ReturnAllUsersWithAdmins()
        {
            await userManager.AddToRoleAsync(secondUser, "Administrator");

            var result = await adminService.GetAllUsersAsync();

            Assert.That(result.Count(u => u.IsAdmin), Is.EqualTo(2));
            Assert.That(result.Any(u => u.Username == firstUser.UserName && u.IsAdmin), Is.True);
            Assert.That(result.Any(u => u.Username == secondUser.UserName && u.IsAdmin), Is.True);
            Assert.That(result.Any(u => u.Username == thirdUser.UserName && u.IsAdmin), Is.False);
        }

        //GetUserDetailsAsync tests
        [Test]
        public async Task GetUserDetailsAsync_WnehUserIdIsValid_ReturnsCorrectDetails()
        {
            var result = await adminService.GetUserDetailsAsync(firstUser.Id);

            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(firstUser.Id));
                Assert.That(result.Username, Is.EqualTo(firstUser.UserName));
                Assert.That(result.Email, Is.EqualTo(firstUser.Email));
                Assert.That(result.FirstName, Is.EqualTo(firstUser.FirstName));
                Assert.That(result.PhoneNumber, Is.EqualTo(firstUser.PhoneNumber));
            });
        }

        [Test]
        public void GetUserDetailsAsync_WhenUserDoesntExists_ThrowsNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await adminService.GetUserDetailsAsync("nonExistingUserId"));
        }

        [Test]
        public void GetUserDetailsAsync_WhenUserIdIsInvalid_ThrowsNullException()
        {
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await adminService.GetUserDetailsAsync(null));

            Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await adminService.GetUserDetailsAsync(string.Empty));
        }

        [Test]
        public async Task GetUserDetailsAsync_WhenUsersContainsRoles_ReturnsUsersWithRoles()
        {
            var first = await adminService.GetUserDetailsAsync(firstUser.Id);
            var third = await adminService.GetUserDetailsAsync(thirdUser.Id);

            Assert.That(first.Roles, Contains.Item("Administrator"));
            Assert.That(third.Roles, Is.Empty);
        }

        //GetUserByIdAsync tests
        [Test]
        public async Task GetUserByIdAsync_WhenUserIdIsValid_ReturnsUserCorrectly()
        {
            var result = await adminService.GetUserByIdAsync(firstUser.Id);

            Assert.That(result.Id, Is.EqualTo(firstUser.Id));
            Assert.That(result.UserName, Is.EqualTo(firstUser.UserName));
            Assert.That(result.Email, Is.EqualTo(firstUser.Email));
        }

        [Test]
        public async Task GetUserByIdAsync_WhenNonExistentUserId_ReturnsNull()
        {
            var result = await adminService.GetUserByIdAsync("nonExistentUserId");

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetUserByIdAsync_WhenUserIdIsInvalid_ReturnsNull()
        {
            var nullUserId = await adminService.GetUserByIdAsync(null);
            var emptyUserId = await adminService.GetUserByIdAsync(string.Empty);

            Assert.That(nullUserId, Is.Null);
            Assert.That(emptyUserId, Is.Null);
        }

        //AddProductAsync Tests
        [Test]
        public async Task AddProductAsync_WhenProductIsValid_AddsProductSuccessfully()
        {
            var model = new ProductAddViewModel
            {
                Name = "Test Product",
                Price = 10.00m,
                ImageUrl = "http://testflowerurl.com/flower.jpg",
                FullDescription = "Some test product description",
                FlowersCount = 5,
                CategoryId = firstCategory.Id
            };

            var productId = await adminService.AddProductAsync(model);
            var product = await dbContext.Products.FindAsync(productId);

            Assert.Multiple(() =>
            {
                Assert.That(product!.Name, Is.EqualTo(model.Name));
                Assert.That(product.Price, Is.EqualTo(model.Price));
                Assert.That(product.Availability, Is.True);
                Assert.That(product.FlowersCount, Is.EqualTo(model.FlowersCount));
                Assert.That(product.CategoryId, Is.EqualTo(model.CategoryId));
            });
        }

        [Test]
        public async Task AddProductAsync_WhenFlowersCountIsZero_AddsItAndSetsAvailabilityToFalse()
        {
            var model = new ProductAddViewModel
            {
                Name = "Test Product",
                Price = 10.00m,
                ImageUrl = "http://testflowerurl.com/flower.jpg",
                FullDescription = "Some test product description",
                FlowersCount = 0,
                CategoryId = firstCategory.Id
            };

            var productId = await adminService.AddProductAsync(model);
            var product = await dbContext.Products.FindAsync(productId);

            Assert.That(product, Is.Not.Null);
            Assert.That(product.Availability, Is.False);
        }

        //Other tests are redundant because validations are handled in the controller

        //GetEditProductAsync tests
        [Test]
        public async Task GetEditProductAsync_WithProductIdIsValid_ReturnsCorrectDetailsForProductEditing()
        {
            var result = await adminService.GetEditProductAsync(redRose.Id);

            Assert.Multiple(() =>
            {
                Assert.That(result.Id, Is.EqualTo(redRose.Id));
                Assert.That(result.Name, Is.EqualTo(redRose.Name));
                Assert.That(result.Price, Is.EqualTo(redRose.Price));
                Assert.That(result.CategoryId, Is.EqualTo(redRose.CategoryId));
                Assert.That(result.Categories.Any(), Is.True); //has category
            });
        }

        [Test]
        public void GetEditProductAsync_WithProductIdIsInvalid_ThrowsNullReference()
        {
            Assert.ThrowsAsync<NullReferenceException>(async () =>
                await adminService.GetEditProductAsync(5645645));
        }

        [Test]
        public async Task GetEditProductAsync_IncludesCategoriesInViewModel()
        {
            var result = await adminService.GetEditProductAsync(redRose.Id);

            Assert.IsNotNull(result);
            Assert.That(result.Categories, Is.Not.Null.And.Not.Empty);
            Assert.That(result.Categories.Count(), Is.EqualTo(categories.Count())); //all categories
            Assert.That(result.Categories.Any(c => c.Id == firstCategory.Id), Is.True); //product in category
        }

        //PostEditProductAsync tests
        [Test]
        public async Task PostEditProductAsync_WithValidDetails_EditsProductCorrectly()
        {
            var updatedModel = new ProductEditViewModel
            {
                Id = redRose.Id,
                Name = "Updated Red Rose",
                Price = 15.99m,
                ImageUrl = "https://img.freepik.com/premium-photo/red-roses-pot-isolated-white-background_511010-2090.jpg",
                FullDescription = "Updated red rose test description",
                DateAdded = redRose.DateAdded,
                FlowersCount = 20,
                CategoryId = secondCategory.Id
            };

            var result = await adminService.PostEditProductAsync(updatedModel);

            var updatedProduct = await repository
                .AllAsReadOnly<Product>()
                .FirstOrDefaultAsync(p => p.Id == redRose.Id);

            Assert.Multiple(() =>
            {
                Assert.That(updatedProduct!.Name, Is.EqualTo(updatedModel.Name));
                Assert.That(updatedProduct.Price, Is.EqualTo(updatedModel.Price));
                Assert.That(updatedProduct.FullDescription, Is.EqualTo(updatedModel.FullDescription));
                Assert.That(updatedProduct.FlowersCount, Is.EqualTo(updatedModel.FlowersCount));
                Assert.That(updatedProduct.Availability, Is.True);
                Assert.That(updatedProduct.CategoryId, Is.EqualTo(updatedModel.CategoryId));
            });
        }

        [Test]
        public async Task PostEditProductAsync_WithValidDataButZeroFlowersCount_EditsAndSetsAvailabilityCorrectly()
        {
            var updatedModel = new ProductEditViewModel
            {
                Id = redRose.Id,
                Name = "Updated Red Rose",
                Price = 15.99m,
                ImageUrl = "https://img.freepik.com/premium-photo/red-roses-pot-isolated-white-background_511010-2090.jpg",
                FullDescription = "Updated red rose test description",
                DateAdded = redRose.DateAdded,
                FlowersCount = 0,
                CategoryId = secondCategory.Id
            };

            var result = await adminService.PostEditProductAsync(updatedModel);

            var updatedProduct = await repository
                .AllAsReadOnly<Product>()
                .FirstOrDefaultAsync(p => p.Id == redRose.Id);

            Assert.Multiple(() =>
            {
                Assert.That(updatedProduct!.Name, Is.EqualTo(updatedModel.Name));
                Assert.That(updatedProduct.Price, Is.EqualTo(updatedModel.Price));
                Assert.That(updatedProduct.FullDescription, Is.EqualTo(updatedModel.FullDescription));
                Assert.That(updatedProduct.FlowersCount, Is.EqualTo(updatedModel.FlowersCount));
                Assert.That(updatedProduct.Availability, Is.False);
                Assert.That(updatedProduct.CategoryId, Is.EqualTo(updatedModel.CategoryId));
            });
        }

        [Test]
        public void PostEditProductAsync_WithProductIdIsInvalid_ThrowsNullException()
        {
            var invalidModel = new ProductEditViewModel
            {
                Id = 5474574, //invalid id
                Name = "Updated Red Rose",
                Price = 15.99m,
                ImageUrl = "https://img.freepik.com/premium-photo/red-roses-pot-isolated-white-background_511010-2090.jpg",
                FullDescription = "Updated red rose test description",
                DateAdded = redRose.DateAdded,
                FlowersCount = 20,
                CategoryId = secondCategory.Id
            };

            Assert.ThrowsAsync<NullReferenceException>(async () => await adminService.PostEditProductAsync(invalidModel));
        }

        //DeleteProductAsync tests
        [Test]
        public async Task DeleteProductAsync_WithValidProductId_ReturnsCorrectDeleteViewModel()
        {
            var result = await adminService.DeleteProductAsync(blueOrchid.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(blueOrchid.Id));
            Assert.That(result.Name, Is.EqualTo(blueOrchid.Name));
        }

        [Test]
        public void DeleteProductAsync_WithInvalidProductId_ThrowsNullException()
        {
            Assert.ThrowsAsync<NullReferenceException>(async () =>
                await adminService.DeleteProductAsync(6575));
        }

        //ConfirmDeleteAsync tests
        [Test]
        public async Task ConfirmDeleteAsync_WithValidProductId_DeletesProductAndReturnsDeletedId()
        {
            var result = await adminService.ConfirmDeleteAsync(ficusLyrata.Id);

            var deletedProduct = await repository
                .AllAsReadOnly<Product>()
                .FirstOrDefaultAsync(p => p.Id == ficusLyrata.Id);

            Assert.That(result, Is.EqualTo(ficusLyrata.Id));
            Assert.That(deletedProduct, Is.Null);
        }

        [Test]
        public void ConfirmDeleteAsync_WithInvalidProductId_ThrowsException()
        {
            Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await adminService.ConfirmDeleteAsync(456456));
        }

        [Test]
        public async Task ConfirmDeleteAsync_WhenValidProductId_RemovesProductFromDatabase()
        {
            await adminService.ConfirmDeleteAsync(redRose.Id);

            var exists = await repository
                .AllAsReadOnly<Product>()
                .AnyAsync(p => p.Id == redRose.Id);

            Assert.That(exists, Is.False);
        }

        //GetLowStockProductsAsync tests
        [Test]
        public async Task GetLowStockProductsAsync_WithDefaultThreshold_ReturnsProductsAtOrBelowThreshold()
        {
            int threshold = 3;

            var result = await adminService.GetLowStockProductsAsync(threshold); //roses are 3

            Assert.That(result.All(p => p.FlowersCount <= threshold), Is.True);
            Assert.That(result.Count(), Is.EqualTo(1)); //only roses
        }

        [Test]
        public async Task GetLowStockProductsAsync_WithNoLowStockProducts_ReturnsEmptyList()
        {
            var result = await adminService.GetLowStockProductsAsync(1);

            Assert.That(result, Is.Not.Null.And.Empty);
        }

        [Test]
        public async Task GetLowStockProductsAsync_WithHighThreshold_ReturnsAllProducts()
        {
            int threshold = 364;

            var result = await adminService.GetLowStockProductsAsync(threshold); //should return all

            Assert.That(result, Is.Not.Null.And.Not.Empty);
            Assert.That(result.Count(), Is.EqualTo(products.Count()));
        }

        [Test]
        public async Task GetLowStockProductsAsync_WhenthreshholdIsFive_ReturnsOnlyTwoProducts()
        {
            var treshold = 5;

            var result = await adminService.GetLowStockProductsAsync(treshold);

            var firstProduct = result.First(); //rose
            var secondProduct = result.Last();  //ficus

            Assert.Multiple(() =>
            {
                Assert.That(firstProduct.Id, Is.EqualTo(redRose.Id));
                Assert.That(firstProduct.Name, Is.EqualTo(redRose.Name));
                Assert.That(firstProduct.FlowersCount, Is.EqualTo(redRose.FlowersCount));

                Assert.That(secondProduct.Id, Is.EqualTo(ficusLyrata.Id));
                Assert.That(secondProduct.Name, Is.EqualTo(ficusLyrata.Name));
                Assert.That(secondProduct.FlowersCount, Is.EqualTo(ficusLyrata.FlowersCount));
            });
        }
    }
}
