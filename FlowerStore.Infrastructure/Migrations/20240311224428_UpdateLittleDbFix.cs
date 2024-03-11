using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class UpdateLittleDbFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
