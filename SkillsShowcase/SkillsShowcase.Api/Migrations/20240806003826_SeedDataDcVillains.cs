using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillsShowcase.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataDcVillains : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DcVillains",
                columns: table => new
                {
                    DcVillanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VillanName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillanPower = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillanAge = table.Column<int>(type: "int", nullable: true),
                    Weaknesses = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ThreatLevel = table.Column<int>(type: "int", nullable: true),
                    PlacedInArkham = table.Column<int>(type: "int", nullable: true),
                    SupermanLevelVillan = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DcVillains", x => x.DcVillanId);
                });

            migrationBuilder.InsertData(
                table: "DcVillains",
                columns: new[] { "DcVillanId", "CityLocation", "PlacedInArkham", "SupermanLevelVillan", "ThreatLevel", "VillanAge", "VillanName", "VillanPower", "Weaknesses" },
                values: new object[,]
                {
                    { 1, "Gotham", 0, null, 3, 43, "Joker", "None/Cunning", "None" },
                    { 2, "Apokolips", 2, null, 4, 1000, "Darkseid", "SuperStrength/CosmicPowers", "None/Superman" },
                    { 3, "Metropolis", 0, null, 2, 44, "Lex Luthor", "Genius Intellect", "None/Regular Human/Superman" },
                    { 4, "Gothom", 0, null, 5, 58, "DeathStroke", "Enhanced Human", "None" },
                    { 5, "Gothom", 1, null, 5, 49, "Two-Face", "None", "None" },
                    { 6, "Unknown", 2, null, 4, 1000, "Braniac", "Genius Intellect/Cosmic Powers", "None/Superman" },
                    { 7, "Gothom", 0, null, 5, 37, "Riddler", "None", "None" },
                    { 8, "Space", 0, null, 2, 59, "Sinestro", "Yellow Lantern Ring", "Removal of Ring" },
                    { 9, "Unknown", 2, null, 4, 1000, "Doomsday", "SuperStrength/Invulnerable", "None/Superman" },
                    { 10, "Star City", 0, null, 4, 40, "Professor Zoom", "Reverse Speed Force", "None/Superman" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DcVillains");
        }
    }
}
