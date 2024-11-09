using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class AddedCardDetailsToOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardDetailsId",
                table: "Orders",
                type: "int",
                nullable: true,
                comment: "Card identifier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66e72f93-f4aa-4873-8595-2d17da9180b5", "AQAAAAEAACcQAAAAEH87v6zBHbJ7ZynINKdFKhsOn5w+IEKsgFVab7zbHXo67gu5Nm0n+0dcoXLQ8HAfGQ==", "73ec08c3-7156-4b36-bb90-9baaaf2907d3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d61b0a8a-4a43-4648-866e-a8d7e777234d", "AQAAAAEAACcQAAAAEKKzLBstO6QsW2blkiwQKGYAaAXrhByRStIia6FQOnMEa2MXmgnxpMJqtVcBsbw5LQ==", "14ab6dd0-ab2d-466c-b85a-7efb0bbe2244" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 11, 9, 12, 50, 43, 349, DateTimeKind.Utc).AddTicks(7604));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 11, 9, 12, 50, 43, 349, DateTimeKind.Utc).AddTicks(7608));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 11, 9, 12, 50, 43, 349, DateTimeKind.Utc).AddTicks(7610));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CardDetailsId",
                table: "Orders",
                column: "CardDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CardDetails_CardDetailsId",
                table: "Orders",
                column: "CardDetailsId",
                principalTable: "CardDetails",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CardDetails_CardDetailsId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CardDetailsId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CardDetailsId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "692a3c61-974c-4097-98f1-e03a18e287df", "AQAAAAEAACcQAAAAEMuDlkyL742Ss2hz2BIutfOaEOJwHHRvteTpFvN2sjNTKimIfvhmx5p+TvJwrPZtFA==", "ff81be86-9824-40a2-a51c-b4ecfaaf0402" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f442b0e-cb4d-49b3-907f-281a0b06bde4", "AQAAAAEAACcQAAAAELvqSzRZebLYccFnUU6APW2UsJc2qXVR6Htfhknjvz+96E9MQy/jqrnFBLTDwS3U7w==", "bd383a3d-2412-44b4-8840-6f16a5299d45" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 11, 5, 13, 26, 11, 37, DateTimeKind.Utc).AddTicks(1989));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 11, 5, 13, 26, 11, 37, DateTimeKind.Utc).AddTicks(1990));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 11, 5, 13, 26, 11, 37, DateTimeKind.Utc).AddTicks(1990));
        }
    }
}
