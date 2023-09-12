using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace REST_Practise.Migrations
{
    /// <inheritdoc />
    public partial class Initialone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("23488f2d-2518-4e9c-8a8b-d99b5eefbb90"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("614f19d4-ba38-40d1-b6ae-15c8d6085d4b"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("7c085a06-f8f3-4099-83a5-8f243d3708f9"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("b27504b6-22d8-4266-af97-e7b2b4932a50"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("e17018d6-1142-415f-8df3-48acc5fb007a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("1b990256-5476-43e4-a42b-452a607b51f9"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("79cfbd79-997f-4410-b2be-4e5fe0dfbc01"));

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentName" },
                values: new object[,]
                {
                    { new Guid("06655555-b847-4c88-8cfe-180cb27cf096"), "Support" },
                    { new Guid("4c7e4a57-860e-45fd-901c-2f6179357f29"), "Engineering" },
                    { new Guid("830ed997-532e-44cf-ae2e-e9b1971f355b"), "Managed Services" },
                    { new Guid("8c349c27-0972-49cf-9837-b2965530e8c1"), "Human Resource" },
                    { new Guid("a64a7fde-f3d1-4cbb-9092-2b0fb6afd5cd"), "Quality Assuarance" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("3b398796-0276-40c0-8089-69dbd11eb99a"), "", "admin", "ADMIN" },
                    { new Guid("aa185330-c5fe-44c0-9440-092b89185c61"), "", "user", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("06655555-b847-4c88-8cfe-180cb27cf096"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("4c7e4a57-860e-45fd-901c-2f6179357f29"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("830ed997-532e-44cf-ae2e-e9b1971f355b"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("8c349c27-0972-49cf-9837-b2965530e8c1"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("a64a7fde-f3d1-4cbb-9092-2b0fb6afd5cd"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("3b398796-0276-40c0-8089-69dbd11eb99a"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("aa185330-c5fe-44c0-9440-092b89185c61"));

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "DepartmentName" },
                values: new object[,]
                {
                    { new Guid("23488f2d-2518-4e9c-8a8b-d99b5eefbb90"), "Engineering" },
                    { new Guid("614f19d4-ba38-40d1-b6ae-15c8d6085d4b"), "Quality Assuarance" },
                    { new Guid("7c085a06-f8f3-4099-83a5-8f243d3708f9"), "Human Resource" },
                    { new Guid("b27504b6-22d8-4266-af97-e7b2b4932a50"), "Managed Services" },
                    { new Guid("e17018d6-1142-415f-8df3-48acc5fb007a"), "Support" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("1b990256-5476-43e4-a42b-452a607b51f9"), "", "admin", "ADMIN" },
                    { new Guid("79cfbd79-997f-4410-b2be-4e5fe0dfbc01"), "", "user", "USER" }
                });
        }
    }
}
