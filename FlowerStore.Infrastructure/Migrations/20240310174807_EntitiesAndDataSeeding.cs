using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    /// <summary>
    /// CHANGED THE DELETE BEHAVIOUR TO "Restrict" !!!
    /// </summary>

    public partial class EntitiesAndDataSeeding : Migration
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Product identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Product name"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category identifier"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Price of product"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Product image"),
                    Availability = table.Column<bool>(type: "bit", nullable: false, comment: "Indicator for in stock/out of stock"),
                    FullDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Product description"),
                    FlowersCount = table.Column<int>(type: "int", maxLength: 10, nullable: false, comment: "Counter of product in stock")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Cart identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Product quantity in cart"),
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
                        onDelete: ReferentialAction.Restrict);
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
                    ShippingDetails = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "More details of the order"),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_OrderStatuses_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "OrderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "Product identifier"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductShoppingCarts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "Product identifier"),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false, comment: "Cart identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductShoppingCarts", x => new { x.ProductId, x.ShoppingCartId });
                    table.ForeignKey(
                        name: "FK_ProductShoppingCarts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductShoppingCarts_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductOrders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false, comment: "Order identifier"),
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "Product identifier"),
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Order line identifier"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Quantity of products in order"),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Unit's price of product")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOrders", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_ProductOrders_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "adminId", 0, "dfd0a9da-800b-458a-b96c-dca51a85b3d4", "admin@admin.bg", false, false, null, "admin@admin.bg", "admin", null, null, false, "0fd8100b-b3f6-442d-9761-793db18b5ffc", false, "Admin" },
                    { "testId", 0, "e3c7d12c-20fd-4dee-83a4-a969a2441093", "test@abv.bg", false, false, null, "test@abv.bg", "test", "AQAAAAEAACcQAAAAEPf1CmwBdA1S8w295oyEhnpYpP+DN1CuGyJQXMlPSsfvNV4Z/B/1MpPSmhaRaRA0lQ==", null, false, "ecfe9a50-3577-430a-9037-a920e0e62171", false, "Test" }
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
                table: "Products",
                columns: new[] { "Id", "Availability", "CategoryId", "FlowersCount", "FullDescription", "ImageUrl", "Name", "Price" },
                values: new object[] { 1, true, 6, 5, "The rose is a classic symbol of love and beauty, known for its exquisite fragrance and delicate petals. This beautiful flower comes in various colors, with the red rose being the most iconic symbol of romance. Our roses are carefully cultivated to ensure freshness and quality.", "https://plantparadise.in/cdn/shop/products/ROSE1_4a1f52f8-ebe7-4dab-93ed-f7af98cb11e7.jpg?v=1691200467", "Rose", 4.00m });

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, "adminId" });

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_UserId",
                table: "Administrators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CardDetails_UserId",
                table: "CardDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderStatusId",
                table: "Orders",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentMethodId",
                table: "Orders",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_OrderId",
                table: "ProductOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShoppingCarts_ShoppingCartId",
                table: "ProductShoppingCarts",
                column: "ShoppingCartId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "CardDetails");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ProductOrders");

            migrationBuilder.DropTable(
                name: "ProductShoppingCarts");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropTable(
                name: "OrderStatuses");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

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
