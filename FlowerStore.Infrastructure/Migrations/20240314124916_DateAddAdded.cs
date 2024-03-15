using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class DateAddAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullDescription",
                table: "Products",
                type: "nvarchar(3000)",
                maxLength: 3000,
                nullable: false,
                comment: "Product description",
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldComment: "Product description");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Product add date");

            migrationBuilder.AlterColumn<string>(
                name: "OrderDetails",
                table: "Orders",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                comment: "More details of the order",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldComment: "More details of the order");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5923bb51-54ef-4e75-8dbf-a0aecb690c06", "AQAAAAEAACcQAAAAEG3RDJ5ru/89Ra51fMjd1kiQLwB1JjN3Zv6yqFfa6HruFr1Y1ldjCpaGivJmxm0+tg==", "3fa52fac-d979-4a09-abf5-42a947d64cd2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9919174-19bc-4590-a880-67346b5c2a29", "AQAAAAEAACcQAAAAEFptF09bWuWHYlfyG4k3joNo34Hk/g/Zy1DJWJj0HxKXJX+eWFWx8GW85zoqGeJ2tg==", "10784ac0-86ad-49d2-aae5-3282a854b0ea" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 3, 14, 12, 49, 16, 669, DateTimeKind.Utc).AddTicks(1149));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "FullDescription",
                table: "Products",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                comment: "Product description",
                oldClrType: typeof(string),
                oldType: "nvarchar(3000)",
                oldMaxLength: 3000,
                oldComment: "Product description");

            migrationBuilder.AlterColumn<string>(
                name: "OrderDetails",
                table: "Orders",
                type: "nvarchar(100)",
                maxLength: 100,
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
                values: new object[] { "af7338fe-608a-41c3-820f-d144b1400974", "AQAAAAEAACcQAAAAEBOEir5dm5EcfpPADCYZlmuEvIyxmgk+JDNXqBNtzXdOeIQZM/b7Onnm4sF10qyCew==", "ae32ac68-c765-4933-bf80-f76ce0e14289" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ec1d7448-28f3-4d99-8e28-c1baf5ba362c", "AQAAAAEAACcQAAAAEM1EzetsgLowtWi8a4CtqJ7cUO+EQGTgiCyg4REvfGitXa72CZGAlthM/cwdogzwkA==", "042dbc47-9a86-4c57-8879-cfb1d14c41de" });
        }
    }
}
