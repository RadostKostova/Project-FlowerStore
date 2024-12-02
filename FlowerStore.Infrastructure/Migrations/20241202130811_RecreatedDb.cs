using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class RecreatedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "First name"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Last name"),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Phone number"),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CardDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Card identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "User identifier"),
                    CardNumber = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false, comment: "Card number"),
                    ExpirationDate = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false, comment: "Card's expiration date"),
                    CVV = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false, comment: "Code of Card Verification Value"),
                    CardHolderName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "First and last name of holder")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardDetails", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Review identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Content of review"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Creation date"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    OrderDetails = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "More details of the order"),
                    ShippingAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Shipping address"),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false, comment: "Order status identifier"),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false, comment: "Shopping Cart identifier"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "First name"),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Last name"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Email"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Phone"),
                    CardDetailsId = table.Column<int>(type: "int", nullable: true, comment: "Card identifier")
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
                        name: "FK_Orders_CardDetails_CardDetailsId",
                        column: x => x.CardDetailsId,
                        principalTable: "CardDetails",
                        principalColumn: "Id");
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
                name: "OrdersProducts",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false, comment: "Order identifier"),
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "Product identifier"),
                    ProductName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Product name"),
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
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "Phone", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "9a53e015-990d-4cd0-ae04-2d402060c207", 0, "1dbded71-70e9-49ee-800d-96d3e97b2b64", "test@test.com", false, "Test", "Test", false, null, "TEST@TEST.COM", "TEST@TEST.COM", "AQAAAAEAACcQAAAAEH0U+dfySB7x2x7zUnrWyaqGExY0CCsfEpaFO8aIX2vmiVF3TrBzlx+eJG2/NGjxEQ==", "1234567700", null, false, "61cbac2d-3f7e-4935-b4c2-fec69f970597", false, "test@test.com" },
                    { "a21722de-a984-476a-a7d7-8e48dadde907", 0, "678afe53-6029-467d-977f-2b04aa685f4d", "admin@mail.com", false, "Admin", "Admin", false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEKXW4qSNlIUISXz1BfK0I0vnyHiGlkYx47WCM7Z+knxZEGAzhaaHajWnCO9P5UVB9A==", "1234567890", null, false, "e32d49c3-8676-40cd-964a-ffdcf52cf7ba", false, "admin@mail.com" },
                    { "d5f40bd1-8e34-4354-8996-0f884be97351", 0, "6ecd919e-9b6c-42fc-8399-251591d9743c", "random@random.com", false, "Random", "User", false, null, "RANDOM@RANDOM.COM", "RANDOM@RANDOM.COM", "AQAAAAEAACcQAAAAEMn9RvioMlomPXr3lDCU8xaTMLbKX8I3U+K+6JiXd0xD7m0mAej6IlabDnM470FDsQ==", "0987654321", null, false, "5b2fffa6-1be3-4494-a32b-951e7ca6e7b2", false, "random@random.com" },
                    { "e50f5dc0-298d-4807-88f0-73b88c82e128", 0, "5f83f9ec-125c-47b6-8157-f85e0b38695f", "guest@guest.com", false, "Guest", "Guest", false, null, "GUEST@GUEST.COM", "GUEST@GUEST.COM", "AQAAAAEAACcQAAAAEAwc3YSAxedaKhtuo1GX65GA0LMwFQdIDub/rBWmowA0PuoG+jpbusAxUU1twy7tRQ==", "1234567800", null, false, "bf07f02b-5bb1-4d07-837e-137d6d8a83de", false, "guest@guest.com" }
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
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "Admin Admin", "a21722de-a984-476a-a7d7-8e48dadde907" },
                    { 2, "user:fullname", "Guest Guest", "e50f5dc0-298d-4807-88f0-73b88c82e128" },
                    { 3, "user:fullname", "Test Test", "9a53e015-990d-4cd0-ae04-2d402060c207" },
                    { 4, "user:fullname", "Random User", "d5f40bd1-8e34-4354-8996-0f884be97351" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Availability", "CategoryId", "DateAdded", "FlowersCount", "FullDescription", "ImageUrl", "Name", "Price" },
                values: new object[,]
                {
                    { 1, true, 6, new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2549), 5, "The rose is a classic symbol of love and beauty, known for its exquisite fragrance and delicate petals. This beautiful flower comes in various colors, with the red rose being the most iconic symbol of romance. Our roses are carefully cultivated to ensure freshness and quality. In the tapestry of botanical history, the Red Rose emerges as a symbol of passion, romance, and enduring love. Its origins are steeped in ancient lore, tracing back to the verdant gardens of Persia, where its scarlet petals first unfurled beneath the gaze of starlit skies. Legends speak of goddesses and mortal admirers alike, captivated by the velvety allure and intoxicating fragrance of this timeless bloom. The Red Rose, with its velvety crimson petals, symbolizes the fervent flames of love and desire. Its rich hue evokes the blush of a lover's cheek and the ardor of a heart aflame. From clandestine rendezvous to grand declarations, the Red Rose has enraptured souls throughout the ages, transcending boundaries of time and culture with its timeless allure.", "https://img.freepik.com/premium-photo/red-roses-pot-isolated-white-background_511010-2090.jpg", "Rose", 4.00m },
                    { 2, true, 7, new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2550), 7, "The elusive Blue Orchid, with its captivating hue, whispers tales of ancient mystique and ethereal beauty. Legend has it that this rare bloom emerged from the depths of forgotten realms, its petals kissed by moonlight and tears of the gods. Its enchanting color, a symphony of cobalt and azure, reflects the secrets of the universe, beckoning admirers into a world of wonder and enchantment. Unlike its vibrant counterparts, the Blue Orchid owes its unique coloration to a delicate balance of genetic mutation and environmental alchemy. Through a serendipitous interplay of genetic expression and environmental factors, this majestic flower dons its celestial cloak, inviting awe and admiration from all who behold its splendor.", "https://i.pinimg.com/736x/3e/14/88/3e148876fc1b8d1b4063a6695a7ebc9a.jpg", "Blue Orchid", 17.50m },
                    { 3, true, 7, new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2551), 4, "Deep within the lush rainforests of West Africa, the majestic Ficus Lyrata, known colloquially as the Fiddle Leaf Fig, reigns as a verdant monarch of the jungle. Its origins intertwine with the ancient rhythms of the forest, where sunlight dances through emerald canopies and gentle rains nurture the soil. Born from the earth's embrace and nurtured by the whispers of the wind, the Ficus Lyrata embodies the resilience and grace of its tropical homeland. The Fiddle Leaf Fig derives its moniker from the lyrical curvature of its expansive leaves, which resemble the graceful silhouette of a fiddle or violin. Each leaf unfurls with a symphony of green hues, invoking a sense of harmony and tranquility in any space it inhabits. From its ancestral roots to its contemporary allure, the Ficus Lyrata remains a cherished emblem of natural beauty and botanical elegance.", "https://cdn.webshopapp.com/shops/30495/files/448237057/ficus-lyrata-xl-fiddle-leaf-fig-pot-21cm-height-80.jpg", "Ficus Lyrata", 22.30m },
                    { 4, true, 4, new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2552), 5, "Tagetes, commonly known as marigold, is a genus of flowering plants in the family Asteraceae. These vibrant flowers are native to North and South America but are widely cultivated around the world for ornamental, medicinal, and culinary purposes. Tagetes flowers are typically yellow, orange, or red, often with ruffled or double-petaled blooms. They range in size from small pom-poms to larger, more dramatic heads. They are usually annuals but can sometimes be perennial, depending on the species. Tagetes grows in a bushy habit and varies in size, from compact dwarf varieties to taller plants over a meter high. ", "https://skgarden.bg/media/18/326.jpg", "Orange Tagetes", 12.00m },
                    { 5, true, 6, new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2553), 10, "Begonias are a diverse genus of flowering plants in the family Begoniaceae, encompassing over 2,000 species. They are prized for their vibrant flowers, striking foliage, and adaptability to various growing conditions. Native to tropical and subtropical regions worldwide, begonias are cultivated extensively as ornamental plants. They produce showy flowers in a range of colors, including red, pink, white, and orange. The blooms are often asymmetrical and can vary significantly in size depending on the variety.", "https://skgarden.bg/media/18/160.jpg", "Pink Begonia", 6.50m },
                    { 6, true, 6, new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2554), 10, "Begonias are a diverse genus of flowering plants in the family Begoniaceae, encompassing over 2,000 species. They are prized for their vibrant flowers, striking foliage, and adaptability to various growing conditions. Native to tropical and subtropical regions worldwide, begonias are cultivated extensively as ornamental plants. They produce showy flowers in a range of colors, including red, pink, white, and orange. The blooms are often asymmetrical and can vary significantly in size depending on the variety.", "https://skgarden.bg/media/18/158.jpg", "Red Begonia", 6.00m },
                    { 7, true, 3, new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2555), 4, "The white anthurium, often called the peace lily anthurium or white flamingo flower, is a striking plant known for its elegant white flowers and glossy green leaves. Belonging to the genus Anthurium within the family Araceae, this tropical plant is prized for its ornamental value and ease of care. The \"flower\" is actually a spathe, a modified leaf, typically white or off-white, surrounding a yellow or pale green spadix. Its minimalist aesthetic makes it a popular choice for modern interiors. These plants grow as evergreen perennials, reaching heights of 12–24 inches (30–60 cm) depending on the species or variety.", "https://www.greenthumb.com/wp-content/uploads/2022/10/c6154cf6-cd75-5a1b-99be-d8e97dc6b45b_455bd0bd-8b8f-430f-a309-baaafe792f1b.jpg", "White Anthurium", 24.00m },
                    { 8, true, 6, new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2556), 8, "The yellow begonia is a radiant and cheerful flowering plant belonging to the genus Begonia in the family Begoniaceae. It is loved for its bright yellow blooms, lush foliage, and versatility in gardening. Native to tropical and subtropical regions, begonias have been cultivated worldwide for their ornamental beauty. The blooms are a vivid yellow, often large and lush, with single or double petals depending on the variety. The flowers create a striking contrast against the green leaves. Yellow begonias can grow as upright or trailing plants, depending on the species. They are compact and bushy, making them perfect for small spaces or containers.", "https://www.provenwinners.com/sites/provenwinners.com/files/imagecache/low-resolution/ifa_upload/begonia_solenia_yellow_mono.jpg", "Yellow Begonia", 8.00m },
                    { 9, true, 4, new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2557), 12, "The pink geranium, belonging to the genus Pelargonium in the family Geraniaceae, is a beloved flowering plant known for its vibrant pink blooms and aromatic foliage. Native to South Africa, geraniums are widely cultivated as ornamentals in gardens, pots, and hanging baskets. Pink geraniums produce clusters of five-petaled flowers in various shades of pink, from pastel to bright hues. The flowers often have subtle patterns or darker streaks, adding depth and visual interest. These plants are profuse bloomers, flowering from spring to late autumn in the right conditions.", "https://flower.bigbadmole.com/wp-content/uploads/2019/12/1-zaglavnaja-3.jpg", "Pink Geranium", 5.80m },
                    { 10, true, 6, new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2558), 6, "The purple ageratum, commonly known as floss flower, is a charming and hardy annual plant in the family Asteraceae. Its botanical name is typically Ageratum houstonianum, and it is prized for its fluffy, soft-textured flowers that resemble tufts of thread or floss. Native to Central America and Mexico, purple ageratum is widely grown for its vibrant purple blooms and easy maintenance. Purple ageratum grows in compact mounds, typically reaching heights of 6–12 inches (15–30 cm), depending on the variety. It is a prolific bloomer, flowering continuously from late spring to the first frost in fall.", "https://skgarden.bg/media/18/369.jpg", "Purple Ageratum", 9.30m },
                    { 11, true, 4, new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2558), 14, "The red geranium, a popular variant of the Pelargonium genus in the Geraniaceae family, is admired for its vibrant, long-lasting red blooms and attractive foliage. Native to South Africa, red geraniums are widely cultivated around the world for their ornamental appeal, easy maintenance, and versatility. The bold red flowers grow in clusters atop sturdy stems. The blooms range in shades from bright scarlet to deep crimson and are excellent for adding dramatic color to gardens. Red geraniums can grow upright, spreading, or trailing, making them versatile for beds, borders, containers, and hanging baskets. Plants typically reach heights of 12–24 inches (30–60 cm).", "https://dfwmnhok7ak0p.cloudfront.net/91919/V21964/C/1691650160000/1280.jpg", "Red Geranium", 5.80m },
                    { 12, true, 6, new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2559), 15, "Pink petunias are flowering plants in the genus Petunia, belonging to the family Solanaceae. Known for their trumpet-shaped blooms and vibrant hues, pink petunias are versatile and widely loved for their ability to thrive in various settings. These annuals or tender perennials (in warmer climates) are native to South America. Pink petunias produce abundant, trumpet-shaped flowers in soft pastel, bright, or even patterned pink shades. Some varieties are fragrant, particularly in the evening. Petunias can be upright or trailing, depending on the variety. They typically grow 6–18 inches (15–45 cm) tall and spread up to 24 inches (60 cm).", "https://skgarden.bg/media/18/420.jpg", "Pink Petunias", 5.00m },
                    { 13, true, 6, new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2589), 4, "Pelargonium within the family Geraniaceae. It is a vibrant and showy ornamental plant, prized for its lush purple flowers and fragrant, lobed foliage. Native to South Africa, pelargoniums have become globally popular in gardens and pots for their vivid colors and adaptability. The blooms of purple pelargonium are typically rich in color, ranging from soft lavender to deep purple. The flowers are often multi-toned, with darker markings or streaks on the petals, adding an artistic flair. Depending on the variety, purple pelargoniums can grow upright or exhibit a trailing habit, making them suitable for containers, hanging baskets, and garden beds. They typically grow 12–24 inches (30–60 cm) tall.", "https://skgarden.bg/media/18/436.jpg", "Purple Pelargonium", 6.50m },
                    { 14, true, 4, new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2590), 9, "The white geranium is a striking variant of the Pelargonium genus, a flowering plant in the Geraniaceae family. Known for its pristine white blooms, it’s a popular ornamental plant used in gardens, hanging baskets, and containers. Native to South Africa, geraniums (including white varieties) have been cultivated for their beauty, fragrance, and ease of care. The white geranium produces elegant, pure white flowers, often with subtle markings or veins in the center of each petal. These flowers are typically five-petaled and appear in clusters atop sturdy stems. White geraniums can grow upright or trailing, making them versatile for garden beds, containers, hanging baskets, and window boxes. They usually grow between 12 to 18 inches (30 to 45 cm) in height, depending on the variety.", "https://skgarden.bg/media/18/206.jpg", "White Geranium", 6.70m },
                    { 15, true, 1, new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2591), 3, "The pink hibiscus is a tropical flowering plant belonging to the genus Hibiscus, part of the Malvaceae family. Known for its large, showy blooms and vibrant pink color, this plant is often associated with tropical and subtropical regions around the world. Pink hibiscus is widely cultivated for its striking appearance and symbolic meanings of beauty, femininity, and exoticism. The flowers of pink hibiscus are large, with five petals that can range from soft pastels to vibrant pinks. Some varieties feature darker veins or a contrasting center, making them visually captivating. These flowers can be up to 6 inches (15 cm) in diameter and are often funnel-shaped. Pink hibiscus plants can grow as shrubs, bushes, or small trees, reaching heights of 3–10 feet (1–3 meters), depending on the species and growing conditions. They can have a bushy, rounded shape with a thick, woody trunk.", "https://photo.floraccess.com/5g5qcbeu7okodcmedk0m43tl9shnbbgm245af2bd_Preview480.jpg", "Pink Hibiscus", 32.00m }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "Id", "Content", "CreatedAt", "UserId" },
                values: new object[,]
                {
                    { 1, "Fast delivery and excellent quality. Will buy again for sure!!!", new DateTime(2024, 12, 2, 15, 8, 10, 887, DateTimeKind.Local).AddTicks(3395), "e50f5dc0-298d-4807-88f0-73b88c82e128" },
                    { 2, "The customer service was exceptional! They were very responsive and helped me choose the perfect arrangement. I’ll definitely be ordering again soon.", new DateTime(2024, 12, 2, 15, 8, 10, 887, DateTimeKind.Utc).AddTicks(3401), "9a53e015-990d-4cd0-ae04-2d402060c207" },
                    { 3, "Fast, efficient, and elegant! The flowers were in pristine condition, and the little card included was a nice touch. Amazing experience overall.", new DateTime(2024, 12, 2, 17, 8, 10, 887, DateTimeKind.Utc).AddTicks(3402), "e50f5dc0-298d-4807-88f0-73b88c82e128" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CardDetailsId",
                table: "Orders",
                column: "CardDetailsId");

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
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrdersProducts");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "ShoppingCartsProducts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "CardDetails");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
