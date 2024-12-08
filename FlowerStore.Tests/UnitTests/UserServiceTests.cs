using FlowerStore.Core.Contracts;
using FlowerStore.Core.Services;
using FlowerStore.Infrastructure.Common;
using FlowerStore.Infrastructure.Data;
using FlowerStore.Infrastructure.Data.Models.Orders.Order;
using FlowerStore.Infrastructure.Data.Models.Roles;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FlowerStore.Tests.UnitTests
{
    [TestFixture]
    internal class UserServiceTests
    {
        //Dependencies
        private FlowerStoreDbContext dbContext;
        private IRepository repository;
        private IUserService userService;
        private UserManager<ApplicationUser> userManager;

        //Collections
        private IEnumerable<ApplicationUser> users;
        private IEnumerable<Order> orders;

        //Users
        private ApplicationUser firstUser;
        private ApplicationUser secondUser;
        private ApplicationUser thirdUser;

        //Orders
        private Order firstOrderOfFirstUser;
        private Order secondOrderOfFirstUser;
        private Order firstOrderOfSecondUser;

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

            firstOrderOfFirstUser = new Order
            {
                Id = 1,
                UserId = firstUser.Id,
                OrderDate = new DateTime(2024, 12, 4, 12, 00, 00, DateTimeKind.Utc), //Fixed date
                OrderDetails = "Provide Birthday card for a woman, please",
                FirstName = "First",
                LastName = "User",
                PhoneNumber = "1234567890",
                TotalPrice = 50.00m,
                ShippingAddress = "Test Street 123",
                PaymentMethodId = 1,
                OrderStatusId = 1,
                ShoppingCartId = 1,
                Email = "firstuser@firstuser.com"
            };

            secondOrderOfFirstUser = new Order
            {
                Id = 2,
                UserId = firstUser.Id,
                OrderDate = new DateTime(2024, 12, 5, 12, 00, 00, DateTimeKind.Utc), //Fixed date
                OrderDetails = "",
                FirstName = "UpdatedFirst",
                LastName = "UpdatedLast",
                PhoneNumber = "1234567890",
                TotalPrice = 17.50m,
                ShippingAddress = "Test Street 123",
                PaymentMethodId = 1,
                OrderStatusId = 1,
                ShoppingCartId = 1,
                Email = "firstuser@firstuser.com"
            };

            firstOrderOfSecondUser = new Order
            {
                Id = 3,
                UserId = secondUser.Id,
                OrderDate = new DateTime(2024, 12, 6, 15, 00, 00, DateTimeKind.Utc), //Fixed date
                OrderDetails = "No",
                FirstName = "Second",
                LastName = "User",
                PhoneNumber = "1234567800",
                TotalPrice = 12.30m,
                ShippingAddress = "Address of Second User",
                PaymentMethodId = 1,
                OrderStatusId = 1,
                ShoppingCartId = 1,
                Email = "seconduser@seconduser.com"
            };

            users = new List<ApplicationUser>() { firstUser, secondUser, thirdUser };
            orders = new List<Order>() { firstOrderOfFirstUser, secondOrderOfFirstUser, firstOrderOfSecondUser };

            //Configuration of in-memory db
            var dbOptions = new DbContextOptionsBuilder<FlowerStoreDbContext>()
               .UseInMemoryDatabase("FlowerStoreTestDb" + Guid.NewGuid().ToString())
               .Options;

            dbContext = new FlowerStoreDbContext(dbOptions);

            //Seed data
            await dbContext.AddRangeAsync(users);
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

            //UserService initialization
            userService = new UserService(repository, userManager);
        }

        //Clean db after each test
        [TearDown]
        public async Task Teardown()
        {
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.DisposeAsync();
        }

        [Test]
        public async Task UpdateUserInfoAsync_WhenUserHasMoreOrders_SetUserInfoFromLastOrder()
        {
            await userService.UpdateUserInfoAsync(firstUser.Id);

            var updatedFirstUserInfo = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == firstUser.Id);
            var updatedSecondUserInfo = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == secondUser.Id);

            //About first user (with two orders)
            Assert.That(updatedFirstUserInfo, Is.Not.Null);
            Assert.That(updatedFirstUserInfo.FirstName, Is.EqualTo("UpdatedFirst"));
            Assert.That(updatedFirstUserInfo.LastName, Is.EqualTo("UpdatedLast"));
            Assert.That(updatedFirstUserInfo.PhoneNumber, Is.EqualTo("1234567890"));

            //About second user (with one order)
            Assert.That(updatedSecondUserInfo, Is.Not.Null);
            Assert.That(updatedSecondUserInfo.FirstName, Is.EqualTo("Second"));
            Assert.That(updatedSecondUserInfo.LastName, Is.EqualTo("User"));
            Assert.That(updatedSecondUserInfo.PhoneNumber, Is.EqualTo("1234567800"));
        }

        [Test]
        public async Task UpdateUserInfoAsync_WhenUserDoesNotExist_DoesNothing()
        {
            await userService.UpdateUserInfoAsync("userId");

            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == "userId");
            Assert.That(user, Is.Null);
        }

        [Test]
        public async Task UpdateUserInfoAsync_WhenUserExistsWithoutOrders_DoesNothing()
        {
            await userService.UpdateUserInfoAsync(thirdUser.Id);

            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Id == thirdUser.Id);

            //About third user (with no orders)
            Assert.That(user, Is.Not.Null);
            Assert.That(user.FirstName, Is.EqualTo("Third"));
            Assert.That(user.LastName, Is.EqualTo("User"));
            Assert.That(user.PhoneNumber, Is.EqualTo("1234567000"));
        }        
    }
}