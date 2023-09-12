using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace REST_Practise.Migrations
{
    /// <inheritdoc />
    public partial class initaldf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("0200d49e-05dc-4f5d-a3af-01eda1629be6"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("03b8e584-1938-446a-a149-0fabdadb4f5a"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("d8172a0c-a660-477c-b488-997e21153f4a"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("ee357f8d-d882-4512-a6cf-ff5dbb3b14ff"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("faabd354-f4ea-4f70-bc3b-28ccff7051ca"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("2da55f73-7a4d-4fde-acf9-971a6ca00d6d"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("e310b041-6333-4ef6-bea7-0c4534e2e0df"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("0200d49e-05dc-4f5d-a3af-01eda1629be6"), "Quality Assuarance" },
                    { new Guid("03b8e584-1938-446a-a149-0fabdadb4f5a"), "Support" },
                    { new Guid("d8172a0c-a660-477c-b488-997e21153f4a"), "Managed Services" },
                    { new Guid("ee357f8d-d882-4512-a6cf-ff5dbb3b14ff"), "Engineering" },
                    { new Guid("faabd354-f4ea-4f70-bc3b-28ccff7051ca"), "Human Resource" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2da55f73-7a4d-4fde-acf9-971a6ca00d6d"), "", "admin", "ADMIN" },
                    { new Guid("e310b041-6333-4ef6-bea7-0c4534e2e0df"), "", "user", "USER" }
                });
        }
    }
}
