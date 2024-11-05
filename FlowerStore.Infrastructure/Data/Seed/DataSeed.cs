using FlowerStore.Infrastructure.Data.Models;
using FlowerStore.Infrastructure.Data.Models.Orders.Order;
using FlowerStore.Infrastructure.Data.Models.Payment;
using FlowerStore.Infrastructure.Data.Models.Roles;
using Microsoft.AspNetCore.Identity;
using static FlowerStore.Infrastructure.Constants.CustomClaims;

namespace FlowerStore.Infrastructure.Data.Seed
{
    /// <summary>
    /// Seeding initial data for the app.
    /// </summary>

    internal class DataSeed
    {
        //Users
        public ApplicationUser AdminUser { get; set; } = null!;      
        public ApplicationUser GuestUser { get; set; } = null!;

        //Claims
        public IdentityUserClaim<string> AdminUserClaim { get; set; } = null!;
        public IdentityUserClaim<string> GuestUserClaim { get; set; } = null!;

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
        public Product BlueOrchid { get; set; } = null!;
        public Product FicusLyrata { get; set; } = null!;

        public DataSeed()
        {
            SeedUsers();
            SeedCategories();
            SeedPaymentMethods();
            SeedOrderStatus();
            SeedProducts();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            AdminUser = new ApplicationUser()
            {
                Id = "adminId",
                UserName = "admin@mail.com",
                NormalizedUserName = "ADMIN@MAIL.COM",
                Email = "admin@mail.com",
                NormalizedEmail = "ADMIN@MAIL.COM",
                FirstName = "Admin",
                LastName = "Admin",
                Phone = "1234567890"
            };

            AdminUserClaim = new IdentityUserClaim<string>()
            {
                Id = 1,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Admin Admin",
                UserId = "adminId"
            };

            AdminUser.PasswordHash = hasher.HashPassword(AdminUser, "admin123");

            GuestUser = new ApplicationUser()
            {
                Id = "testId",
                UserName = "test@test.com",
                NormalizedUserName = "TEST@TEST.COM",
                Email = "test@test.com",
                NormalizedEmail = "TEST@TEST.COM",
                FirstName = "Test",
                LastName = "Test",
                Phone = "1234567800"
            };

            GuestUserClaim = new IdentityUserClaim<string>()
            {
                Id = 2,
                ClaimType = UserFullNameClaim,
                ClaimValue = "Test Test",
                UserId = "testId"
            };

            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "test");
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
                FullDescription = "The rose is a classic symbol of love and beauty, known for its exquisite fragrance and delicate petals. This beautiful flower comes in various colors, with the red rose being the most iconic symbol of romance. Our roses are carefully cultivated to ensure freshness and quality." +
                "Origin Story:\r\nIn the tapestry of botanical history, the Red Rose emerges as a symbol of passion, romance, and enduring love. Its origins are steeped in ancient lore, tracing back to the verdant gardens of Persia, where its scarlet petals first unfurled beneath the gaze of starlit skies. Legends speak of goddesses and mortal admirers alike, captivated by the velvety allure and intoxicating fragrance of this timeless bloom.\r\n\r\nWhy Red?\r\nThe Red Rose, with its velvety crimson petals, symbolizes the fervent flames of love and desire. Its rich hue evokes the blush of a lover's cheek and the ardor of a heart aflame. From clandestine rendezvous to grand declarations, the Red Rose has enraptured souls throughout the ages, transcending boundaries of time and culture with its timeless allure.",
                FlowersCount = 5
            };

            BlueOrchid = new Product
            {
                Id = 2,
                Name = "Blue Orchid",
                CategoryId = 7,
                Price = 17.50m,
                DateAdded = DateTime.UtcNow,
                ImageUrl = "https://fyf.tac-cdn.net/images/products/large/P-149.jpg?auto=webp&quality=60&width=690",
                Availability = true,
                FullDescription = "Origin Story:\r\nThe elusive Blue Orchid, with its captivating hue, whispers tales of ancient mystique and ethereal beauty. Legend has it that this rare bloom emerged from the depths of forgotten realms, its petals kissed by moonlight and tears of the gods. Its enchanting color, a symphony of cobalt and azure, reflects the secrets of the universe, beckoning admirers into a world of wonder and enchantment.\r\n\r\nWhy Blue?\r\nUnlike its vibrant counterparts, the Blue Orchid owes its unique coloration to a delicate balance of genetic mutation and environmental alchemy. Through a serendipitous interplay of genetic expression and environmental factors, this majestic flower dons its celestial cloak, inviting awe and admiration from all who behold its splendor.",
                FlowersCount = 7
            };

            FicusLyrata = new Product
            {
                Id = 3,
                Name = "Ficus Lyrata",
                CategoryId = 7,
                Price = 22.30m,
                DateAdded = DateTime.UtcNow,
                ImageUrl = "https://cdn.webshopapp.com/shops/30495/files/448237057/ficus-lyrata-xl-fiddle-leaf-fig-pot-21cm-height-80.jpg",
                Availability = true,
                FullDescription = "Origin Story:\r\nDeep within the lush rainforests of West Africa, the majestic Ficus Lyrata, known colloquially as the Fiddle Leaf Fig, reigns as a verdant monarch of the jungle. Its origins intertwine with the ancient rhythms of the forest, where sunlight dances through emerald canopies and gentle rains nurture the soil. Born from the earth's embrace and nurtured by the whispers of the wind, the Ficus Lyrata embodies the resilience and grace of its tropical homeland.\r\n\r\nWhy Fiddle Leaf Fig?\r\nThe Fiddle Leaf Fig derives its moniker from the lyrical curvature of its expansive leaves, which resemble the graceful silhouette of a fiddle or violin. Each leaf unfurls with a symphony of green hues, invoking a sense of harmony and tranquility in any space it inhabits. From its ancestral roots to its contemporary allure, the Ficus Lyrata remains a cherished emblem of natural beauty and botanical elegance.",
                FlowersCount = 4
            };
        }
    }
}
