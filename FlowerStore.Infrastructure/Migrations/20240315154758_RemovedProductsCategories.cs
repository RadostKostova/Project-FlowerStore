using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlowerStore.Infrastructure.Migrations
{
    public partial class RemovedProductsCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ca43a7b-4890-487c-b0d0-7359e8d556c6", "AQAAAAEAACcQAAAAEOfftu0PVWuCJUfdDnKAJiHcfgpMHI+qvXu/3rprngpWLtQTCDzPxMpZpdJFSIs/kA==", "40870f56-66de-4681-b911-da0a12dd0750" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "347bdbb6-2e5f-4e9f-bb84-b9fe8acc2bfc", "AQAAAAEAACcQAAAAEEOPZYmkJcggkaxgwFRMt0ebHYLf52LldUKBaaAJx+dCrNsoe+CADW/dBy27xrj4lA==", "35713c42-f147-4b7a-a346-03c03ae1544d" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 3, 15, 15, 47, 58, 161, DateTimeKind.Utc).AddTicks(4564));

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false, comment: "Product identifier"),
                    CategoryId = table.Column<int>(type: "int", nullable: false, comment: "Category identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "adminId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5923bb51-54ef-4e75-8dbf-a0aecb690c06", "AQAAAAEAACcQAAAAEG3RDJ5ru/89Ra51fMjd1kiQLwB1JjN3Zv6yqFfa6HruFr1Y1ldjCpaGivJmxm0+tg==", "3fa52fac-d979-4a09-abf5-42a947d64cd2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "testId",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9919174-19bc-4590-a880-67346b5c2a29", "AQAAAAEAACcQAAAAEFptF09bWuWHYlfyG4k3joNo34Hk/g/Zy1DJWJj0HxKXJX+eWFWx8GW85zoqGeJ2tg==", "10784ac0-86ad-49d2-aae5-3282a854b0ea" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 3, 14, 12, 49, 16, 669, DateTimeKind.Utc).AddTicks(1149));

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");
        }
    }
}
