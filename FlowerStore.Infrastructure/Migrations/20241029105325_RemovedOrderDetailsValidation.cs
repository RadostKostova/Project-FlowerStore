using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class RemovedOrderDetailsValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderDetails",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                comment: "More details of the order",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "OrderDetails",
                table: "Orders",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                comment: "More details of the order",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "More details of the order");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e650025-7ed8-4281-847e-d92f62ac95bc", "AQAAAAEAACcQAAAAEGZY6djLRTsQIRcOdx1798A0XfHcEkycjCUrEPaEnGNLhXLRU5Z6Rv3cdnUTBpBptw==", "31366419-f117-4166-858a-0cb5fdabbbfc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5cada9f1-9178-4297-917f-9137da1fedb5", "AQAAAAEAACcQAAAAEEXnkrShU7KziWEdkK8xcmVlxkSCbkilSldvO1IvOGW+vQ40/Vvc2cGS6epu1avXCA==", "6ae7bc43-0918-4a42-8b20-f5044ec3be07" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 10, 28, 8, 29, 15, 695, DateTimeKind.Utc).AddTicks(2127));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 10, 28, 8, 29, 15, 695, DateTimeKind.Utc).AddTicks(2128));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 10, 28, 8, 29, 15, 695, DateTimeKind.Utc).AddTicks(2128));
        }
    }
}
