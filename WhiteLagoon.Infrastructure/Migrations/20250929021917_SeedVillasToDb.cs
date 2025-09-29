using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillasToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "CreatedAt", "Description", "ImageUrl", "IsDeleted", "Name", "Occupancy", "Price", "Sqft", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("22f60f72-ac50-471a-bd14-3ceed231858c"), new DateTime(2025, 9, 29, 9, 19, 17, 166, DateTimeKind.Local).AddTicks(9981), "A mornal villa with a no pool and a small garden.", "https://example.com/images/normal-garden-villa.jpg", false, "Normal Pool Villa", 4, 200.0, 250, null },
                    { new Guid("c7e2704c-8505-4e4c-aa2f-7ea1e9b9b823"), new DateTime(2025, 9, 29, 9, 19, 17, 166, DateTimeKind.Local).AddTicks(9973), "A luxurious villa with stunning sea views.", "https://example.com/images/royal-villa.jpg", false, "Royal Villa", 4, 500.0, 550, null },
                    { new Guid("dbc0c36d-5211-4012-a070-33ce40357c4c"), new DateTime(2025, 9, 29, 9, 19, 17, 166, DateTimeKind.Local).AddTicks(9978), "A premium villa with a private pool and garden.", "https://example.com/images/premium-pool-villa.jpg", false, "Premium Pool Villa", 4, 400.0, 500, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("22f60f72-ac50-471a-bd14-3ceed231858c"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("c7e2704c-8505-4e4c-aa2f-7ea1e9b9b823"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("dbc0c36d-5211-4012-a070-33ce40357c4c"));
        }
    }
}
