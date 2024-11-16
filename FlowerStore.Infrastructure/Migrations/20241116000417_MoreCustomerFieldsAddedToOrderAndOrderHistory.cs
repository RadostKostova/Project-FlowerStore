using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class MoreCustomerFieldsAddedToOrderAndOrderHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Email");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Orders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "First name");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Orders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "Last name");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Phone");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "OrderHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Email");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "OrderHistories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "First name");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "OrderHistories",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                comment: "Last name");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "OrderHistories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Phone");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "987d9084-b9ce-45a9-91a4-7d2ddfe364de", "AQAAAAEAACcQAAAAEAc68ImKdKwyT2eJFg99Q2R7lCjC4q7Jitb4B7Nhmeo6qXrHQL6r4NA+DKcDpxvAbg==", "ead1d47d-28e2-4db6-b266-e23f7b20dd39" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3a246082-3a6a-4eab-9d2a-1233baf22a37", "AQAAAAEAACcQAAAAEGWs3YTUZM9n6DIrlLzVm2o+CKakhyF3GYO/0qRmaY6kAuGK0cFugwtzYd16Dw1ufA==", "6f2d3b17-c792-4b5b-9d38-1118bf632515" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 11, 16, 0, 4, 17, 253, DateTimeKind.Utc).AddTicks(3422));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 11, 16, 0, 4, 17, 253, DateTimeKind.Utc).AddTicks(3423));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 11, 16, 0, 4, 17, 253, DateTimeKind.Utc).AddTicks(3424));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "OrderHistories");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "OrderHistories");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "OrderHistories");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "OrderHistories");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0ab6246d-d39f-44c6-a40f-1a309d2e0bfe", "AQAAAAEAACcQAAAAEEqk9B2IG8sW8tLE2+66cJXB+EcAQ40aiG1gWUVf0s8Un92K4urqvGGlZm0r7tntYQ==", "a07616e1-0449-473c-b65d-b4d4c58409f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bd3a52b9-03cf-417a-9dbd-2254276f2f00", "AQAAAAEAACcQAAAAENzIj85fpShTwswFtCb8XFLYXrQRHGBVDcVcRmd0D+80GrxOEaZU4fjqP+3mdrkufQ==", "ce890026-4c2e-4065-979f-7b506bdd3adc" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 11, 11, 16, 40, 2, 451, DateTimeKind.Utc).AddTicks(8853));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 11, 11, 16, 40, 2, 451, DateTimeKind.Utc).AddTicks(8854));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 11, 11, 16, 40, 2, 451, DateTimeKind.Utc).AddTicks(8854));
        }
    }
}
