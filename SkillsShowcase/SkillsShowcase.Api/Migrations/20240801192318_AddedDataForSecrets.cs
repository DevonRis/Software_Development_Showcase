using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillsShowcase.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddedDataForSecrets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeSecretKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecretKey = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSecretKeys", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EmployeeSecretKeys",
                columns: new[] { "Id", "EmployeeName", "SecretKey" },
                values: new object[,]
                {
                    { 1, "Devon Rismay", "Auth-234252-rgsdfg4553-234dsdf-5555" },
                    { 2, "John Hull", "Auth-234252-rgsdfg4553-234dsdf-5554" },
                    { 3, "Quinshae Hopkins", "Auth-234252-rgsdfg4553-234dsdf-5553" },
                    { 4, "Robert Pyron", "Auth-234252-rgsdfg4553-234dsdf-5552" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSecretKeys");
        }
    }
}
