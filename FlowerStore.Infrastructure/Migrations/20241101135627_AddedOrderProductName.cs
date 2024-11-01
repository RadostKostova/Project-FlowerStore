using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class AddedOrderProductName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "OrdersProducts",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "Product name");

            migrationBuilder.AlterColumn<string>(
                name: "OrderDetails",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                comment: "More details of the order",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "More details of the order");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "OrdersProducts");

            migrationBuilder.AlterColumn<string>(
                name: "OrderDetails",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "More details of the order",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldComment: "More details of the order");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b9378602-0eb1-4645-8b34-12400e9814c8", "AQAAAAEAACcQAAAAEHJYV3QkQpkVhBhr2IFvbyuVa+zmhlqLgWXV35Tn+NG04FVR6xvSamggDecA2vLUYA==", "ef8ba718-e77f-46f7-ab68-06a12ad275d7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cceb3c94-77c9-49ff-8451-0f3f43278e81", "AQAAAAEAACcQAAAAEF2Sb2bmObkqKVW9c0NqMzPXRBB07iLtckpA3xmuMNnEVKZOFc9SoQtUq5XiDe9K1w==", "04ec14df-0d8b-40e1-934c-68f11f7f4012" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 10, 29, 10, 53, 25, 16, DateTimeKind.Utc).AddTicks(3165));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 10, 29, 10, 53, 25, 16, DateTimeKind.Utc).AddTicks(3165));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 10, 29, 10, 53, 25, 16, DateTimeKind.Utc).AddTicks(3166));
        }
    }
}
