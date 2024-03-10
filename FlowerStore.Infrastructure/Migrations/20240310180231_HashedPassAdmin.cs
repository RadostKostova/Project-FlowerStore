using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class HashedPassAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfd0a9da-800b-458a-b96c-dca51a85b3d4", null, "0fd8100b-b3f6-442d-9761-793db18b5ffc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3c7d12c-20fd-4dee-83a4-a969a2441093", "AQAAAAEAACcQAAAAEPf1CmwBdA1S8w295oyEhnpYpP+DN1CuGyJQXMlPSsfvNV4Z/B/1MpPSmhaRaRA0lQ==", "ecfe9a50-3577-430a-9037-a920e0e62171" });
        }
    }
}
