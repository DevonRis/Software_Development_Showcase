using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillsShowcase.Api.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataSessionLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SessionLogs",
                columns: table => new
                {
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionCountsPerDate = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionLogs", x => x.SessionId);
                });

            migrationBuilder.InsertData(
                table: "SessionLogs",
                columns: new[] { "SessionId", "CreatedTime", "IpAddress", "SessionCountsPerDate", "UserAgent" },
                values: new object[,]
                {
                    { new Guid("0ee967b6-591e-4aff-83ce-a9ebf0a33de4"), new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "06.6.0.20", 2, "Windows\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("3d8d9d50-658a-470d-8f23-88a775619c8d"), new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "12.6.0.20", 49, "Mozilla\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("5555319c-7df6-490d-8aa2-1edaa0bea797"), new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "03.6.0.20", 30, "FireFox\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("5c66c0d2-73f6-4af7-b5ba-5d3e964a3cfa"), new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "02.6.0.20", 15, "Safari\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("61e97007-452d-4a0d-a107-cbf3f76fd8e9"), new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "05.6.0.20", 43, "Mozilla\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("677a43f3-48a2-4527-9e28-6547ff6f0637"), new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "07.6.0.20", 6, "Mozilla\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("684c1fab-5015-4457-b675-dc7d49a9bbf7"), new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "08.6.0.20", 33, "TechJuice\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("8291f0fb-a1be-4056-bbae-0034840c1a2e"), new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "04.6.0.20", 23, "EnterExplorer\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("8dd305c9-6ddf-406c-8558-0570597db647"), new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "11.6.0.20", 10, "Mozilla\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("913a2029-7c2d-4e68-b9e0-455db4a62284"), new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "10.6.0.20", 52, "TechJuice\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("92e289eb-8da5-4554-9d4d-65fbec329e9d"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "01.6.0.20", 1, "Mozilla\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("9ce37660-95ff-4126-ad98-19e551fcf55a"), new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "09.6.0.20", 20, "TechJuice\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessionLogs");
        }
    }
}
