using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class RemovedOrderHistoryAndOrderHistoryProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "OrderProductHistories");

            migrationBuilder.DropTable(
                name: "OrderHistories");

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
                column: "DateAdded",
                value: new DateTime(2024, 11, 18, 15, 19, 23, 645, DateTimeKind.Utc).AddTicks(1774));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 11, 18, 15, 19, 23, 645, DateTimeKind.Utc).AddTicks(1775));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 11, 18, 15, 19, 23, 645, DateTimeKind.Utc).AddTicks(1775));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Order history identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false, comment: "Order identifier"),
                    OrderStatusId = table.Column<int>(type: "int", nullable: false, comment: "Order status identifier"),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false, comment: "Payment method identifier"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Email"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "First name"),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Last name"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Order date"),
                    OrderDetails = table.Column<string>(type: "nvarchar(max)", nullable: true, comment: "Additional details of the order"),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false, comment: "Phone"),
                    ShippingAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Shipping address"),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Total order price")
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
                    table.ForeignKey(
                        name: "FK_OrderHistories_PaymentMethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProductHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Order product identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderHistoryId = table.Column<int>(type: "int", nullable: false, comment: "Order history identifier"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price per unit"),
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "Product identifier"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Product name at the time of order"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Quantity of product")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProductHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProductHistory_OrderHistories_OrderHistoryId",
                        column: x => x.OrderHistoryId,
                        principalTable: "OrderHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "987d9084-b9ce-45a9-91a4-7d2ddfe364de", "AQAAAAEAACcQAAAAEAc68ImKdKwyT2eJFg99Q2R7lCjC4q7Jitb4B7Nhmeo6qXrHQL6r4NA+DKcDpxvAbg==", "ead1d47d-28e2-4db6-b266-e23f7b20dd39" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a246082-3a6a-4eab-9d2a-1233baf22a37", "AQAAAAEAACcQAAAAEGWs3YTUZM9n6DIrlLzVm2o+CKakhyF3GYO/0qRmaY6kAuGK0cFugwtzYd16Dw1ufA==", "6f2d3b17-c792-4b5b-9d38-1118bf632515" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 11, 16, 0, 4, 17, 253, DateTimeKind.Utc).AddTicks(3422));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 11, 16, 0, 4, 17, 253, DateTimeKind.Utc).AddTicks(3423));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 11, 16, 0, 4, 17, 253, DateTimeKind.Utc).AddTicks(3424));

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistories_OrderId",
                table: "OrderHistories",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistories_OrderStatusId",
                table: "OrderHistories",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistories_PaymentMethodId",
                table: "OrderHistories",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistories_UserId",
                table: "OrderHistories",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProductHistory_OrderHistoryId",
                table: "OrderProductHistory",
                column: "OrderHistoryId");
        }
    }
}
