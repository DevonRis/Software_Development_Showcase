using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillsShowcase.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataGuitars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Guitars",
                columns: table => new
                {
                    GuitarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GuitarManufacturer = table.Column<int>(type: "int", nullable: false),
                    GuitarModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuitarPrice = table.Column<double>(type: "float", nullable: true),
                    BuildYear = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guitars", x => x.GuitarId);
                });

            migrationBuilder.InsertData(
                table: "Guitars",
                columns: new[] { "GuitarId", "BuildYear", "GuitarManufacturer", "GuitarModel", "GuitarPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Custom Shop American Stratocaster", 5000.2299999999996 },
                    { 2, new DateTime(2023, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Custom Shop American Telecaster", 4000.4499999999998 },
                    { 3, new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Special Edition Telecaster FMT HH", 1000.55 },
                    { 4, new DateTime(2024, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Acoustasonic Telecaster", 1998.6300000000001 },
                    { 5, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "ES-339 Figured Semi-hollowbody", 3500.8899999999999 },
                    { 6, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "SG Standard 61 Maestro Vibrola", 2300.23 },
                    { 7, new DateTime(2020, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Silver Sky", 2749.23 },
                    { 8, new DateTime(2000, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Artstar AS2000", 2600.23 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Guitars");
        }
    }
}
