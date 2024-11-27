using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class SeededMoreProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8a83462-e59b-4fcc-962d-2eb22c3b83e3", "AQAAAAEAACcQAAAAEEabvkNdZkjp8JkJhL1nBJ6axC88W9ia256mb1iA9pjUEndoVa578FEFSmhmqSoSew==", "a7c4520b-d33d-4cd2-9c45-3c9b9d915a2a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7244df7-69e8-4507-9f67-1209a7e9996a", "AQAAAAEAACcQAAAAEGNvPfOI9XeWET/cnoLq6RM6wxNh6vmJZ0jAKDQYfJKiNHCtFU2+wAERP084iEQ5ww==", "2293a3b0-b36b-4f7f-9184-18a65ca84db5" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAdded", "FullDescription", "ImageUrl" },
                values: new object[] { new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7384), "The rose is a classic symbol of love and beauty, known for its exquisite fragrance and delicate petals. This beautiful flower comes in various colors, with the red rose being the most iconic symbol of romance. Our roses are carefully cultivated to ensure freshness and quality. In the tapestry of botanical history, the Red Rose emerges as a symbol of passion, romance, and enduring love. Its origins are steeped in ancient lore, tracing back to the verdant gardens of Persia, where its scarlet petals first unfurled beneath the gaze of starlit skies. Legends speak of goddesses and mortal admirers alike, captivated by the velvety allure and intoxicating fragrance of this timeless bloom. The Red Rose, with its velvety crimson petals, symbolizes the fervent flames of love and desire. Its rich hue evokes the blush of a lover's cheek and the ardor of a heart aflame. From clandestine rendezvous to grand declarations, the Red Rose has enraptured souls throughout the ages, transcending boundaries of time and culture with its timeless allure.", "https://img.freepik.com/premium-photo/red-roses-pot-isolated-white-background_511010-2090.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateAdded", "FullDescription", "ImageUrl" },
                values: new object[] { new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7384), "The elusive Blue Orchid, with its captivating hue, whispers tales of ancient mystique and ethereal beauty. Legend has it that this rare bloom emerged from the depths of forgotten realms, its petals kissed by moonlight and tears of the gods. Its enchanting color, a symphony of cobalt and azure, reflects the secrets of the universe, beckoning admirers into a world of wonder and enchantment. Unlike its vibrant counterparts, the Blue Orchid owes its unique coloration to a delicate balance of genetic mutation and environmental alchemy. Through a serendipitous interplay of genetic expression and environmental factors, this majestic flower dons its celestial cloak, inviting awe and admiration from all who behold its splendor.", "https://i.pinimg.com/736x/3e/14/88/3e148876fc1b8d1b4063a6695a7ebc9a.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateAdded", "FullDescription" },
                values: new object[] { new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7385), "Deep within the lush rainforests of West Africa, the majestic Ficus Lyrata, known colloquially as the Fiddle Leaf Fig, reigns as a verdant monarch of the jungle. Its origins intertwine with the ancient rhythms of the forest, where sunlight dances through emerald canopies and gentle rains nurture the soil. Born from the earth's embrace and nurtured by the whispers of the wind, the Ficus Lyrata embodies the resilience and grace of its tropical homeland. The Fiddle Leaf Fig derives its moniker from the lyrical curvature of its expansive leaves, which resemble the graceful silhouette of a fiddle or violin. Each leaf unfurls with a symphony of green hues, invoking a sense of harmony and tranquility in any space it inhabits. From its ancestral roots to its contemporary allure, the Ficus Lyrata remains a cherished emblem of natural beauty and botanical elegance." });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Availability", "CategoryId", "DateAdded", "FlowersCount", "FullDescription", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 4, true, 4, new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7386), 5, "Tagetes, commonly known as marigold, is a genus of flowering plants in the family Asteraceae. These vibrant flowers are native to North and South America but are widely cultivated around the world for ornamental, medicinal, and culinary purposes. Tagetes flowers are typically yellow, orange, or red, often with ruffled or double-petaled blooms. They range in size from small pom-poms to larger, more dramatic heads. They are usually annuals but can sometimes be perennial, depending on the species. Tagetes grows in a bushy habit and varies in size, from compact dwarf varieties to taller plants over a meter high. ", "https://skgarden.bg/media/18/326.jpg", "Orange Tagetes", 12.00m },
                    { 5, true, 6, new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7386), 10, "Begonias are a diverse genus of flowering plants in the family Begoniaceae, encompassing over 2,000 species. They are prized for their vibrant flowers, striking foliage, and adaptability to various growing conditions. Native to tropical and subtropical regions worldwide, begonias are cultivated extensively as ornamental plants. They produce showy flowers in a range of colors, including red, pink, white, and orange. The blooms are often asymmetrical and can vary significantly in size depending on the variety.", "https://skgarden.bg/media/18/160.jpg", "Pink Begonia", 6.50m },
                    { 6, true, 6, new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7387), 10, "Begonias are a diverse genus of flowering plants in the family Begoniaceae, encompassing over 2,000 species. They are prized for their vibrant flowers, striking foliage, and adaptability to various growing conditions. Native to tropical and subtropical regions worldwide, begonias are cultivated extensively as ornamental plants. They produce showy flowers in a range of colors, including red, pink, white, and orange. The blooms are often asymmetrical and can vary significantly in size depending on the variety.", "https://skgarden.bg/media/18/158.jpg", "Red Begonia", 6.00m },
                    { 7, true, 3, new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7387), 4, "The white anthurium, often called the peace lily anthurium or white flamingo flower, is a striking plant known for its elegant white flowers and glossy green leaves. Belonging to the genus Anthurium within the family Araceae, this tropical plant is prized for its ornamental value and ease of care. The \"flower\" is actually a spathe, a modified leaf, typically white or off-white, surrounding a yellow or pale green spadix. Its minimalist aesthetic makes it a popular choice for modern interiors. These plants grow as evergreen perennials, reaching heights of 12–24 inches (30–60 cm) depending on the species or variety.", "https://www.greenthumb.com/wp-content/uploads/2022/10/c6154cf6-cd75-5a1b-99be-d8e97dc6b45b_455bd0bd-8b8f-430f-a309-baaafe792f1b.jpg", "White Anthurium", 24.00m },
                    { 8, true, 6, new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7388), 8, "The yellow begonia is a radiant and cheerful flowering plant belonging to the genus Begonia in the family Begoniaceae. It is loved for its bright yellow blooms, lush foliage, and versatility in gardening. Native to tropical and subtropical regions, begonias have been cultivated worldwide for their ornamental beauty. The blooms are a vivid yellow, often large and lush, with single or double petals depending on the variety. The flowers create a striking contrast against the green leaves. Yellow begonias can grow as upright or trailing plants, depending on the species. They are compact and bushy, making them perfect for small spaces or containers.", "https://www.provenwinners.com/sites/provenwinners.com/files/imagecache/low-resolution/ifa_upload/begonia_solenia_yellow_mono.jpg", "Yellow Begonia", 8.00m },
                    { 9, true, 4, new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7389), 12, "The pink geranium, belonging to the genus Pelargonium in the family Geraniaceae, is a beloved flowering plant known for its vibrant pink blooms and aromatic foliage. Native to South Africa, geraniums are widely cultivated as ornamentals in gardens, pots, and hanging baskets. Pink geraniums produce clusters of five-petaled flowers in various shades of pink, from pastel to bright hues. The flowers often have subtle patterns or darker streaks, adding depth and visual interest. These plants are profuse bloomers, flowering from spring to late autumn in the right conditions.", "https://flower.bigbadmole.com/wp-content/uploads/2019/12/1-zaglavnaja-3.jpg", "Pink Geranium", 5.80m },
                    { 10, true, 6, new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7389), 6, "The purple ageratum, commonly known as floss flower, is a charming and hardy annual plant in the family Asteraceae. Its botanical name is typically Ageratum houstonianum, and it is prized for its fluffy, soft-textured flowers that resemble tufts of thread or floss. Native to Central America and Mexico, purple ageratum is widely grown for its vibrant purple blooms and easy maintenance. Purple ageratum grows in compact mounds, typically reaching heights of 6–12 inches (15–30 cm), depending on the variety. It is a prolific bloomer, flowering continuously from late spring to the first frost in fall.", "https://skgarden.bg/media/18/369.jpg", "Purple Ageratum", 9.30m },
                    { 11, true, 4, new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7390), 14, "The red geranium, a popular variant of the Pelargonium genus in the Geraniaceae family, is admired for its vibrant, long-lasting red blooms and attractive foliage. Native to South Africa, red geraniums are widely cultivated around the world for their ornamental appeal, easy maintenance, and versatility. The bold red flowers grow in clusters atop sturdy stems. The blooms range in shades from bright scarlet to deep crimson and are excellent for adding dramatic color to gardens. Red geraniums can grow upright, spreading, or trailing, making them versatile for beds, borders, containers, and hanging baskets. Plants typically reach heights of 12–24 inches (30–60 cm).", "https://dfwmnhok7ak0p.cloudfront.net/91919/V21964/C/1691650160000/1280.jpg", "Red Geranium", 5.80m },
                    { 12, true, 6, new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7390), 15, "Pink petunias are flowering plants in the genus Petunia, belonging to the family Solanaceae. Known for their trumpet-shaped blooms and vibrant hues, pink petunias are versatile and widely loved for their ability to thrive in various settings. These annuals or tender perennials (in warmer climates) are native to South America. Pink petunias produce abundant, trumpet-shaped flowers in soft pastel, bright, or even patterned pink shades. Some varieties are fragrant, particularly in the evening. Petunias can be upright or trailing, depending on the variety. They typically grow 6–18 inches (15–45 cm) tall and spread up to 24 inches (60 cm).", "https://skgarden.bg/media/18/420.jpg", "Pink Petunias", 5.00m },
                    { 13, true, 6, new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7391), 4, "Pelargonium within the family Geraniaceae. It is a vibrant and showy ornamental plant, prized for its lush purple flowers and fragrant, lobed foliage. Native to South Africa, pelargoniums have become globally popular in gardens and pots for their vivid colors and adaptability. The blooms of purple pelargonium are typically rich in color, ranging from soft lavender to deep purple. The flowers are often multi-toned, with darker markings or streaks on the petals, adding an artistic flair. Depending on the variety, purple pelargoniums can grow upright or exhibit a trailing habit, making them suitable for containers, hanging baskets, and garden beds. They typically grow 12–24 inches (30–60 cm) tall.", "https://skgarden.bg/media/18/436.jpg", "Purple Pelargonium", 6.50m },
                    { 14, true, 4, new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7391), 9, "The white geranium is a striking variant of the Pelargonium genus, a flowering plant in the Geraniaceae family. Known for its pristine white blooms, it’s a popular ornamental plant used in gardens, hanging baskets, and containers. Native to South Africa, geraniums (including white varieties) have been cultivated for their beauty, fragrance, and ease of care. The white geranium produces elegant, pure white flowers, often with subtle markings or veins in the center of each petal. These flowers are typically five-petaled and appear in clusters atop sturdy stems. White geraniums can grow upright or trailing, making them versatile for garden beds, containers, hanging baskets, and window boxes. They usually grow between 12 to 18 inches (30 to 45 cm) in height, depending on the variety.", "https://skgarden.bg/media/18/206.jpg", "White Geranium", 6.70m },
                    { 15, true, 1, new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7392), 3, "The pink hibiscus is a tropical flowering plant belonging to the genus Hibiscus, part of the Malvaceae family. Known for its large, showy blooms and vibrant pink color, this plant is often associated with tropical and subtropical regions around the world. Pink hibiscus is widely cultivated for its striking appearance and symbolic meanings of beauty, femininity, and exoticism. The flowers of pink hibiscus are large, with five petals that can range from soft pastels to vibrant pinks. Some varieties feature darker veins or a contrasting center, making them visually captivating. These flowers can be up to 6 inches (15 cm) in diameter and are often funnel-shaped. Pink hibiscus plants can grow as shrubs, bushes, or small trees, reaching heights of 3–10 feet (1–3 meters), depending on the species and growing conditions. They can have a bushy, rounded shape with a thick, woody trunk.", "https://photo.floraccess.com/5g5qcbeu7okodcmedk0m43tl9shnbbgm245af2bd_Preview480.jpg", "Pink Hibiscus", 32.00m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3aa54d9-15de-46de-8816-eb52f27ca7f0", "AQAAAAEAACcQAAAAEOvLzA/czH79+0ZxyvA9GLFWsn8MxFX2lfRGTA2/gZ3e5Wcobrg6FshfvAMlwAWP8g==", "3a0baab6-46cb-480d-afd1-d0c4444ef513" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ac6b70d-0514-48af-bfcb-4250b1595c9f", "AQAAAAEAACcQAAAAEEvQ3okz9Xssjgoqfsa59BVROZ7Hz5J+zZdaUCJg4/ynmeXOB5qWG7i/S26xqws8Uw==", "396cc6fc-0f17-42bc-9087-0e437bbe2ede" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAdded", "FullDescription", "ImageUrl" },
                values: new object[] { new DateTime(2024, 11, 18, 15, 19, 23, 645, DateTimeKind.Utc).AddTicks(1774), "The rose is a classic symbol of love and beauty, known for its exquisite fragrance and delicate petals. This beautiful flower comes in various colors, with the red rose being the most iconic symbol of romance. Our roses are carefully cultivated to ensure freshness and quality.Origin Story:\r\nIn the tapestry of botanical history, the Red Rose emerges as a symbol of passion, romance, and enduring love. Its origins are steeped in ancient lore, tracing back to the verdant gardens of Persia, where its scarlet petals first unfurled beneath the gaze of starlit skies. Legends speak of goddesses and mortal admirers alike, captivated by the velvety allure and intoxicating fragrance of this timeless bloom.\r\n\r\nWhy Red?\r\nThe Red Rose, with its velvety crimson petals, symbolizes the fervent flames of love and desire. Its rich hue evokes the blush of a lover's cheek and the ardor of a heart aflame. From clandestine rendezvous to grand declarations, the Red Rose has enraptured souls throughout the ages, transcending boundaries of time and culture with its timeless allure.", "https://plantparadise.in/cdn/shop/products/ROSE1_4a1f52f8-ebe7-4dab-93ed-f7af98cb11e7.jpg?v=1691200467" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateAdded", "FullDescription", "ImageUrl" },
                values: new object[] { new DateTime(2024, 11, 18, 15, 19, 23, 645, DateTimeKind.Utc).AddTicks(1775), "Origin Story:\r\nThe elusive Blue Orchid, with its captivating hue, whispers tales of ancient mystique and ethereal beauty. Legend has it that this rare bloom emerged from the depths of forgotten realms, its petals kissed by moonlight and tears of the gods. Its enchanting color, a symphony of cobalt and azure, reflects the secrets of the universe, beckoning admirers into a world of wonder and enchantment.\r\n\r\nWhy Blue?\r\nUnlike its vibrant counterparts, the Blue Orchid owes its unique coloration to a delicate balance of genetic mutation and environmental alchemy. Through a serendipitous interplay of genetic expression and environmental factors, this majestic flower dons its celestial cloak, inviting awe and admiration from all who behold its splendor.", "https://fyf.tac-cdn.net/images/products/large/P-149.jpg?auto=webp&quality=60&width=690" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateAdded", "FullDescription" },
                values: new object[] { new DateTime(2024, 11, 18, 15, 19, 23, 645, DateTimeKind.Utc).AddTicks(1775), "Origin Story:\r\nDeep within the lush rainforests of West Africa, the majestic Ficus Lyrata, known colloquially as the Fiddle Leaf Fig, reigns as a verdant monarch of the jungle. Its origins intertwine with the ancient rhythms of the forest, where sunlight dances through emerald canopies and gentle rains nurture the soil. Born from the earth's embrace and nurtured by the whispers of the wind, the Ficus Lyrata embodies the resilience and grace of its tropical homeland.\r\n\r\nWhy Fiddle Leaf Fig?\r\nThe Fiddle Leaf Fig derives its moniker from the lyrical curvature of its expansive leaves, which resemble the graceful silhouette of a fiddle or violin. Each leaf unfurls with a symphony of green hues, invoking a sense of harmony and tranquility in any space it inhabits. From its ancestral roots to its contemporary allure, the Ficus Lyrata remains a cherished emblem of natural beauty and botanical elegance." });
        }
    }
}
