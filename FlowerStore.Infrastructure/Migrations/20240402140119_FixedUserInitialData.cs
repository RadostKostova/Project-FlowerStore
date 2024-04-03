using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class FixedUserInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "251bd742-fb00-4deb-bf7d-3696e0d82829", "AQAAAAEAACcQAAAAEMrqvwrHQRPLlvk0xTA6d1kQOGGRXHII2ft7zd3Rb/gQIKyca7EDPMAGgtFiioUnXA==", "0c620519-e713-45a5-b7fc-45bdfd17536b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6b99aed-6136-4d14-83a4-faa2b887ae98", "AQAAAAEAACcQAAAAEI7JxuLq/5dVUXMO50b9VtgfXNHvJeSS80qKIvMWQkyJ7XYm0ZSByNREZ1dDSmGP9A==", "cad4551a-38d8-4b8f-b058-7bf77e3e08fb" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 4, 2, 14, 1, 19, 646, DateTimeKind.Utc).AddTicks(2732));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ddaeb57a-a589-44bf-a134-0b9638f18c93", "AQAAAAEAACcQAAAAEC7PIzyr0A0HredBbQhwRcCQp4Km8aUKE+U97TBiMI7I4eQfYkscmueP6lTmuFoyEA==", "5ac2b31e-07c4-479e-b52a-c9d91c3cf0c4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "723d6794-443d-4865-88eb-ed22aac49dc4", "AQAAAAEAACcQAAAAENOR2SkPimfP9hxcTrQPUInkT8MW5wqS8y74Aq4abIBOxty/5z809Oklo2LhDN2Y6A==", "df74875f-3ab8-4cdd-94a0-965fdb736eb4" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 4, 2, 13, 53, 50, 151, DateTimeKind.Utc).AddTicks(1086));
        }
    }
}
