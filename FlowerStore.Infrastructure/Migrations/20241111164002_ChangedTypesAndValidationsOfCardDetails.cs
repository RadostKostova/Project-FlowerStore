using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class ChangedTypesAndValidationsOfCardDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardDetails_AspNetUsers_UserId",
                table: "CardDetails");

            migrationBuilder.DropIndex(
                name: "IX_CardDetails_UserId",
                table: "CardDetails");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CardDetails",
                type: "nvarchar(max)",
                nullable: false,
                comment: "User identifier",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldComment: "User identifier");

            migrationBuilder.AlterColumn<string>(
                name: "ExpirationDate",
                table: "CardDetails",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                comment: "Card's expiration date",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "Card's expiration date");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "CardDetails",
                type: "nvarchar(450)",
                nullable: false,
                comment: "User identifier",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldComment: "User identifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "CardDetails",
                type: "datetime2",
                nullable: false,
                comment: "Card's expiration date",
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldComment: "Card's expiration date");

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
                name: "IX_CardDetails_UserId",
                table: "CardDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CardDetails_AspNetUsers_UserId",
                table: "CardDetails",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
