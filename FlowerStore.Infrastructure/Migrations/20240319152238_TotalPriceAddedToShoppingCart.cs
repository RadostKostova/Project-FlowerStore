using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class TotalPriceAddedToShoppingCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ProductsCounter",
                table: "ShoppingCarts",
                type: "int",
                maxLength: 15,
                nullable: false,
                comment: "Count of products",
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 15,
                oldComment: "Count of products in cart");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "ShoppingCarts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                comment: "Total price of all products");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6f7584e4-9530-42cb-bc37-167178efe57e", "AQAAAAEAACcQAAAAEMNaAMhKXsr31YkgdmDi32HaEb4HeIE7+MJtgLvi5CXPUICN5mxYccwfgNQmtnxxFQ==", "8e5e4e27-ba98-457e-a415-c50bfb052e7a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2fe7cd2c-ea07-472a-8b16-7453e52d3193", "AQAAAAEAACcQAAAAELq7rziClde6oFl8JwAXDyVWh/53fYyhg5Vkl5nqPc32Z6gH0+RQDvaTcD0nJVGOIA==", "4ffc3a6b-442e-4bc8-bc3f-e2b29dfd41a3" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 3, 19, 15, 22, 38, 548, DateTimeKind.Utc).AddTicks(5487));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "ShoppingCarts");

            migrationBuilder.AlterColumn<int>(
                name: "ProductsCounter",
                table: "ShoppingCarts",
                type: "int",
                maxLength: 15,
                nullable: false,
                comment: "Count of products in cart",
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 15,
                oldComment: "Count of products");

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
        }
    }
}
