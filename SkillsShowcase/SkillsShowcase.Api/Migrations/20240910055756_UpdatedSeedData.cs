using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillsShowcase.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("0ee967b6-591e-4aff-83ce-a9ebf0a33de4"));

            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("3d8d9d50-658a-470d-8f23-88a775619c8d"));

            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("5555319c-7df6-490d-8aa2-1edaa0bea797"));

            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("5c66c0d2-73f6-4af7-b5ba-5d3e964a3cfa"));

            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("61e97007-452d-4a0d-a107-cbf3f76fd8e9"));

            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("677a43f3-48a2-4527-9e28-6547ff6f0637"));

            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("684c1fab-5015-4457-b675-dc7d49a9bbf7"));

            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("8291f0fb-a1be-4056-bbae-0034840c1a2e"));

            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("8dd305c9-6ddf-406c-8558-0570597db647"));

            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("913a2029-7c2d-4e68-b9e0-455db4a62284"));

            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("92e289eb-8da5-4554-9d4d-65fbec329e9d"));

            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("9ce37660-95ff-4126-ad98-19e551fcf55a"));

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
                table: "Employees",
                columns: new[] { "EmployeeId", "Email", "FirstName", "Gender", "LastName", "MaritalStatus", "PhoneNumber" },
                values: new object[,]
                {
                    { 2, "JohnHull@gmail.com", "John", 0, "Hull", 0, "8322156676" },
                    { 3, "QuinshaeHopkins@gmail.com", "Quinshae", 1, "Hopkins", 0, "8322156674" },
                    { 4, "RobertPyron@gmail.com", "Robert", 0, "Pyron", 1, "8322156675" }
                });

            migrationBuilder.InsertData(
                table: "SessionLogs",
                columns: new[] { "SessionId", "CreatedTime", "IpAddress", "SessionCountsPerDate", "UserAgent" },
                values: new object[,]
                {
                    { new Guid("067b61fb-3736-40f8-b14f-9c98f548a42c"), new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "02.6.0.20", 15, "Safari\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("3a4af92c-b183-487f-a644-96d03e43f0aa"), new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "06.6.0.20", 2, "Windows\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("4ee48909-9147-419d-8430-d3b79933bb44"), new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "11.6.0.20", 10, "Mozilla\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("4fab71c8-0116-4bda-8d83-18c141283338"), new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "10.6.0.20", 52, "TechJuice\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("54392352-17c8-438b-897a-116fdb2c2fba"), new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "01.6.0.20", 1, "Mozilla\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("603e68ea-e81f-46b0-bcdf-bd2b8424fe17"), new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "07.6.0.20", 6, "Mozilla\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("78b43996-dfe4-4097-bd5b-f34855ebccb2"), new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "04.6.0.20", 23, "EnterExplorer\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("85059052-13ee-4d51-9ae0-4d5c62fe1a40"), new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "03.6.0.20", 30, "FireFox\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("b3487638-0b17-461f-bfdb-da5af929223e"), new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "08.6.0.20", 33, "TechJuice\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("d5237fdc-bd65-49f5-98d4-6e34b65b0b99"), new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "09.6.0.20", 20, "TechJuice\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("f1352ae5-0421-4ff3-ad92-275bfc81e19e"), new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "05.6.0.20", 43, "Mozilla\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" },
                    { new Guid("f796560e-b3ac-4e72-b342-28bebd845042"), new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "12.6.0.20", 49, "Mozilla\\/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit\\/537.36 (KHTML, like Gecko) Chrome\\/127.0.0.0 Safari\\/537.36" }
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
                name: "CarPurchaseEventTypes");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("067b61fb-3736-40f8-b14f-9c98f548a42c"));

            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("3a4af92c-b183-487f-a644-96d03e43f0aa"));

            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("4ee48909-9147-419d-8430-d3b79933bb44"));

            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("4fab71c8-0116-4bda-8d83-18c141283338"));

            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("54392352-17c8-438b-897a-116fdb2c2fba"));

            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("603e68ea-e81f-46b0-bcdf-bd2b8424fe17"));

            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("78b43996-dfe4-4097-bd5b-f34855ebccb2"));

            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("85059052-13ee-4d51-9ae0-4d5c62fe1a40"));

            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("b3487638-0b17-461f-bfdb-da5af929223e"));

            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("d5237fdc-bd65-49f5-98d4-6e34b65b0b99"));

            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("f1352ae5-0421-4ff3-ad92-275bfc81e19e"));

            migrationBuilder.DeleteData(
                table: "SessionLogs",
                keyColumn: "SessionId",
                keyValue: new Guid("f796560e-b3ac-4e72-b342-28bebd845042"));

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
    }
}
