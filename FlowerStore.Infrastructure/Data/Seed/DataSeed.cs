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
        public Product OrangeTagetes { get; set; } = null!;
        public Product PinkBegonia { get; set; } = null!;
        public Product RedBegonia { get; set; } = null!;
        public Product WhiteAnthurium { get; set; } = null!;
        public Product YellowBegonia { get; set; } = null!;
        public Product PinkGeranium { get; set; } = null!;
        public Product PurpleAgeratum { get; set; } = null!;
        public Product RedGeranium { get; set;} = null!;
        public Product PinkPetunias { get; set; } = null!;
        public Product PurplePelargonium { get; set; } = null!;
        public Product WhiteGeranium { get; set; } = null!;
        public Product PinkHibiscus { get; set; } = null!;

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
                ImageUrl = "https://img.freepik.com/premium-photo/red-roses-pot-isolated-white-background_511010-2090.jpg",
                Availability = true,
                FullDescription = "The rose is a classic symbol of love and beauty, known for its exquisite fragrance and delicate petals. This beautiful flower comes in various colors, with the red rose being the most iconic symbol of romance. Our roses are carefully cultivated to ensure freshness and quality. In the tapestry of botanical history, the Red Rose emerges as a symbol of passion, romance, and enduring love. Its origins are steeped in ancient lore, tracing back to the verdant gardens of Persia, where its scarlet petals first unfurled beneath the gaze of starlit skies. Legends speak of goddesses and mortal admirers alike, captivated by the velvety allure and intoxicating fragrance of this timeless bloom. The Red Rose, with its velvety crimson petals, symbolizes the fervent flames of love and desire. Its rich hue evokes the blush of a lover's cheek and the ardor of a heart aflame. From clandestine rendezvous to grand declarations, the Red Rose has enraptured souls throughout the ages, transcending boundaries of time and culture with its timeless allure.",
                FlowersCount = 5
            };

            BlueOrchid = new Product
            {
                Id = 2,
                Name = "Blue Orchid",
                CategoryId = 7,
                Price = 17.50m,
                DateAdded = DateTime.UtcNow,
                ImageUrl = "https://i.pinimg.com/736x/3e/14/88/3e148876fc1b8d1b4063a6695a7ebc9a.jpg",
                Availability = true,
                FullDescription = "The elusive Blue Orchid, with its captivating hue, whispers tales of ancient mystique and ethereal beauty. Legend has it that this rare bloom emerged from the depths of forgotten realms, its petals kissed by moonlight and tears of the gods. Its enchanting color, a symphony of cobalt and azure, reflects the secrets of the universe, beckoning admirers into a world of wonder and enchantment. Unlike its vibrant counterparts, the Blue Orchid owes its unique coloration to a delicate balance of genetic mutation and environmental alchemy. Through a serendipitous interplay of genetic expression and environmental factors, this majestic flower dons its celestial cloak, inviting awe and admiration from all who behold its splendor.",
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
                FullDescription = "Deep within the lush rainforests of West Africa, the majestic Ficus Lyrata, known colloquially as the Fiddle Leaf Fig, reigns as a verdant monarch of the jungle. Its origins intertwine with the ancient rhythms of the forest, where sunlight dances through emerald canopies and gentle rains nurture the soil. Born from the earth's embrace and nurtured by the whispers of the wind, the Ficus Lyrata embodies the resilience and grace of its tropical homeland. The Fiddle Leaf Fig derives its moniker from the lyrical curvature of its expansive leaves, which resemble the graceful silhouette of a fiddle or violin. Each leaf unfurls with a symphony of green hues, invoking a sense of harmony and tranquility in any space it inhabits. From its ancestral roots to its contemporary allure, the Ficus Lyrata remains a cherished emblem of natural beauty and botanical elegance.",
                FlowersCount = 4
            };

            OrangeTagetes = new Product
            {
                Id = 4,
                Name = "Orange Tagetes",
                CategoryId = 4,
                Price = 12.00m,
                DateAdded = DateTime.UtcNow,
                ImageUrl = "https://skgarden.bg/media/18/326.jpg",
                Availability = true,
                FullDescription = "Tagetes, commonly known as marigold, is a genus of flowering plants in the family Asteraceae. These vibrant flowers are native to North and South America but are widely cultivated around the world for ornamental, medicinal, and culinary purposes. Tagetes flowers are typically yellow, orange, or red, often with ruffled or double-petaled blooms. They range in size from small pom-poms to larger, more dramatic heads. They are usually annuals but can sometimes be perennial, depending on the species. Tagetes grows in a bushy habit and varies in size, from compact dwarf varieties to taller plants over a meter high. ",
                FlowersCount = 5
            };

            PinkBegonia = new Product
            {
                Id = 5,
                Name = "Pink Begonia",
                CategoryId = 6,
                Price = 6.50m,
                DateAdded = DateTime.UtcNow,
                ImageUrl = "https://skgarden.bg/media/18/160.jpg",
                Availability = true,
                FullDescription = "Begonias are a diverse genus of flowering plants in the family Begoniaceae, encompassing over 2,000 species. They are prized for their vibrant flowers, striking foliage, and adaptability to various growing conditions. Native to tropical and subtropical regions worldwide, begonias are cultivated extensively as ornamental plants. They produce showy flowers in a range of colors, including red, pink, white, and orange. The blooms are often asymmetrical and can vary significantly in size depending on the variety.",
                FlowersCount = 10
            };

            RedBegonia = new Product
            {
                Id = 6,
                Name = "Red Begonia",
                CategoryId = 6,
                Price = 6.00m,
                DateAdded = DateTime.UtcNow,
                ImageUrl = "https://skgarden.bg/media/18/158.jpg",
                Availability = true,
                FullDescription = "Begonias are a diverse genus of flowering plants in the family Begoniaceae, encompassing over 2,000 species. They are prized for their vibrant flowers, striking foliage, and adaptability to various growing conditions. Native to tropical and subtropical regions worldwide, begonias are cultivated extensively as ornamental plants. They produce showy flowers in a range of colors, including red, pink, white, and orange. The blooms are often asymmetrical and can vary significantly in size depending on the variety.",
                FlowersCount = 10
            };

            WhiteAnthurium = new Product
            {
                Id = 7,
                Name = "White Anthurium",
                CategoryId = 3,
                Price = 24.00m,
                DateAdded = DateTime.UtcNow,
                ImageUrl = "https://www.greenthumb.com/wp-content/uploads/2022/10/c6154cf6-cd75-5a1b-99be-d8e97dc6b45b_455bd0bd-8b8f-430f-a309-baaafe792f1b.jpg",
                Availability = true,
                FullDescription = "The white anthurium, often called the peace lily anthurium or white flamingo flower, is a striking plant known for its elegant white flowers and glossy green leaves. Belonging to the genus Anthurium within the family Araceae, this tropical plant is prized for its ornamental value and ease of care. The \"flower\" is actually a spathe, a modified leaf, typically white or off-white, surrounding a yellow or pale green spadix. Its minimalist aesthetic makes it a popular choice for modern interiors. These plants grow as evergreen perennials, reaching heights of 12–24 inches (30–60 cm) depending on the species or variety.",
                FlowersCount = 4
            };

            YellowBegonia = new Product
            {
                Id = 8,
                Name = "Yellow Begonia",
                CategoryId = 6,
                Price = 8.00m,
                DateAdded = DateTime.UtcNow,
                ImageUrl = "https://www.provenwinners.com/sites/provenwinners.com/files/imagecache/low-resolution/ifa_upload/begonia_solenia_yellow_mono.jpg",
                Availability = true,
                FullDescription = "The yellow begonia is a radiant and cheerful flowering plant belonging to the genus Begonia in the family Begoniaceae. It is loved for its bright yellow blooms, lush foliage, and versatility in gardening. Native to tropical and subtropical regions, begonias have been cultivated worldwide for their ornamental beauty. The blooms are a vivid yellow, often large and lush, with single or double petals depending on the variety. The flowers create a striking contrast against the green leaves. Yellow begonias can grow as upright or trailing plants, depending on the species. They are compact and bushy, making them perfect for small spaces or containers.",
                FlowersCount = 8
            };

            PinkGeranium = new Product
            {
                Id = 9,
                Name = "Pink Geranium",
                CategoryId = 4,
                Price = 5.80m,
                DateAdded = DateTime.UtcNow,
                ImageUrl = "https://flower.bigbadmole.com/wp-content/uploads/2019/12/1-zaglavnaja-3.jpg",
                Availability = true,
                FullDescription = "The pink geranium, belonging to the genus Pelargonium in the family Geraniaceae, is a beloved flowering plant known for its vibrant pink blooms and aromatic foliage. Native to South Africa, geraniums are widely cultivated as ornamentals in gardens, pots, and hanging baskets. Pink geraniums produce clusters of five-petaled flowers in various shades of pink, from pastel to bright hues. The flowers often have subtle patterns or darker streaks, adding depth and visual interest. These plants are profuse bloomers, flowering from spring to late autumn in the right conditions.",
                FlowersCount = 12
            };

            PurpleAgeratum = new Product
            {
                Id = 10,
                Name = "Purple Ageratum",
                CategoryId = 6,
                Price = 9.30m,
                DateAdded = DateTime.UtcNow,
                ImageUrl = "https://skgarden.bg/media/18/369.jpg",
                Availability = true,
                FullDescription = "The purple ageratum, commonly known as floss flower, is a charming and hardy annual plant in the family Asteraceae. Its botanical name is typically Ageratum houstonianum, and it is prized for its fluffy, soft-textured flowers that resemble tufts of thread or floss. Native to Central America and Mexico, purple ageratum is widely grown for its vibrant purple blooms and easy maintenance. Purple ageratum grows in compact mounds, typically reaching heights of 6–12 inches (15–30 cm), depending on the variety. It is a prolific bloomer, flowering continuously from late spring to the first frost in fall.",
                FlowersCount = 6
            };

            RedGeranium = new Product
            {
                Id = 11,
                Name = "Red Geranium",
                CategoryId = 4,
                Price = 5.80m,
                DateAdded = DateTime.UtcNow,
                ImageUrl = "https://dfwmnhok7ak0p.cloudfront.net/91919/V21964/C/1691650160000/1280.jpg",
                Availability = true,
                FullDescription = "The red geranium, a popular variant of the Pelargonium genus in the Geraniaceae family, is admired for its vibrant, long-lasting red blooms and attractive foliage. Native to South Africa, red geraniums are widely cultivated around the world for their ornamental appeal, easy maintenance, and versatility. The bold red flowers grow in clusters atop sturdy stems. The blooms range in shades from bright scarlet to deep crimson and are excellent for adding dramatic color to gardens. Red geraniums can grow upright, spreading, or trailing, making them versatile for beds, borders, containers, and hanging baskets. Plants typically reach heights of 12–24 inches (30–60 cm).",
                FlowersCount = 14
            };

            PinkPetunias = new Product
            {
                Id = 12,
                Name = "Pink Petunias",
                CategoryId = 6,
                Price = 5.00m,
                DateAdded = DateTime.UtcNow,
                ImageUrl = "https://skgarden.bg/media/18/420.jpg",
                Availability = true,
                FullDescription = "Pink petunias are flowering plants in the genus Petunia, belonging to the family Solanaceae. Known for their trumpet-shaped blooms and vibrant hues, pink petunias are versatile and widely loved for their ability to thrive in various settings. These annuals or tender perennials (in warmer climates) are native to South America. Pink petunias produce abundant, trumpet-shaped flowers in soft pastel, bright, or even patterned pink shades. Some varieties are fragrant, particularly in the evening. Petunias can be upright or trailing, depending on the variety. They typically grow 6–18 inches (15–45 cm) tall and spread up to 24 inches (60 cm).",
                FlowersCount = 15
            };

            PurplePelargonium = new Product
            {
                Id = 13,
                Name = "Purple Pelargonium",
                CategoryId = 6,
                Price = 6.50m,
                DateAdded = DateTime.UtcNow,
                ImageUrl = "https://skgarden.bg/media/18/436.jpg",
                Availability = true,
                FullDescription = "Pelargonium within the family Geraniaceae. It is a vibrant and showy ornamental plant, prized for its lush purple flowers and fragrant, lobed foliage. Native to South Africa, pelargoniums have become globally popular in gardens and pots for their vivid colors and adaptability. The blooms of purple pelargonium are typically rich in color, ranging from soft lavender to deep purple. The flowers are often multi-toned, with darker markings or streaks on the petals, adding an artistic flair. Depending on the variety, purple pelargoniums can grow upright or exhibit a trailing habit, making them suitable for containers, hanging baskets, and garden beds. They typically grow 12–24 inches (30–60 cm) tall.",
                FlowersCount = 4
            };

            WhiteGeranium = new Product
            {
                Id = 14,
                Name = "White Geranium",
                CategoryId = 4,
                Price = 6.70m,
                DateAdded = DateTime.UtcNow,
                ImageUrl = "https://skgarden.bg/media/18/206.jpg",
                Availability = true,
                FullDescription = "The white geranium is a striking variant of the Pelargonium genus, a flowering plant in the Geraniaceae family. Known for its pristine white blooms, it’s a popular ornamental plant used in gardens, hanging baskets, and containers. Native to South Africa, geraniums (including white varieties) have been cultivated for their beauty, fragrance, and ease of care. The white geranium produces elegant, pure white flowers, often with subtle markings or veins in the center of each petal. These flowers are typically five-petaled and appear in clusters atop sturdy stems. White geraniums can grow upright or trailing, making them versatile for garden beds, containers, hanging baskets, and window boxes. They usually grow between 12 to 18 inches (30 to 45 cm) in height, depending on the variety.",
                FlowersCount = 9
            };

            PinkHibiscus = new Product
            {
                Id = 15,
                Name = "Pink Hibiscus",
                CategoryId = 1,
                Price = 32.00m,
                DateAdded = DateTime.UtcNow,
                ImageUrl = "https://photo.floraccess.com/5g5qcbeu7okodcmedk0m43tl9shnbbgm245af2bd_Preview480.jpg",
                Availability = true,
                FullDescription = "The pink hibiscus is a tropical flowering plant belonging to the genus Hibiscus, part of the Malvaceae family. Known for its large, showy blooms and vibrant pink color, this plant is often associated with tropical and subtropical regions around the world. Pink hibiscus is widely cultivated for its striking appearance and symbolic meanings of beauty, femininity, and exoticism. The flowers of pink hibiscus are large, with five petals that can range from soft pastels to vibrant pinks. Some varieties feature darker veins or a contrasting center, making them visually captivating. These flowers can be up to 6 inches (15 cm) in diameter and are often funnel-shaped. Pink hibiscus plants can grow as shrubs, bushes, or small trees, reaching heights of 3–10 feet (1–3 meters), depending on the species and growing conditions. They can have a bushy, rounded shape with a thick, woody trunk.",
                FlowersCount = 3
            };
        }
    }
}
