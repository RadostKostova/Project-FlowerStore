using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class ExtendUserAndRemoveAdminTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "First name");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                comment: "Last name");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "",
                comment: "Phone number");

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "user:fullname", "Admin Admin", "adminId" },
                    { 2, "user:fullname", "Test Test", "testId" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "Phone", "SecurityStamp" },
                values: new object[] { "692a3c61-974c-4097-98f1-e03a18e287df", "Admin", "Admin", "AQAAAAEAACcQAAAAEMuDlkyL742Ss2hz2BIutfOaEOJwHHRvteTpFvN2sjNTKimIfvhmx5p+TvJwrPZtFA==", "1234567890", "ff81be86-9824-40a2-a51c-b4ecfaaf0402" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash", "Phone", "SecurityStamp" },
                values: new object[] { "9f442b0e-cb4d-49b3-907f-281a0b06bde4", "Test", "Test", "AQAAAAEAACcQAAAAELvqSzRZebLYccFnUU6APW2UsJc2qXVR6Htfhknjvz+96E9MQy/jqrnFBLTDwS3U7w==", "1234567800", "bd383a3d-2412-44b4-8840-6f16a5299d45" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUserClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Administrator's Identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "User's Identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administrators_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "Id", "UserId" },
                values: new object[] { 1, "adminId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "718f312a-e77f-417c-b213-02f5028a6f02", "AQAAAAEAACcQAAAAEKl2zNyA/7jhU6G8056WlFycO1vhfWFPyNkYtktNDngRS5Ue+OzkIKivzdDyXHGYLQ==", "acfcd913-4ffb-45e7-a476-52c8a7879212" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e712da41-c833-49c9-ae75-9d03c6b5f572", "AQAAAAEAACcQAAAAEInP2ZKyvXmSZpNo8R0gBeg198rKtmmRxAT67r8E0fY+MI/MyhuMrKY8TsLfDTBb5g==", "537ad807-190d-4649-aecb-984f997a015c" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 11, 3, 12, 40, 46, 196, DateTimeKind.Utc).AddTicks(3497));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 11, 3, 12, 40, 46, 196, DateTimeKind.Utc).AddTicks(3498));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 11, 3, 12, 40, 46, 196, DateTimeKind.Utc).AddTicks(3499));

            migrationBuilder.CreateIndex(
                name: "IX_Administrators_UserId",
                table: "Administrators",
                column: "UserId");
        }
    }
}
