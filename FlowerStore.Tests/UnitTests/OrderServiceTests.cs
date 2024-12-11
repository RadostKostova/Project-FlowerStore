using FlowerStore.Core.Contracts;
using FlowerStore.Core.Services;
using FlowerStore.Core.ViewModels.CardDetails;
using FlowerStore.Core.ViewModels.Cart;
using FlowerStore.Core.ViewModels.CartProduct;
using FlowerStore.Core.ViewModels.Order;
using FlowerStore.Core.ViewModels.OrderProduct;
using FlowerStore.Infrastructure.Common;
using FlowerStore.Infrastructure.Data;
using FlowerStore.Infrastructure.Data.Models;
using FlowerStore.Infrastructure.Data.Models.Cart;
using FlowerStore.Infrastructure.Data.Models.Carts;
using FlowerStore.Infrastructure.Data.Models.Orders.Order;
using FlowerStore.Infrastructure.Data.Models.Payment;
using FlowerStore.Infrastructure.Data.Models.Roles;
using Microsoft.EntityFrameworkCore;

namespace FlowerStore.Tests.UnitTests
{
    [TestFixture]
    internal class OrderServiceTests
    {
        //Dependencies
        private FlowerStoreDbContext dbContext;
        private IRepository repository;
        private IProductService productService;
        private ICartService cartService;
        private IOrderService orderService;

        //Collections
        private IEnumerable<ApplicationUser> users;
        private IEnumerable<Category> categories;
        private IEnumerable<Product> products;
        private IEnumerable<ShoppingCart> carts;
        private IEnumerable<PaymentMethod> paymentMethods;
        private IEnumerable<OrderStatus> orderStatuses;
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

        //Shopping Carts
        private ShoppingCart firstCart;
        private ShoppingCart secondCart;
        private ShoppingCart thirdCart;

        //Payment methods
        private PaymentMethod cashPayment;
        private PaymentMethod cardPayment;

        //Order statuses
        private OrderStatus pendingStatus;
        private OrderStatus shippedStatus;
        private OrderStatus deliveredStatus;

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
                NormalizedUserName = "THIRDUSER@THIRDUSER.COM",
                Email = "thirduser@thirduser.com",
                NormalizedEmail = "THIRDUSER@THIRDUSER.COM",
                FirstName = "Third",
                LastName = "User",
                PhoneNumber = "1234567000"
            };
            #endregion

            #region Categories
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

            #region ShoppingCarts
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

            thirdCart = new ShoppingCart
            {
                Id = 3,
                UserId = thirdUser.Id,
                ProductsCounter = 2,
                TotalPrice = 26.30m,
                ShoppingCartProducts = new List<ShoppingCartProduct>
                {
                    new ShoppingCartProduct
                    {
                        ProductId = 1,
                        ShoppingCartId = 3,
                        Quantity = 1,
                        Price = redRose.Price //4.00
                    },
                    new ShoppingCartProduct
                    {
                        ProductId = 3,
                        ShoppingCartId = 3,
                        Quantity = 1,
                        Price = ficusLyrata.Price  //22.30
                    }
                }
            };
            #endregion

            #region PaymentMethods
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

            #region OrderStatuses
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

            #region Orders
            firstOrder = new Order
            {
                Id = 1,
                UserId = firstUser.Id,
                FirstName = firstUser.FirstName,
                LastName = firstUser.LastName,
                Email = firstUser.Email,
                PhoneNumber = firstUser.PhoneNumber,
                ShoppingCartId = firstCart.Id,
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
                ShoppingCartId = secondCart.Id,
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
                ShoppingCartId = thirdCart.Id,
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
            carts = new List<ShoppingCart> { firstCart, secondCart, thirdCart };
            paymentMethods = new List<PaymentMethod> { cashPayment, cardPayment };
            orderStatuses = new List<OrderStatus> { pendingStatus, shippedStatus, deliveredStatus };
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
            await dbContext.AddRangeAsync(carts);
            await dbContext.AddRangeAsync(paymentMethods);
            await dbContext.AddRangeAsync(orderStatuses);
            await dbContext.AddRangeAsync(orders);
            await dbContext.SaveChangesAsync();

            //Repository initialization
            repository = new Repository(dbContext);

            //Service initializations
            productService = new ProductService(repository);
            cartService = new CartService(repository, productService);
            orderService = new OrderService(repository, cartService, productService);
        }

