using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class RecreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Administrator's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrators_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CardDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Card identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    CardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false, comment: "Card number"),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Card's expiration date"),
                    CVV = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false, comment: "Code of Card Verification Value"),
                    CardHolderName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "First and last name of holder")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardDetails_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Category identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false, comment: "Name of category")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Order status identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderStatusName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false, comment: "Name of the order status")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Chosen payment idenfitier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Payment option name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Cart identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductsCounter = table.Column<int>(type: "int", maxLength: 15, nullable: false, comment: "Count of products in cart"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Cart total price"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Product identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Product name"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Price of product"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category identifier"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Product image"),
                    Availability = table.Column<bool>(type: "bit", nullable: false, comment: "Indicator for in stock/out of stock"),
                    FullDescription = table.Column<string>(type: "nvarchar(3000)", maxLength: 3000, nullable: false, comment: "Product description"),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Product add date"),
                    FlowersCount = table.Column<int>(type: "int", maxLength: 20, nullable: false, comment: "Counter of product in stock")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Order identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Order date"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Payment amount"),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false, comment: "Chosen payment identifier"),
                    OrderDetails = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false, comment: "More details of the order"),
                    ShippingAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Shipping address"),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false, comment: "Order status identifier"),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false, comment: "Shopping Cart identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatuses_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartsProducts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "Product identifier"),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false, comment: "Cart identifier"),
                    Quantity = table.Column<int>(type: "int", maxLength: 20, nullable: false, comment: "Quantity of product"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Price of product")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartsProducts", x => new { x.ShoppingCartId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_ShoppingCartsProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartsProducts_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Order history identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "User identifier"),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false, comment: "Order status identifier"),
                    OrderId = table.Column<int>(type: "int", nullable: false, comment: "Order identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderHistories_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderHistories_OrderStatuses_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdersProducts",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false, comment: "Order identifier"),
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "Product identifier"),
                    Quantity = table.Column<int>(type: "int", maxLength: 20, nullable: false, comment: "Quantity of product"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price of product")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersProducts", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrdersProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "adminId", 0, "1e650025-7ed8-4281-847e-d92f62ac95bc", "admin@mail.com", false, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEGZY6djLRTsQIRcOdx1798A0XfHcEkycjCUrEPaEnGNLhXLRU5Z6Rv3cdnUTBpBptw==", null, false, "31366419-f117-4166-858a-0cb5fdabbbfc", false, "admin@mail.com" },
                    { "testId", 0, "5cada9f1-9178-4297-917f-9137da1fedb5", "test@test.com", false, false, null, "TEST@TEST.COM", "TEST@TEST.COM", "AQAAAAEAACcQAAAAEEXnkrShU7KziWEdkK8xcmVlxkSCbkilSldvO1IvOGW+vQ40/Vvc2cGS6epu1avXCA==", null, false, "6ae7bc43-0918-4a42-8b20-f5044ec3be07", false, "test@test.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Tropical" },
                    { 2, "Desert" },
                    { 3, "Indoor" },
                    { 4, "Outdoor" },
                    { 5, "Wildflowers" },
                    { 6, "Garden" },
                    { 7, "Exotic" },
                    { 8, "Native" },
                    { 9, "Seasonal" },
                    { 10, "Other" }
                });

            migrationBuilder.InsertData(
                table: "OrderStatuses",
                columns: new[] { "Id", "OrderStatusName" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Shipped" },
                    { 3, "Delivered" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cash" },
                    { 2, "Card" }
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, "adminId" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Availability", "CategoryId", "DateAdded", "FlowersCount", "FullDescription", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, true, 6, new DateTime(2024, 10, 28, 8, 29, 15, 695, DateTimeKind.Utc).AddTicks(2127), 5, "The rose is a classic symbol of love and beauty, known for its exquisite fragrance and delicate petals. This beautiful flower comes in various colors, with the red rose being the most iconic symbol of romance. Our roses are carefully cultivated to ensure freshness and quality.Origin Story:\r\nIn the tapestry of botanical history, the Red Rose emerges as a symbol of passion, romance, and enduring love. Its origins are steeped in ancient lore, tracing back to the verdant gardens of Persia, where its scarlet petals first unfurled beneath the gaze of starlit skies. Legends speak of goddesses and mortal admirers alike, captivated by the velvety allure and intoxicating fragrance of this timeless bloom.\r\n\r\nWhy Red?\r\nThe Red Rose, with its velvety crimson petals, symbolizes the fervent flames of love and desire. Its rich hue evokes the blush of a lover's cheek and the ardor of a heart aflame. From clandestine rendezvous to grand declarations, the Red Rose has enraptured souls throughout the ages, transcending boundaries of time and culture with its timeless allure.", "https://plantparadise.in/cdn/shop/products/ROSE1_4a1f52f8-ebe7-4dab-93ed-f7af98cb11e7.jpg?v=1691200467", "Rose", 4.00m },
                    { 2, true, 7, new DateTime(2024, 10, 28, 8, 29, 15, 695, DateTimeKind.Utc).AddTicks(2128), 7, "Origin Story:\r\nThe elusive Blue Orchid, with its captivating hue, whispers tales of ancient mystique and ethereal beauty. Legend has it that this rare bloom emerged from the depths of forgotten realms, its petals kissed by moonlight and tears of the gods. Its enchanting color, a symphony of cobalt and azure, reflects the secrets of the universe, beckoning admirers into a world of wonder and enchantment.\r\n\r\nWhy Blue?\r\nUnlike its vibrant counterparts, the Blue Orchid owes its unique coloration to a delicate balance of genetic mutation and environmental alchemy. Through a serendipitous interplay of genetic expression and environmental factors, this majestic flower dons its celestial cloak, inviting awe and admiration from all who behold its splendor.", "https://fyf.tac-cdn.net/images/products/large/P-149.jpg?auto=webp&quality=60&width=690", "Blue Orchid", 17.50m },
                    { 3, true, 7, new DateTime(2024, 10, 28, 8, 29, 15, 695, DateTimeKind.Utc).AddTicks(2128), 4, "Origin Story:\r\nDeep within the lush rainforests of West Africa, the majestic Ficus Lyrata, known colloquially as the Fiddle Leaf Fig, reigns as a verdant monarch of the jungle. Its origins intertwine with the ancient rhythms of the forest, where sunlight dances through emerald canopies and gentle rains nurture the soil. Born from the earth's embrace and nurtured by the whispers of the wind, the Ficus Lyrata embodies the resilience and grace of its tropical homeland.\r\n\r\nWhy Fiddle Leaf Fig?\r\nThe Fiddle Leaf Fig derives its moniker from the lyrical curvature of its expansive leaves, which resemble the graceful silhouette of a fiddle or violin. Each leaf unfurls with a symphony of green hues, invoking a sense of harmony and tranquility in any space it inhabits. From its ancestral roots to its contemporary allure, the Ficus Lyrata remains a cherished emblem of natural beauty and botanical elegance.", "https://cdn.webshopapp.com/shops/30495/files/448237057/ficus-lyrata-xl-fiddle-leaf-fig-pot-21cm-height-80.jpg", "Ficus Lyrata", 22.30m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_UserId",
                table: "Administrators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CardDetails_UserId",
                table: "CardDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistories_OrderId",
                table: "OrderHistories",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistories_OrderStatusId",
                table: "OrderHistories",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMethodId",
                table: "Orders",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShoppingCartId",
                table: "Orders",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdersProducts_ProductId",
                table: "OrdersProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartsProducts_ProductId",
                table: "ShoppingCartsProducts",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "CardDetails");

            migrationBuilder.DropTable(
                name: "OrderHistories");

            migrationBuilder.DropTable(
                name: "OrdersProducts");

            migrationBuilder.DropTable(
                name: "ShoppingCartsProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId");
        }
    }
}
