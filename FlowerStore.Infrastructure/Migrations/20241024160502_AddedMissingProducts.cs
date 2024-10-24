using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class AddedMissingProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "ShoppingCarts",
                type: "int",
                nullable: true,
                comment: "Order identifier");

            migrationBuilder.AddColumn<int>(
                name: "OrderHistoryId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Shipping address");

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCartId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Shopping Cart identifier");

            migrationBuilder.CreateTable(
                name: "OrderHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Order history identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHistories_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderHistories_OrderStatuses_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ce117b4-ccd1-4309-8a66-9f96df2dc1fe", "AQAAAAEAACcQAAAAEEP2sQU2//dX62a6usQ0h0Fv9n/z9xVOqHWhcrFQM4sH9e9h38nnJwyr8WF9JuaFhw==", "a5d2ddf1-de23-4003-b0e9-f6f116d0ed9a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6b8e9b5b-d1ef-4b67-8ae5-2ae70066855b", "AQAAAAEAACcQAAAAEN+f6LBWB2xg79S2uSYOLq3k05SNyDkSsVzMWV/vDCgz98g0tdthYPA0bW0moFgCyQ==", "46b443f9-72b9-4966-8b2c-a15affd68e3b" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAdded", "FullDescription" },
                values: new object[] { new DateTime(2024, 10, 24, 16, 5, 2, 146, DateTimeKind.Utc).AddTicks(7603), "The rose is a classic symbol of love and beauty, known for its exquisite fragrance and delicate petals. This beautiful flower comes in various colors, with the red rose being the most iconic symbol of romance. Our roses are carefully cultivated to ensure freshness and quality.Origin Story:\r\nIn the tapestry of botanical history, the Red Rose emerges as a symbol of passion, romance, and enduring love. Its origins are steeped in ancient lore, tracing back to the verdant gardens of Persia, where its scarlet petals first unfurled beneath the gaze of starlit skies. Legends speak of goddesses and mortal admirers alike, captivated by the velvety allure and intoxicating fragrance of this timeless bloom.\r\n\r\nWhy Red?\r\nThe Red Rose, with its velvety crimson petals, symbolizes the fervent flames of love and desire. Its rich hue evokes the blush of a lover's cheek and the ardor of a heart aflame. From clandestine rendezvous to grand declarations, the Red Rose has enraptured souls throughout the ages, transcending boundaries of time and culture with its timeless allure." });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Availability", "CategoryId", "DateAdded", "FlowersCount", "FullDescription", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 2, true, 7, new DateTime(2024, 10, 24, 16, 5, 2, 146, DateTimeKind.Utc).AddTicks(7604), 7, "Origin Story:\r\nThe elusive Blue Orchid, with its captivating hue, whispers tales of ancient mystique and ethereal beauty. Legend has it that this rare bloom emerged from the depths of forgotten realms, its petals kissed by moonlight and tears of the gods. Its enchanting color, a symphony of cobalt and azure, reflects the secrets of the universe, beckoning admirers into a world of wonder and enchantment.\r\n\r\nWhy Blue?\r\nUnlike its vibrant counterparts, the Blue Orchid owes its unique coloration to a delicate balance of genetic mutation and environmental alchemy. Through a serendipitous interplay of genetic expression and environmental factors, this majestic flower dons its celestial cloak, inviting awe and admiration from all who behold its splendor.", "https://fyf.tac-cdn.net/images/products/large/P-149.jpg?auto=webp&quality=60&width=690", "Blue Orchid", 17.50m },
                    { 3, true, 7, new DateTime(2024, 10, 24, 16, 5, 2, 146, DateTimeKind.Utc).AddTicks(7605), 4, "Origin Story:\r\nDeep within the lush rainforests of West Africa, the majestic Ficus Lyrata, known colloquially as the Fiddle Leaf Fig, reigns as a verdant monarch of the jungle. Its origins intertwine with the ancient rhythms of the forest, where sunlight dances through emerald canopies and gentle rains nurture the soil. Born from the earth's embrace and nurtured by the whispers of the wind, the Ficus Lyrata embodies the resilience and grace of its tropical homeland.\r\n\r\nWhy Fiddle Leaf Fig?\r\nThe Fiddle Leaf Fig derives its moniker from the lyrical curvature of its expansive leaves, which resemble the graceful silhouette of a fiddle or violin. Each leaf unfurls with a symphony of green hues, invoking a sense of harmony and tranquility in any space it inhabits. From its ancestral roots to its contemporary allure, the Ficus Lyrata remains a cherished emblem of natural beauty and botanical elegance.", "https://cdn.webshopapp.com/shops/30495/files/448237057/ficus-lyrata-xl-fiddle-leaf-fig-pot-21cm-height-80.jpg", "Ficus Lyrata", 22.30m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderHistoryId",
                table: "Orders",
                column: "OrderHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShoppingCartId",
                table: "Orders",
                column: "ShoppingCartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistories_OrderStatusId",
                table: "OrderHistories",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistories_UserId",
                table: "OrderHistories",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderHistories_OrderHistoryId",
                table: "Orders",
                column: "OrderHistoryId",
                principalTable: "OrderHistories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShoppingCarts_ShoppingCartId",
                table: "Orders",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderHistories_OrderHistoryId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShoppingCarts_ShoppingCartId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderHistories");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderHistoryId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShoppingCartId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "ShoppingCarts");

            migrationBuilder.DropColumn(
                name: "OrderHistoryId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingAddress",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "488864e5-087f-4402-9ada-7e57fc4bd5e6", "AQAAAAEAACcQAAAAEGoRTdC7+DSgonIVQtVpUmh4577lUUVzTWA8qCnPOqocBmW88sJB5evj/jTWQxmFsg==", "21c45c56-80e8-4115-97da-54c04cdb9f65" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27ec412c-6827-47af-91a2-afefb28835fd", "AQAAAAEAACcQAAAAELjfv2S9/oi2ghR35Kb+6t03E7Vxu65as084j9DIAaIasqDzaLW3M/YoH907Rw3xOA==", "ca9f8624-1178-4031-bf24-fbc02ec69ef6" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateAdded", "FullDescription" },
                values: new object[] { new DateTime(2024, 4, 3, 15, 1, 27, 53, DateTimeKind.Utc).AddTicks(1221), "The rose is a classic symbol of love and beauty, known for its exquisite fragrance and delicate petals. This beautiful flower comes in various colors, with the red rose being the most iconic symbol of romance. Our roses are carefully cultivated to ensure freshness and quality." });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartProducts_OrderId",
                table: "ShoppingCartProducts",
                column: "OrderId");
        }
    }
}
