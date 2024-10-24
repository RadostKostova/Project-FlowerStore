using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class OrderProductsRemovedAndAddedOrderIdToCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                column: "DateAdded",
                value: new DateTime(2024, 4, 3, 15, 1, 27, 53, DateTimeKind.Utc).AddTicks(1221));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b5aa52db-10a0-45dd-9080-82b9dcb78022", "AQAAAAEAACcQAAAAEBSrVl20Uge8KiwDc5StL15lrCcN6ZySgNf8aF71+miUteSwq0zzF9aPT9Te9qPeYw==", "fa6cff94-b456-44c7-9a6e-dcc969221d15" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba878815-846a-49a1-91b6-9411836d0657", "AQAAAAEAACcQAAAAEM3HmTWS+WMYg2NQ963iUBN4WWoj3J4CsqJ2tVB2kylTYDStLozwf5S5//WKHeIZ2w==", "7d87158a-b736-41e7-a8c9-ad6e952b2ba0" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 4, 3, 11, 44, 22, 153, DateTimeKind.Utc).AddTicks(5241));
        }
    }
}
