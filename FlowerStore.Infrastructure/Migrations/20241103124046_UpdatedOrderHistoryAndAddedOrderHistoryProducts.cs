using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class UpdatedOrderHistoryAndAddedOrderHistoryProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "OrderHistories",
                type: "nvarchar(450)",
                nullable: false,
                comment: "User identifier",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "User identifier");

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "OrderHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Order date");

            migrationBuilder.AddColumn<string>(
                name: "OrderDetails",
                table: "OrderHistories",
                type: "nvarchar(max)",
                nullable: true,
                comment: "Additional details of the order");

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodId",
                table: "OrderHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                comment: "Payment method identifier");

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress",
                table: "OrderHistories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                comment: "Shipping address");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "OrderHistories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Total order price");

            migrationBuilder.CreateTable(
                name: "OrderProductHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Order product identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderHistoryId = table.Column<int>(type: "int", nullable: false, comment: "Order history identifier"),
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "Product identifier"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Price per unit"),
                    Quantity = table.Column<int>(type: "int", nullable: false, comment: "Quantity of product"),
                    ProductName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Product name at the time of order")
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
                values: new object[] { "718f312a-e77f-417c-b213-02f5028a6f02", "AQAAAAEAACcQAAAAEKl2zNyA/7jhU6G8056WlFycO1vhfWFPyNkYtktNDngRS5Ue+OzkIKivzdDyXHGYLQ==", "acfcd913-4ffb-45e7-a476-52c8a7879212" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e712da41-c833-49c9-ae75-9d03c6b5f572", "AQAAAAEAACcQAAAAEInP2ZKyvXmSZpNo8R0gBeg198rKtmmRxAT67r8E0fY+MI/MyhuMrKY8TsLfDTBb5g==", "537ad807-190d-4649-aecb-984f997a015c" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 11, 3, 12, 40, 46, 196, DateTimeKind.Utc).AddTicks(3497));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 11, 3, 12, 40, 46, 196, DateTimeKind.Utc).AddTicks(3498));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 11, 3, 12, 40, 46, 196, DateTimeKind.Utc).AddTicks(3499));

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

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHistories_AspNetUsers_UserId",
                table: "OrderHistories",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHistories_PaymentMethods_PaymentMethodId",
                table: "OrderHistories",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHistories_AspNetUsers_UserId",
                table: "OrderHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderHistories_PaymentMethods_PaymentMethodId",
                table: "OrderHistories");

            migrationBuilder.DropTable(
                name: "OrderProductHistory");

            migrationBuilder.DropIndex(
                name: "IX_OrderHistories_PaymentMethodId",
                table: "OrderHistories");

            migrationBuilder.DropIndex(
                name: "IX_OrderHistories_UserId",
                table: "OrderHistories");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "OrderHistories");

            migrationBuilder.DropColumn(
                name: "OrderDetails",
                table: "OrderHistories");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                table: "OrderHistories");

            migrationBuilder.DropColumn(
                name: "ShippingAddress",
                table: "OrderHistories");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "OrderHistories");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "OrderHistories",
                type: "nvarchar(max)",
                nullable: false,
                comment: "User identifier",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "User identifier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b432062c-31ee-4b18-8b73-06f54bd4a766", "AQAAAAEAACcQAAAAEN1K3WpiVbwqAZ4f5aSVP5r1mMM/pJaktwAzyGmZQO9oocG61L0BmHlDFXJfHy1ezA==", "48810b7c-9982-4cfb-87ae-081f0dc853d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "09ebf992-50be-43b4-b01d-160f97c7ccc6", "AQAAAAEAACcQAAAAEFK9w1QocOuEQJSE+68LHOhO3dqw3YSyW4w6nRVOE89mXRWxSayYJc6uTRrq5zyQFw==", "3c29d33d-23bd-4db4-9b39-ce2dab0ea5b9" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 11, 1, 13, 56, 27, 578, DateTimeKind.Utc).AddTicks(1272));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 11, 1, 13, 56, 27, 578, DateTimeKind.Utc).AddTicks(1273));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 11, 1, 13, 56, 27, 578, DateTimeKind.Utc).AddTicks(1274));
        }
    }
}