        //Clean db after each test
        [TearDown]
        public async Task Teardown()
        {
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.DisposeAsync();
        }


        //OrderByIdExistAsync tests
        [Test]
        public async Task OrderByIdExistAsync_WhenOrderExists_ReturnsCorrectOrder()
        {
            var result = await orderService.OrderByIdExistAsync(firstOrder.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(firstOrder.Id));
            Assert.That(result.UserId, Is.EqualTo(firstUser.Id));
            Assert.That(result.ShoppingCart.ShoppingCartProducts.First().Product.Name, Is.EqualTo(redRose.Name));
        }

        [Test]
        public async Task OrderByIdExistAsync_WhenOrderDoesntExist_ReturnsNull()
        {
            var result = await orderService.OrderByIdExistAsync(43593845);

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task OrderByIdExistAsync_WhenInvalidOrderId_ReturnsNull()
        {
            var result = await orderService.OrderByIdExistAsync(-6);

            Assert.That(result, Is.Null);
        }

        //GetAllPaymentMethodsAsync() tests 
        [Test]
        public async Task GetAllPaymentMethodsAsync_WhenPaymentMethodsExist_ReturnsAllMethods()
        {
            var result = await orderService.GetAllPaymentMethodsAsync();

            var cashResult = result.FirstOrDefault(p => p.Id == cashPayment.Id);
            var cardResult = result.FirstOrDefault(p => p.Id == cardPayment.Id);

            Assert.Multiple(() =>
            {
                Assert.That(result.Count(), Is.EqualTo(2));

                Assert.That(cashResult!.Id, Is.EqualTo(1));
                Assert.That(cashResult!.Name, Is.EqualTo(cashPayment.Name));

                Assert.That(cardResult!.Id, Is.EqualTo(2));
                Assert.That(cardResult!.Name, Is.EqualTo(cardPayment.Name));
            });
        }

        [Test]
        public async Task GetAllPaymentMethodsAsync_WhenPaymentMethodsDoesntExist_ReturnsEmptyCollection()
        {
            dbContext.RemoveRange(paymentMethods); //clear all payments
            await dbContext.SaveChangesAsync();

            var result = await orderService.GetAllPaymentMethodsAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Empty);
        }

        //GetAllOrderStatusesAsync test
        [Test]
        public async Task GetAllOrderStatusesAsync_WhenOrderStatusesExist_ReturnsAllStatuses()
        {
            var result = await orderService.GetAllOrderStatusesAsync();

            var pending = result.FirstOrDefault(os => os.Id == 1);
            var shipped = result.FirstOrDefault(os => os.Id == 2);
            var delivered = result.FirstOrDefault(os => os.Id == 3);

            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(pending!.OrderStatusName, Is.EqualTo("Pending"));
            Assert.That(shipped!.OrderStatusName, Is.EqualTo("Shipped"));
            Assert.That(delivered!.OrderStatusName, Is.EqualTo("Delivered"));
        }

