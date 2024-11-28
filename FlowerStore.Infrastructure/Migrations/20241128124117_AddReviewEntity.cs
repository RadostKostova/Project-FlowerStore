using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class AddReviewEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Review identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false, comment: "Content of review"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Creation date"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8783192-16f4-4820-9239-201f064f6cab", "AQAAAAEAACcQAAAAELGjroEYIM+6c8SntS1i4BoWfOGKEwN5zIVkmJafeF2PXvLNU2eh2d2lS7Rp1v4kwA==", "d3207cab-ff7c-4954-b122-70be22a258b3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d0898a3-74c2-404e-a058-fd7f40a0cbc5", "AQAAAAEAACcQAAAAEH3We/klgP62XKrXBNJJXEtwh4e/vJzXd/7KjNJwZn9UvOHUUvPRod5Si+ZJEo5adA==", "31121064-d83e-45cf-a482-91c257407f04" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 11, 28, 12, 41, 17, 396, DateTimeKind.Utc).AddTicks(2519));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 11, 28, 12, 41, 17, 396, DateTimeKind.Utc).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 11, 28, 12, 41, 17, 396, DateTimeKind.Utc).AddTicks(2521));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2024, 11, 28, 12, 41, 17, 396, DateTimeKind.Utc).AddTicks(2521));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2024, 11, 28, 12, 41, 17, 396, DateTimeKind.Utc).AddTicks(2522));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2024, 11, 28, 12, 41, 17, 396, DateTimeKind.Utc).AddTicks(2523));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2024, 11, 28, 12, 41, 17, 396, DateTimeKind.Utc).AddTicks(2523));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2024, 11, 28, 12, 41, 17, 396, DateTimeKind.Utc).AddTicks(2524));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2024, 11, 28, 12, 41, 17, 396, DateTimeKind.Utc).AddTicks(2524));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2024, 11, 28, 12, 41, 17, 396, DateTimeKind.Utc).AddTicks(2525));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2024, 11, 28, 12, 41, 17, 396, DateTimeKind.Utc).AddTicks(2526));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2024, 11, 28, 12, 41, 17, 396, DateTimeKind.Utc).AddTicks(2526));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2024, 11, 28, 12, 41, 17, 396, DateTimeKind.Utc).AddTicks(2527));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2024, 11, 28, 12, 41, 17, 396, DateTimeKind.Utc).AddTicks(2527));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2024, 11, 28, 12, 41, 17, 396, DateTimeKind.Utc).AddTicks(2528));

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8a83462-e59b-4fcc-962d-2eb22c3b83e3", "AQAAAAEAACcQAAAAEEabvkNdZkjp8JkJhL1nBJ6axC88W9ia256mb1iA9pjUEndoVa578FEFSmhmqSoSew==", "a7c4520b-d33d-4cd2-9c45-3c9b9d915a2a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7244df7-69e8-4507-9f67-1209a7e9996a", "AQAAAAEAACcQAAAAEGNvPfOI9XeWET/cnoLq6RM6wxNh6vmJZ0jAKDQYfJKiNHCtFU2+wAERP084iEQ5ww==", "2293a3b0-b36b-4f7f-9184-18a65ca84db5" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7384));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7384));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7385));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7386));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7386));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7387));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7387));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7388));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7389));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7389));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7390));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7390));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7391));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7391));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2024, 11, 27, 10, 55, 35, 161, DateTimeKind.Utc).AddTicks(7392));
        }
    }
}
