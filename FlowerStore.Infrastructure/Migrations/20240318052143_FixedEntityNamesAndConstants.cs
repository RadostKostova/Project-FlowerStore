using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class FixedEntityNamesAndConstants : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductOrders");

            migrationBuilder.DropTable(
                name: "ProductShoppingCarts");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ShoppingCarts");

            migrationBuilder.AddColumn<int>(
                name: "ProductsCounter",
                table: "ShoppingCarts",
                type: "int",
                maxLength: 15,
                nullable: false,
                defaultValue: 0,
                comment: "Count of products in cart");

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "Product identifier"),
                    OrderId = table.Column<int>(type: "int", nullable: false, comment: "Order identifier"),
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Order line identifier"),
                    Quantity = table.Column<int>(type: "int", maxLength: 20, nullable: false, comment: "Unit's quantity of product"),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Unit's price of product")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.ProductId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartProducts",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "Product identifier"),
                    ShoppingCartId = table.Column<int>(type: "int", nullable: false, comment: "Cart identifier"),
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Cart product identifier"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Quantity of product"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false, comment: "Price of product")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartProducts", x => new { x.ProductId, x.ShoppingCartId });
                    table.ForeignKey(
                        name: "FK_ShoppingCartProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartProducts_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83d7cb47-e54b-4430-9c69-f22d84d98601", "AQAAAAEAACcQAAAAEEM0svw1GrRxJYLt/UCnFH6STPLqu1ozQfAxU8QNq/dwhx8lxfRM4X5sh7Kth84cnA==", "6d37f81a-d09f-4924-8017-4d81a7056025" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36fde107-973b-4757-b591-4d59da91a6de", "AQAAAAEAACcQAAAAEMjx/ivMSUkkejc2zadPmAAcp6AKne/JTjjBhdx7dkB4lmMmg+21wSswvcXQqx8i1A==", "00d689ec-cb3c-4aa1-b189-1c77b4b90269" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 3, 18, 5, 21, 43, 218, DateTimeKind.Utc).AddTicks(8601));

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartProducts_ShoppingCartId",
                table: "ShoppingCartProducts",
                column: "ShoppingCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "ShoppingCartProducts");

            migrationBuilder.DropColumn(
                name: "ProductsCounter",
                table: "ShoppingCarts");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ShoppingCarts",
                type: "int",
                maxLength: 15,
                nullable: false,
                defaultValue: 0,
                comment: "Product quantity in cart");

            migrationBuilder.CreateTable(
                name: "ProductOrders",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "Product identifier"),
                    OrderId = table.Column<int>(type: "int", nullable: false, comment: "Order identifier"),
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Order line identifier"),
                    Quantity = table.Column<int>(type: "int", maxLength: 20, nullable: false, comment: "Unit's quantity of product"),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductOrders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductShoppingCarts_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ca43a7b-4890-487c-b0d0-7359e8d556c6", "AQAAAAEAACcQAAAAEOfftu0PVWuCJUfdDnKAJiHcfgpMHI+qvXu/3rprngpWLtQTCDzPxMpZpdJFSIs/kA==", "40870f56-66de-4681-b911-da0a12dd0750" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "347bdbb6-2e5f-4e9f-bb84-b9fe8acc2bfc", "AQAAAAEAACcQAAAAEEOPZYmkJcggkaxgwFRMt0ebHYLf52LldUKBaaAJx+dCrNsoe+CADW/dBy27xrj4lA==", "35713c42-f147-4b7a-a346-03c03ae1544d" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 3, 15, 15, 47, 58, 161, DateTimeKind.Utc).AddTicks(4564));

            migrationBuilder.CreateIndex(
                name: "IX_ProductOrders_OrderId",
                table: "ProductOrders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductShoppingCarts_ShoppingCartId",
                table: "ProductShoppingCarts",
                column: "ShoppingCartId");
        }
    }
}
