using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class RemovedRequiredValidationsAndOverridePhoneField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Orders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "Phone number");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                comment: "Phone number",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "Last name",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "Last name");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                comment: "First name",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldComment: "First name");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a53e015-990d-4cd0-ae04-2d402060c207",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "d11bf9bd-0e64-46db-9e56-19c592e99b4d", "AQAAAAEAACcQAAAAELxpAbm7EPdbn6xuvkrY2lE0VsAiQKiZz4PuJ8tJs92OotgrkbXLJZvLv29JYcHFYQ==", "1234567700", "69a68a09-706b-4a77-9c05-7af82fa25c9b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a21722de-a984-476a-a7d7-8e48dadde907",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "81a4099a-d91d-47c4-a69f-254955f02d7d", "AQAAAAEAACcQAAAAEDLJYHYwzo9YAe7ACDfJuOr+JeaHQQaRNM3jBiwYgNmWNXZj5EURJB712IbR/JDy/A==", "1234567890", "b281533a-43e1-4378-bd4f-7ce3e23ba057" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5f40bd1-8e34-4354-8996-0f884be97351",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "3f23bdbc-8f5c-4fca-b0f8-e7b7ef7c6085", "AQAAAAEAACcQAAAAEIkBsiSun/ckFAje165ps9HPdDdflwMJ5/BjwL3eaHoMHZKA9RWHe9RWm8m7syGyGA==", "0987654321", "45c46195-ea4e-4a9d-ab50-b15fc486f761" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e50f5dc0-298d-4807-88f0-73b88c82e128",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "075e8f29-8994-4fc1-bbfa-743358055f59", "AQAAAAEAACcQAAAAEI6C35t4pzYm3GtSFkJbMiBEFsGnKhFvxiB9kpVD8EbCDzbzW8ENdLxDaXD7ifpJzQ==", "1234567800", "6de2f3d2-ab3b-4611-8310-d95ea81ac07d" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 12, 4, 13, 15, 2, 168, DateTimeKind.Utc).AddTicks(4758));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 12, 4, 13, 15, 2, 168, DateTimeKind.Utc).AddTicks(4759));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 12, 4, 13, 15, 2, 168, DateTimeKind.Utc).AddTicks(4760));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2024, 12, 4, 13, 15, 2, 168, DateTimeKind.Utc).AddTicks(4760));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2024, 12, 4, 13, 15, 2, 168, DateTimeKind.Utc).AddTicks(4761));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2024, 12, 4, 13, 15, 2, 168, DateTimeKind.Utc).AddTicks(4762));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2024, 12, 4, 13, 15, 2, 168, DateTimeKind.Utc).AddTicks(4762));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2024, 12, 4, 13, 15, 2, 168, DateTimeKind.Utc).AddTicks(4763));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2024, 12, 4, 13, 15, 2, 168, DateTimeKind.Utc).AddTicks(4763));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2024, 12, 4, 13, 15, 2, 168, DateTimeKind.Utc).AddTicks(4764));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2024, 12, 4, 13, 15, 2, 168, DateTimeKind.Utc).AddTicks(4764));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2024, 12, 4, 13, 15, 2, 168, DateTimeKind.Utc).AddTicks(4765));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2024, 12, 4, 13, 15, 2, 168, DateTimeKind.Utc).AddTicks(4765));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2024, 12, 4, 13, 15, 2, 168, DateTimeKind.Utc).AddTicks(4766));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2024, 12, 4, 13, 15, 2, 168, DateTimeKind.Utc).AddTicks(4767));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 4, 15, 15, 2, 153, DateTimeKind.Local).AddTicks(7352));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 4, 15, 15, 2, 153, DateTimeKind.Utc).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 4, 17, 15, 2, 153, DateTimeKind.Utc).AddTicks(7356));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                comment: "Phone");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true,
                oldComment: "Phone number");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Last name",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "Last name");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "First name",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldComment: "First name");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "Phone number");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9a53e015-990d-4cd0-ae04-2d402060c207",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Phone", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "1dbded71-70e9-49ee-800d-96d3e97b2b64", "AQAAAAEAACcQAAAAEH0U+dfySB7x2x7zUnrWyaqGExY0CCsfEpaFO8aIX2vmiVF3TrBzlx+eJG2/NGjxEQ==", "1234567700", null, "61cbac2d-3f7e-4935-b4c2-fec69f970597" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a21722de-a984-476a-a7d7-8e48dadde907",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Phone", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "678afe53-6029-467d-977f-2b04aa685f4d", "AQAAAAEAACcQAAAAEKXW4qSNlIUISXz1BfK0I0vnyHiGlkYx47WCM7Z+knxZEGAzhaaHajWnCO9P5UVB9A==", "1234567890", null, "e32d49c3-8676-40cd-964a-ffdcf52cf7ba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5f40bd1-8e34-4354-8996-0f884be97351",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Phone", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "6ecd919e-9b6c-42fc-8399-251591d9743c", "AQAAAAEAACcQAAAAEMn9RvioMlomPXr3lDCU8xaTMLbKX8I3U+K+6JiXd0xD7m0mAej6IlabDnM470FDsQ==", "0987654321", null, "5b2fffa6-1be3-4494-a32b-951e7ca6e7b2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e50f5dc0-298d-4807-88f0-73b88c82e128",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "Phone", "PhoneNumber", "SecurityStamp" },
                values: new object[] { "5f83f9ec-125c-47b6-8157-f85e0b38695f", "AQAAAAEAACcQAAAAEAwc3YSAxedaKhtuo1GX65GA0LMwFQdIDub/rBWmowA0PuoG+jpbusAxUU1twy7tRQ==", "1234567800", null, "bf07f02b-5bb1-4d07-837e-137d6d8a83de" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2549));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2550));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2551));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2552));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2553));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2554));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2555));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2556));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2557));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2558));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateAdded",
                value: new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2558));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateAdded",
                value: new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2559));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateAdded",
                value: new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2589));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateAdded",
                value: new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2590));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateAdded",
                value: new DateTime(2024, 12, 2, 13, 8, 10, 902, DateTimeKind.Utc).AddTicks(2591));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 2, 15, 8, 10, 887, DateTimeKind.Local).AddTicks(3395));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 2, 15, 8, 10, 887, DateTimeKind.Utc).AddTicks(3401));

            migrationBuilder.UpdateData(
                table: "Reviews",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 12, 2, 17, 8, 10, 887, DateTimeKind.Utc).AddTicks(3402));
        }
    }
}
