using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WhiteLagoon.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Villas",
                columns: table => new
                {
                    VillaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Sqft = table.Column<int>(type: "int", nullable: false),
                    Occupancy = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villas", x => x.VillaId);
                });

            migrationBuilder.CreateTable(
                name: "VillaRooms",
                columns: table => new
                {
                    VillaNo = table.Column<int>(type: "int", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaRooms", x => x.VillaNo);
                    table.ForeignKey(
                        name: "FK_VillaRooms_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "VillaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "VillaId", "CreatedAt", "Description", "ImageUrl", "IsDeleted", "Name", "Occupancy", "Price", "Sqft", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 9, 29, 12, 59, 53, 193, DateTimeKind.Local).AddTicks(1895), "A luxurious villa with stunning sea views.", "https://example.com/images/royal-villa.jpg", false, "Royal Villa", 4, 500.0, 550, null },
                    { 2, new DateTime(2025, 9, 29, 12, 59, 53, 193, DateTimeKind.Local).AddTicks(1898), "A premium villa with a private pool and garden.", "https://example.com/images/premium-pool-villa.jpg", false, "Premium Pool Villa", 4, 400.0, 500, null },
                    { 3, new DateTime(2025, 9, 29, 12, 59, 53, 193, DateTimeKind.Local).AddTicks(1900), "A mornal villa with a no pool and a small garden.", "https://example.com/images/normal-garden-villa.jpg", false, "Normal Pool Villa", 4, 200.0, 250, null }
                });

            migrationBuilder.InsertData(
                table: "VillaRooms",
                columns: new[] { "VillaNo", "CreatedAt", "IsDeleted", "SpecialDetails", "UpdatedAt", "VillaId" },
                values: new object[,]
                {
                    { 101, new DateTime(2025, 9, 29, 12, 59, 53, 193, DateTimeKind.Local).AddTicks(2002), false, null, null, 1 },
                    { 102, new DateTime(2025, 9, 29, 12, 59, 53, 193, DateTimeKind.Local).AddTicks(2005), false, null, null, 1 },
                    { 103, new DateTime(2025, 9, 29, 12, 59, 53, 193, DateTimeKind.Local).AddTicks(2006), false, null, null, 1 },
                    { 104, new DateTime(2025, 9, 29, 12, 59, 53, 193, DateTimeKind.Local).AddTicks(2006), false, null, null, 1 },
                    { 201, new DateTime(2025, 9, 29, 12, 59, 53, 193, DateTimeKind.Local).AddTicks(2007), false, null, null, 2 },
                    { 202, new DateTime(2025, 9, 29, 12, 59, 53, 193, DateTimeKind.Local).AddTicks(2008), false, null, null, 2 },
                    { 203, new DateTime(2025, 9, 29, 12, 59, 53, 193, DateTimeKind.Local).AddTicks(2009), false, null, null, 2 },
                    { 301, new DateTime(2025, 9, 29, 12, 59, 53, 193, DateTimeKind.Local).AddTicks(2010), false, null, null, 3 },
                    { 302, new DateTime(2025, 9, 29, 12, 59, 53, 193, DateTimeKind.Local).AddTicks(2011), false, null, null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VillaRooms_VillaId",
                table: "VillaRooms",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VillaRooms");

            migrationBuilder.DropTable(
                name: "Villas");
        }
    }
}
