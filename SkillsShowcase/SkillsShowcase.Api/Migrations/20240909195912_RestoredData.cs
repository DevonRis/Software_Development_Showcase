using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillsShowcase.Api.Migrations
{
    /// <inheritdoc />
    public partial class RestoredData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarPurchaseEventTypes",
                columns: table => new
                {
                    CarPurchaseEventTypeId = table.Column<int>(type: "int", nullable: false),
                    CarPurchaseEventTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarPurchaseEventTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPurchaseEventTypes", x => x.CarPurchaseEventTypeId);
                });

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

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaritalStatus = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

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

            migrationBuilder.CreateTable(
                name: "CarPurchaseInfoLogs",
                columns: table => new
                {
                    CarPurchaseInfoLogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarModel = table.Column<int>(type: "int", nullable: false),
                    CarPurchaseStatus = table.Column<int>(type: "int", nullable: false),
                    CarArrivalInDealership = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarPurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarModelPrice = table.Column<int>(type: "int", nullable: false),
                    CarModelQuantityLeft = table.Column<int>(type: "int", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerCreditStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarPurchaseInfoLogs", x => x.CarPurchaseInfoLogId);
                    table.ForeignKey(
                        name: "FK_CarPurchaseInfoLogs_CarPurchaseEventTypes_CarPurchaseStatus",
                        column: x => x.CarPurchaseStatus,
                        principalTable: "CarPurchaseEventTypes",
                        principalColumn: "CarPurchaseEventTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CarPurchaseEventTypes",
                columns: new[] { "CarPurchaseEventTypeId", "CarPurchaseEventTypeDescription", "CarPurchaseEventTypeName" },
                values: new object[,]
                {
                    { 0, "Car In process of getting bought but not sold yet.", "CarPurchaseInProcess" },
                    { 1, "Credit check in review but approved yet.", "CreditCheckInReview" },
                    { 2, "Credit has been declined. Customer must purchase in cash.", "CreditDeclined" },
                    { 3, "Credit has been accepted. Customer can purchase in credit.", "CreditAccepted" },
                    { 4, "Car has been sold.", "CarsSold" },
                    { 5, "Car cannot be given to customer without full down payment.", "CarsPurchaseHold" },
                    { 6, "Customer bought car but not yet in physical store.", "CarsInRouteForPurchase" }
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

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "Email", "FirstName", "Gender", "LastName", "MaritalStatus", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Devonpaniccia@gmail.com", "Devon", 0, "Rismay", 0, "8322156677" },
                    { 2, "JohnHull@gmail.com", "John", 0, "Hull", 0, "8322156676" },
                    { 3, "QuinshaeHopkins@gmail.com", "Quinshae", 1, "Hopkins", 0, "8322156674" },
                    { 4, "RobertPyron@gmail.com", "Robert", 0, "Pyron", 1, "8322156675" }
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

            migrationBuilder.InsertData(
                table: "SessionLogs",
                columns: new[] { "SessionId", "CreatedTime", "IpAddress", "SessionCountsPerDate", "UserAgent" },
                values: new object[,]
                {
                    { new Guid("321a238a-086d-45d7-a407-1c0695d57bcb"), new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "09.6.0.20", 20, "TechJuice\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("36a64815-7d01-44eb-8d91-130eed5a3c57"), new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "02.6.0.20", 15, "Safari\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("3f40d390-c706-4366-bbb8-337042c6ae3a"), new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "06.6.0.20", 2, "Windows\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("44a03290-fb76-40fb-b3be-b9006e7fa4d3"), new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "07.6.0.20", 6, "Mozilla\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("4fbee5bd-55ba-430f-b899-3d24399e2cf1"), new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "10.6.0.20", 52, "TechJuice\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("59c2a66c-5b45-44b3-99df-6ccbee555505"), new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "04.6.0.20", 23, "EnterExplorer\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("68511be5-5a35-4d68-96f8-4fa5e8ca855f"), new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "05.6.0.20", 43, "Mozilla\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("738c8d6b-4086-4bcc-9db8-deae0bb669c0"), new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "12.6.0.20", 49, "Mozilla\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("77a1b4f3-9fb9-4450-9fe9-8599fb20384a"), new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "11.6.0.20", 10, "Mozilla\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("bb76adc6-d4ef-42c5-9f27-d46e626dbc1d"), new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "03.6.0.20", 30, "FireFox\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("c45c4a22-2b3c-47ed-8390-ad5473295925"), new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "08.6.0.20", 33, "TechJuice\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("dc3e54e7-cd98-4c11-862e-392dbb8e6f0b"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "01.6.0.20", 1, "Mozilla\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" }
                });

            migrationBuilder.InsertData(
                table: "CarPurchaseInfoLogs",
                columns: new[] { "CarPurchaseInfoLogId", "CarArrivalInDealership", "CarModel", "CarModelPrice", "CarModelQuantityLeft", "CarPurchaseDate", "CarPurchaseStatus", "CustomerCreditStatus", "CustomerName" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 60, 40000, 10, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, "Devon Rismay" },
                    { 2, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 350, 123000, 5, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, "John Hull" },
                    { 3, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 300, 92000, 2, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, "Quinshae Hopkins" },
                    { 4, new DateTime(2023, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 400, 65000, 3, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, "Robert Pyron" },
                    { 5, new DateTime(2022, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 80, 236000, 2, new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, "John Goldeen" },
                    { 6, new DateTime(2020, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 200, 101000, 7, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 3, "Crystal Myrondeen" },
                    { 7, new DateTime(2018, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 120, 95000, 9, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 3, "James Mayfield" },
                    { 8, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 100, 80000, 1, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 3, "Chris Mayson" },
                    { 9, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 150, 120000, 5, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, "Barack Husaine" },
                    { 10, new DateTime(2016, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 250, 150000, 1, new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, "Johnson Crayfield" },
                    { 11, new DateTime(2019, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 500, 250000, 1, new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, "Johnson Jones" },
                    { 12, new DateTime(2017, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 600, 300000, 1, new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, "Eugene Paniccia" },
                    { 13, new DateTime(2015, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, 80000, 13, new DateTime(2023, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 1, "Natalie Cyris" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarPurchaseInfoLogs_CarPurchaseStatus",
                table: "CarPurchaseInfoLogs",
                column: "CarPurchaseStatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarPurchaseInfoLogs");

            migrationBuilder.DropTable(
                name: "DcVillains");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "EmployeeSecretKeys");

            migrationBuilder.DropTable(
                name: "Guitars");

            migrationBuilder.DropTable(
                name: "SessionLogs");

            migrationBuilder.DropTable(
                name: "CarPurchaseEventTypes");
        }
    }
}