        [Test]
        public async Task GetAllOrderStatusesAsync_WhenOrderStatusesDoesntExist_ReturnsEmpty()
        {
            dbContext.RemoveRange(dbContext.OrderStatuses); //clear all statuses
            await dbContext.SaveChangesAsync();

            var result = await orderService.GetAllOrderStatusesAsync();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.Empty);
        }

        //GetChosenPaymentMethodAsync Tests
        [Test]
        public async Task GetChosenPaymentMethodAsync_WhenPaymentMethodExists_ReturnsPaymentMethod()
        {
            var result = await orderService.GetChosenPaymentMethodAsync(cardPayment.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id, Is.EqualTo(cardPayment.Id));
            Assert.That(result.Name, Is.EqualTo(cardPayment.Name));
        }

        [Test]
        public async Task GetChosenPaymentMethodAsync_WhenPaymentMethodDoesntExist_ReturnsNull()
        {
            var result = await orderService.GetChosenPaymentMethodAsync(345345);

            Assert.That(result, Is.Null);
        }

        //CreateOrderViewModelAsync test (only positive - other scenarios are handled in the controller)
        [Test]
        public async Task CreateOrderViewModelAsync_WhenInputIsValid_ReturnsProperViewModel()
        {
            var formModel = new OrderFormViewModel  //shipping details form
            {
                Id = 5,
                ShippingAddress = "New Order Address",
                OrderDetails = "",
                PaymentMethodId = cashPayment.Id,
                FirstName = "NewUserFirstName",
                LastName = "NewUserLastName",
                PhoneNumber = "0987609876",
                Email = "newuser@newuser.com"
            };

            var cart = new ShoppingCart   //shopping cart 
            {
                Id = 5,
                UserId = "newUserId",
                ProductsCounter = 2,
                TotalPrice = 8.00m,
                ShoppingCartProducts = new List<ShoppingCartProduct>
                {
                    new ShoppingCartProduct  //products in shopping cart
                    {
                        ProductId = redRose.Id,
                        Quantity = 2,
                        Price = redRose.Price,
                        ShoppingCartId = 5,
                        Product = redRose
                    }
                }
            };

            var cartModel = new CartViewModel  //cart as viewModel
            {
                Id = cart.Id,
                UserId = cart.UserId,
                ProductsCounter = cart.ProductsCounter,
                TotalPrice = cart.TotalPrice,
                ShoppingCartProducts = cart.ShoppingCartProducts.Select(cp => new CartProductViewModel
                {
                    ProductId = cp.ProductId,
                    Name = cp.Product.Name,
                    Quantity = cp.Quantity,
                    UnitPrice = cp.Price,
                    ImageUrl = cp.Product.ImageUrl,
                    Category = cp.Product.Category.Name
                }).ToList()

            };

            await dbContext.ShoppingCarts.AddAsync(cart);
            await dbContext.SaveChangesAsync();

            var result = await orderService.CreateOrderViewModelAsync(formModel, cartModel);
            var orderedProducts = result.OrderProducts.FirstOrDefault(op => op.ProductId == 1); //roses            

            Assert.Multiple(() =>
            {
                //validate basic details
                Assert.That(result.UserId, Is.EqualTo(cart.UserId));
                Assert.That(result.ShippingAddress, Is.EqualTo(formModel.ShippingAddress));
                Assert.That(result.PaymentMethodId, Is.EqualTo(formModel.PaymentMethodId));
                Assert.That(result.PhoneNumber, Is.EqualTo(formModel.PhoneNumber));
                Assert.That(result.Email, Is.EqualTo(formModel.Email));
                Assert.That(result.ShoppingCartId, Is.EqualTo(cart.Id));
                Assert.That(result.TotalPrice, Is.EqualTo(cart.ShoppingCartProducts.Sum(p => p.Quantity * p.Price)));

                //validate payment method and order status
                Assert.That(result.PaymentMethods.Any(pm => pm.Id == cashPayment.Id && pm.Name == "Cash"));
                Assert.That(result.OrderStatuses.Any(os => os.Id == os.Id && os.OrderStatusName == "Pending"));

                //validate ordered products
                Assert.That(result.OrderProducts.Count, Is.EqualTo(1));
                Assert.That(orderedProducts!.ProductName, Is.EqualTo(redRose.Name));
                Assert.That(orderedProducts.Quantity, Is.EqualTo(2));
            });
        }

        //CreateOrderAsync tests (only positive - other scenarios are handled in the controller)
        [Test]
        public async Task CreateOrderAsync_WhenInputIsValid_CreatesOrderAndUpdatesProductCountSuccessfully()
        {
            // Arrange
            var model = new OrderViewModel
            {
                UserId = "newUserId",
                OrderDate = DateTime.UtcNow,
                TotalPrice = 8.00m,
                OrderDetails = "",
                ShippingAddress = "New Order Address",
                OrderStatusId = 1,  //pending
                PaymentMethodId = cashPayment.Id,
                ShoppingCartId = 5,
                FirstName = "NewUserFistName",
                LastName = "NewUserLastName",
                PhoneNumber = "0987609876",
                Email = "newuser@newuser.com",
                OrderProducts = new List<OrderProductViewModel>
                {
                    new OrderProductViewModel
                    {
                        ProductId = redRose.Id,
                        ProductName = redRose.Name,
                        Price = redRose.Price,
                        Quantity = 2
                    }
                }
            };

            var cart = new ShoppingCart
            {
                Id = 5,
                UserId = "newUserId",
                ProductsCounter = 2,
                TotalPrice = 8.00m,
                ShoppingCartProducts = new List<ShoppingCartProduct>
                {
                    new ShoppingCartProduct
                    {
                        ProductId = redRose.Id,
                        Product = redRose,
                        Quantity = 2,  //it was 3 at db
                        Price = redRose.Price,
                        ShoppingCartId = 5
                    }
                }
            };

            await dbContext.ShoppingCarts.AddAsync(cart);
            await dbContext.SaveChangesAsync();

            var newOrderId = await orderService.CreateOrderAsync(model, null);

            var orderResult = await dbContext.Orders.FirstOrDefaultAsync(o => o.Id == newOrderId);
            var orderProducts = await dbContext.OrdersProducts.FirstOrDefaultAsync(op => op.OrderId == newOrderId);

            Assert.Multiple(() =>
            {
                Assert.That(newOrderId, !Is.EqualTo(0));
                Assert.That(orderResult!.UserId, Is.EqualTo(model.UserId));
                Assert.That(orderResult.TotalPrice, Is.EqualTo(model.TotalPrice));
                Assert.That(orderResult.ShippingAddress, Is.EqualTo(model.ShippingAddress));
                Assert.That(orderResult.OrderStatusId, Is.EqualTo(model.OrderStatusId));
                Assert.That(orderResult.PaymentMethodId, Is.EqualTo(model.PaymentMethodId));
                Assert.That(orderResult.ShoppingCartId, Is.EqualTo(model.ShoppingCartId));
                Assert.That(orderResult.OrderProducts.Count, Is.EqualTo(1));
                Assert.That(redRose.Id, Is.EqualTo(orderProducts!.ProductId));
            });

            //verify that the count of the product is updated
            var updatedRedRose = await productService.GetProductDetailsAsync(redRose.Id);
            Assert.That(updatedRedRose.FlowersCount, Is.EqualTo(1)); //3 - 2
        }

        //CreateCardDetailsAsync tests
        [Test]
        public async Task CreateCardDetailsAsync_WhenInputIsValid_CreatesCardDetailsSuccessfully()
        {
            var model = new CardDetailsAddViewModel
            {
                UserId = "newUserId",
                CardHolderName = "New User",
                CardNumber = "1234567812345678",
                ExpirationDate = "04/26",
                CVV = "123"
            };

            var newCardId = await orderService.CreateCardDetailsAsync(model);
            var cardDetails = await dbContext.CardDetails.FirstOrDefaultAsync(cd => cd.Id == newCardId);

            Assert.That(newCardId, Is.GreaterThan(0));
            Assert.That(cardDetails, Is.Not.Null);
            Assert.That(cardDetails!.UserId, Is.EqualTo(model.UserId));
            Assert.That(cardDetails.CardHolderName, Is.EqualTo(model.CardHolderName));
            Assert.That(cardDetails.ExpirationDate, Is.EqualTo(model.ExpirationDate));
            Assert.That(cardDetails.CVV, Is.EqualTo(model.CVV));
        }

        //GetAllOrdersByUserIdAsync tests
        [Test]
        public async Task GetAllOrdersByUserIdAsync_WhenUserHasOneOrder_ReturnsCorrectOrderDetails()
        {
            var result = await orderService.GetAllOrdersByUserIdAsync(thirdUser.Id);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(1));

            var order = result.FirstOrDefault(o => o.UserId == thirdUser.Id);

            Assert.Multiple(() =>
            {
                Assert.That(order!.OrderId, Is.EqualTo(3));
                Assert.That(order.UserId, Is.EqualTo(thirdUser.Id));
                Assert.That(order.FirstName, Is.EqualTo("Third"));
                Assert.That(order.Email, Is.EqualTo("thirduser@thirduser.com"));
                Assert.That(order.TotalPrice, Is.EqualTo(26.30m));
                Assert.That(order.PaymentMethod, Is.EqualTo("Cash"));

                Assert.That(order.OrderProducts.Count, Is.EqualTo(2));
                Assert.That(order.OrderProducts.Any(p => p.ProductName == redRose.Name && p.Quantity == 1));
                Assert.That(order.OrderProducts.Any(p => p.ProductName == ficusLyrata.Name && p.Quantity == 1));
            });
        }

        [Test]
        public async Task GetAllOrdersByUserIdAsync_WhenUserHasNoOrders_ReturnsEmptyCollection()
        {
            var result = await orderService.GetAllOrdersByUserIdAsync("nonExistentUserId");

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(0));
        }

        [Test]
        public async Task GetAllOrdersByUserIdAsync_WhenUserHasTwoOrMoreOrders_ReturnsAllOrdersForThatUser()
        {
            var newOrder = new Order  //additional order
            {
                UserId = firstUser.Id,
                FirstName = "First",
                LastName = "User",
                Email = "firstuser@firstuser.com",
                PhoneNumber = "1234567890",
                OrderDate = DateTime.UtcNow,
                TotalPrice = 50.00m,
                PaymentMethodId = cashPayment.Id,
                OrderStatusId = pendingStatus.Id,
                ShippingAddress = "First user address",
                OrderDetails = "",
                OrderProducts = new List<OrderProduct>
                {
                    new OrderProduct
                    {
                        ProductId = redRose.Id,
                        ProductName = redRose.Name,
                        Quantity = 3,
                        Price = redRose.Price
                    }
                }
            };

            await dbContext.Orders.AddAsync(newOrder);
            await dbContext.SaveChangesAsync();

            var result = await orderService.GetAllOrdersByUserIdAsync(firstUser.Id);

            Assert.That(result.Count(), Is.EqualTo(2));
            Assert.That(result.All(o => o.UserId == firstUser.Id));
            Assert.That(result.Any(o => o.OrderId == firstOrder.Id), Is.True);
            Assert.That(result.Any(o => o.OrderId == newOrder.Id), Is.True);
        }

        //GetOrderDetailsAsync tests
        [Test]
        public async Task GetOrderDetailsAsync_WhenOrderExistsByThatUser_ReturnsDetailedOrder()
        {
            var result = await orderService.GetOrderDetailsAsync(firstOrder.Id, firstUser.Id);

            Assert.That(result!.OrderId, Is.EqualTo(firstOrder.Id));  
            Assert.That(result.UserId, Is.EqualTo(firstUser.Id));
            Assert.That(result.OrderProducts.Count, Is.EqualTo(1));
            Assert.That(result.OrderProducts.Any(p => p.ProductName == redRose.Name && p.Quantity == 1));
        }

        [Test]
        public async Task GetOrderDetailsAsync_WhenOrderDoesntExist_ReturnsNull()
        {
            var result = await orderService.GetOrderDetailsAsync(123456, firstUser.Id); 

            Assert.That(result, Is.Null);
        }

        [Test]
        public async Task GetOrderDetailsAsync_WhenOrderBelongsToDifferentUser_ReturnsNull()
        {
            var result = await orderService.GetOrderDetailsAsync(firstOrder.Id, secondUser.Id);

            Assert.That(result, Is.Null);
        }

        //CalcuateTotalPrice
        [Test]
        public void CalculateTotalPrice_WhenCartHasProducts_ReturnsCorrectTotalPrice()
        {          
            var result = orderService.CalculateTotalPrice(thirdCart);

            Assert.That(result, Is.EqualTo(26.30m)); // 4 + 22.30
        }

        [Test]
        public void CalculateTotalPrice_WhenCartIsEmpty_ReturnsZero()
        {
            var cart = new ShoppingCart
            {
                ShoppingCartProducts = new List<ShoppingCartProduct>() //empty
            };

            var result = orderService.CalculateTotalPrice(cart);

            Assert.That(result, Is.EqualTo(0m));
        }

        [Test]
        public void CalculateTotalPrice_WhenCartProductsIsNull_ThrowsNullException()
        {
            var cart = new ShoppingCart
            {
                ShoppingCartProducts = null
            };

            Assert.Throws<ArgumentNullException>(() => orderService.CalculateTotalPrice(cart));
        }
    }
}
