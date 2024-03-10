using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class ModifyInitialConstraints : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShippingDetails",
                table: "Orders",
                newName: "OrderDetails");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "ProductOrders",
                type: "int",
                maxLength: 20,
                nullable: false,
                comment: "Unit's quantity of product",
                oldClrType: typeof(int),
                oldType: "int",
                oldComment: "Quantity of products in order");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "26b6655e-725c-44a7-bbf3-cbb72f839936", "AQAAAAEAACcQAAAAEE/k+hg/fcDpJIJKwvbXXLuLtCrc0F19+S2vymmiVlax7a40+R12jT05PVvZb8lYXA==", "ca79b136-1e2a-4f0e-92aa-6395ccf95197" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0219fcf6-f0f4-4d05-80d7-018a15d0f712", "AQAAAAEAACcQAAAAEHbFSOsCYb1/f1TgEK4mGU8xHs6iCy6lW15NlyegAL4m5z/F1dgHq74oA/LDEzMuMw==", "0afe01a2-5cf3-431a-b5f3-d2383eb9b6f2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderDetails",
                table: "Orders",
                newName: "ShippingDetails");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "ProductOrders",
                type: "int",
                nullable: false,
                comment: "Quantity of products in order",
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 20,
                oldComment: "Unit's quantity of product");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c8bbd0db-10ab-46ba-babd-a6948550b798", "AQAAAAEAACcQAAAAEGK0iXBeHMeNRma/e2b35UNbZy6W+mEdqmyrPSh+TRu/0BSxm3a9eL2s3XEMCMP1bA==", "48bbbea7-ed41-4f61-a01c-290082ea8a0d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46e21393-e054-4be8-8391-f85afcd1bf6a", "AQAAAAEAACcQAAAAEA4ZmQk79OtqOv58j20rAnwRop3CD1MRA3+2P4Xez6fFWn/BocKunIkRaj0LjO2LQA==", "df7b6b1f-ec28-4633-a789-6b44c34518cd" });
        }
    }
}
