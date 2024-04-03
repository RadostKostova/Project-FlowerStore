using BookingSystem.Infrastructure.Data.Models.Roles;
using FlowerStore.Infrastructure.Data.Models;
using FlowerStore.Infrastructure.Data.Models.Orders.Order;
using FlowerStore.Infrastructure.Data.Models.Payment;
using Microsoft.AspNetCore.Identity;

namespace FlowerStore.Infrastructure.Data.Seed
{
    /// <summary>
    /// Seeding initial data for the app.
    /// </summary>

    internal class DataSeed
    {
        //Users
        public IdentityUser AdministratorUser { get; set; } = null!;
        public IdentityUser GuestUser { get; set; } = null!;
        public Administrator Administrator { get; set; } = null!;

        //Categories
        public Category Tropical { get; set; } = null!;
        public Category Desert { get; set; } = null!;
        public Category Indoor { get; set; } = null!;
        public Category Outdoor { get; set; } = null!;
        public Category Wildflowers { get; set; } = null!;
        public Category Garden { get; set; } = null!;
        public Category Exotic { get; set; } = null!;
        public Category Native { get; set; } = null!;
        public Category Seasonal { get; set; } = null!;
        public Category Other { get; set; } = null!;

        //Payment methods
        public PaymentMethod Cash { get; set; } = null!;
        public PaymentMethod Card { get; set; } = null!;

        //Order status
        public OrderStatus Pending { get; set; } = null!;
        public OrderStatus Shipped { get; set; } = null!;
        public OrderStatus Delivered { get; set; } = null!;

        //Products
        public Product RedRoses { get; set; } = null!;

        public DataSeed()
        {
            SeedUsers();
            SeedAdministrator();
            SeedCategories();
            SeedPaymentMethods();
            SeedOrderStatus();
            SeedProducts();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            GuestUser = new IdentityUser()
            {
                Id = "testId",
                UserName = "test@test.com",
                NormalizedUserName = "TEST@TEST.COM",
                Email = "test@test.com",
                NormalizedEmail = "TEST@TEST.COM"
            };

            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "test");

            AdministratorUser = new IdentityUser()
            {
                Id = "adminId",
                UserName = "admin@mail.com",
                NormalizedUserName = "ADMIN@MAIL.COM",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM"
            };

            AdministratorUser.PasswordHash = hasher.HashPassword(AdministratorUser, "admin123");
        }

        private void SeedAdministrator()
        {
            Administrator = new Administrator()
            {
                Id = 1,
                UserId = AdministratorUser.Id
            };
        }

        private void SeedCategories()
        {
            Tropical = new Category
            {
                Id = 1,
                Name = "Tropical",
            };

            Desert = new Category
            {
                Id = 2,
                Name = "Desert"
            };

            Indoor = new Category
            {
                Id = 3,
                Name = "Indoor"
            };

            Outdoor = new Category
            {
                Id = 4,
                Name = "Outdoor"
            };

            Wildflowers = new Category
            {
                Id = 5,
                Name = "Wildflowers"
            };

            Garden = new Category
            {
                Id = 6,
                Name = "Garden"
            };

            Exotic = new Category
            {
                Id = 7,
                Name = "Exotic"
            };

            Native = new Category
            {
                Id = 8,
                Name = "Native"
            };

            Seasonal = new Category
            {
                Id = 9,
                Name = "Seasonal"
            };

            Other = new Category
            {
                Id = 10,
                Name = "Other"
            };
        }

        private void SeedPaymentMethods()
        {
            Cash = new PaymentMethod
            {
                Id = 1,
                Name = "Cash"
            };

            Card = new PaymentMethod
            {
                Id = 2,
                Name = "Card"
            };
        }

        private void SeedOrderStatus()
        {
            Pending = new OrderStatus
            {
                Id = 1,
                OrderStatusName = "Pending"
            };

            Shipped = new OrderStatus
            {
                Id = 2,
                OrderStatusName = "Shipped"
            };

            Delivered = new OrderStatus
            {
                Id = 3,
                OrderStatusName = "Delivered"
            };
        }

        private void SeedProducts()
        {
            RedRoses = new Product
            {
                Id = 1,
                Name = "Rose",
                CategoryId = 6,
                Price = 4.00m,
                DateAdded = DateTime.UtcNow,
                ImageUrl = "https://plantparadise.in/cdn/shop/products/ROSE1_4a1f52f8-ebe7-4dab-93ed-f7af98cb11e7.jpg?v=1691200467",
                Availability = true,
                FullDescription = "The rose is a classic symbol of love and beauty, known for its exquisite fragrance and delicate petals. This beautiful flower comes in various colors, with the red rose being the most iconic symbol of romance. Our roses are carefully cultivated to ensure freshness and quality.",
                FlowersCount = 5
            };
        }
    }
}
