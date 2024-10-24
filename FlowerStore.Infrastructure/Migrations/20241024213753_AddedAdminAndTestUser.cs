using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class AddedAdminAndTestUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount" },

                values: new object[] { "adminId", "admin@mail.com", "ADMIN@MAIL.COM", "admin@mail.com", "ADMIN@MAIL.COM", true, "AQAAAAEAACcQAAAAEI8YeWljKK3ve1q0dLMhcwwZu5OPMS6feKpH0aJj2PMPxRvNr4+NPV+fsnSCHS2wSw==", "da62259a-1626-4a8e-855a-97c4b5b70f88", "79c27c43-4ebd-4a72-9dd7-7d13c8530230", null, false, false, null,
                    false, 0
                });

            migrationBuilder.InsertData(
            table: "AspNetUsers",
            columns: new[] { "Id", "UserName", "NormalizedUserName", "Email", "NormalizedEmail", "EmailConfirmed", "PasswordHash", "SecurityStamp", "ConcurrencyStamp", "PhoneNumber", "PhoneNumberConfirmed", "TwoFactorEnabled", "LockoutEnd", "LockoutEnabled", "AccessFailedCount" },
            values: new object[] { "testId", "test@test.com", "TEST@TEST.COM", "test@test.com", "TEST@TEST.COM", true,
                "AQAAAAEAACcQAAAAEPS6p+sf8f3b1B6foWO9GZzlqsWQ3YLIhfF32rDPPj33ujyH/GtuSW/rGtU4HNnwIg==",
                "d097977e-1cf5-4f8b-97f1-d1078f153b91", "24a2cbc1-3dc3-4234-ba3d-0b7be6681b27", null, false, false, null,
                false, 0
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 10, 24, 21, 16, 15, 622, DateTimeKind.Utc).AddTicks(8791));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 10, 24, 21, 16, 15, 622, DateTimeKind.Utc).AddTicks(8793));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 10, 24, 21, 16, 15, 622, DateTimeKind.Utc).AddTicks(8794));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId"
            );

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId"
            );

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 10, 24, 16, 5, 2, 146, DateTimeKind.Utc).AddTicks(7603));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 10, 24, 16, 5, 2, 146, DateTimeKind.Utc).AddTicks(7604));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 10, 24, 16, 5, 2, 146, DateTimeKind.Utc).AddTicks(7605));
        }
    }
}
