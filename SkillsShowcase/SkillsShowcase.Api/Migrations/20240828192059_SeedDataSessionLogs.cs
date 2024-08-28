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
            migrationBuilder.DropTable(
                name: "InfoGraphData");

            migrationBuilder.DropTable(
                name: "TestSessionLogs");

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

            migrationBuilder.CreateTable(
                name: "InfoGraphData",
                columns: table => new
                {
                    GraphDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AfricanAmerican_DegreePaths = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfricanAmericans_AverageEducationLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AfricanAmericans_BusinessStart = table.Column<double>(type: "float", nullable: false),
                    AfricanAmericans_BusinessSuccessRate = table.Column<double>(type: "float", nullable: false),
                    African_Americans_AverageIncome = table.Column<int>(type: "int", nullable: false),
                    Asian_Americans_AverageIncome = table.Column<int>(type: "int", nullable: false),
                    Asians_AverageEducationLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Asians_BusinessStart = table.Column<double>(type: "float", nullable: false),
                    Asians_BusinessSuccessRate = table.Column<double>(type: "float", nullable: false),
                    Asians_DegreePaths = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caucasian_Americans_AverageIncome = table.Column<int>(type: "int", nullable: false),
                    Caucasians_AverageEducationLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caucasians_BusinessStart = table.Column<double>(type: "float", nullable: false),
                    Caucasians_BusinessSuccessRate = table.Column<double>(type: "float", nullable: false),
                    Caucasians_DegreePaths = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indian_Americans_AverageIncome = table.Column<int>(type: "int", nullable: false),
                    Indians_AverageEducationLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indians_BusinessStart = table.Column<double>(type: "float", nullable: false),
                    Indians_BusinessSuccessRate = table.Column<double>(type: "float", nullable: false),
                    Indians_DegreePaths = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latino_Americans_AverageIncome = table.Column<int>(type: "int", nullable: false),
                    Latinos_AverageEducationLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latinos_BusinessStart = table.Column<double>(type: "float", nullable: false),
                    Latinos_BusinessSuccessRate = table.Column<double>(type: "float", nullable: false),
                    Latinos_DegreePaths = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NativeAmericans_AverageEducationLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NativeAmericans_BusinessStart = table.Column<double>(type: "float", nullable: false),
                    NativeAmericans_BusinessSuccessRate = table.Column<double>(type: "float", nullable: false),
                    NativeAmericans_DegreePaths = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Native_Americans_AverageIncome = table.Column<int>(type: "int", nullable: false),
                    Nigerian_Americans_AverageIncome = table.Column<int>(type: "int", nullable: false),
                    Nigerians_AverageEducationLevel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nigerians_BusinessStart = table.Column<double>(type: "float", nullable: false),
                    Nigerians_BusinessSuccessRate = table.Column<double>(type: "float", nullable: false),
                    Nigerians_DegreePaths = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoGraphData", x => x.GraphDataId);
                });

            migrationBuilder.CreateTable(
                name: "TestSessionLogs",
                columns: table => new
                {
                    SessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserAgent = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSessionLogs", x => x.SessionId);
                });

            migrationBuilder.InsertData(
                table: "InfoGraphData",
                columns: new[] { "GraphDataId", "AfricanAmerican_DegreePaths", "AfricanAmericans_AverageEducationLevel", "AfricanAmericans_BusinessStart", "AfricanAmericans_BusinessSuccessRate", "African_Americans_AverageIncome", "Asian_Americans_AverageIncome", "Asians_AverageEducationLevel", "Asians_BusinessStart", "Asians_BusinessSuccessRate", "Asians_DegreePaths", "Caucasian_Americans_AverageIncome", "Caucasians_AverageEducationLevel", "Caucasians_BusinessStart", "Caucasians_BusinessSuccessRate", "Caucasians_DegreePaths", "Indian_Americans_AverageIncome", "Indians_AverageEducationLevel", "Indians_BusinessStart", "Indians_BusinessSuccessRate", "Indians_DegreePaths", "Latino_Americans_AverageIncome", "Latinos_AverageEducationLevel", "Latinos_BusinessStart", "Latinos_BusinessSuccessRate", "Latinos_DegreePaths", "NativeAmericans_AverageEducationLevel", "NativeAmericans_BusinessStart", "NativeAmericans_BusinessSuccessRate", "NativeAmericans_DegreePaths", "Native_Americans_AverageIncome", "Nigerian_Americans_AverageIncome", "Nigerians_AverageEducationLevel", "Nigerians_BusinessStart", "Nigerians_BusinessSuccessRate", "Nigerians_DegreePaths" },
                values: new object[] { 1, "Business Administration, Nursing and Health, Criminal Justice and Law Enforcement, Social Work, Education", "High School, Associate Degrees", 0.070000000000000007, 0.41999999999999998, 52860, 106954, "Associate Degrees, Bachelor Degrees, Master Degrees", 0.12, 0.29999999999999999, "Medicine, Engineering, Computer Science and IT, Business Administration, Law", 81000, "Associate Degrees, Bachelor Degrees", 0.69999999999999996, 0.5, "Business Administration, Computer Science, Nursing and Health, Engineering, Psychology", 152141, "Associate Degrees, Bachelor Degrees, Master Degrees, Doctorate Degrees", 0.14000000000000001, 0.45000000000000001, "Medicine, Engineering, Computer Science and IT, Business Administration, Pharmacy", 62800, "High School, Associate Degrees", 0.35999999999999999, 0.47999999999999998, "Business Administration, Health Sciences and Nursing, Computer Science and IT, Engineering, Education", "High School, Associate Degrees", 0.29999999999999999, 0.40000000000000002, "Business, Healthcare, Education, Environmental Science, Social Work", 58082, 70000, "Associate Degrees, Bachelor Degrees, Master Degrees", 0.070000000000000007, 0.5, "Medicine, Engineering, Computer Science and IT, Business Administration, Law" });

            migrationBuilder.InsertData(
                table: "TestSessionLogs",
                columns: new[] { "SessionId", "CreatedTime", "IpAddress", "UserAgent" },
                values: new object[,]
                {
                    { new Guid("4fed01cf-540f-4880-9be3-d419fe2281b3"), new DateTime(2024, 8, 26, 22, 43, 54, 569, DateTimeKind.Local).AddTicks(4258), "08.7.1.50", "Google\\/5.0 (Windows ZT 11.2; Win64; x64) AppleWebKit\\/537.36 (EHTML, like Gecko) Chrome\\/127.0.0.0 explorer\\/537.36" },
                    { new Guid("56d3ef3c-8229-46b1-880c-b0a087df8b53"), new DateTime(2024, 8, 26, 22, 43, 54, 569, DateTimeKind.Local).AddTicks(4147), "04.7.1.50", "Google\\/5.0 (Windows ZT 11.2; Win64; x64) AppleWebKit\\/537.36 (EHTML, like Gecko) Chrome\\/127.0.0.0 explorer\\/537.36" },
                    { new Guid("5cd27c67-32d5-4fd5-95c2-48664953eaf6"), new DateTime(2024, 8, 26, 22, 43, 54, 569, DateTimeKind.Local).AddTicks(4120), "02.7.1.50", "Google\\/5.0 (Windows ZT 11.2; Win64; x64) AppleWebKit\\/537.36 (EHTML, like Gecko) Chrome\\/127.0.0.0 explorer\\/537.36" },
                    { new Guid("5d038a1d-42af-47c6-af10-52253c2e755e"), new DateTime(2024, 8, 26, 22, 43, 54, 569, DateTimeKind.Local).AddTicks(4171), "05.7.1.50", "Google\\/5.0 (Windows ZT 11.2; Win64; x64) AppleWebKit\\/537.36 (EHTML, like Gecko) Chrome\\/127.0.0.0 explorer\\/537.36" },
                    { new Guid("656eadca-8bfb-4f45-bc5b-614973743268"), new DateTime(2024, 8, 26, 22, 43, 54, 569, DateTimeKind.Local).AddTicks(4055), "01.7.1.50", "Google\\/5.0 (Windows ZT 11.2; Win64; x64) AppleWebKit\\/537.36 (EHTML, like Gecko) Chrome\\/127.0.0.0 explorer\\/537.36" },
                    { new Guid("84d18f29-3b49-4f70-b55e-dcb72b2adc80"), new DateTime(2024, 8, 26, 22, 43, 54, 569, DateTimeKind.Local).AddTicks(4287), "10.7.1.50", "Google\\/5.0 (Windows ZT 11.2; Win64; x64) AppleWebKit\\/537.36 (EHTML, like Gecko) Chrome\\/127.0.0.0 explorer\\/537.36" },
                    { new Guid("8b64d713-8dcf-4f80-8da5-f7b1ab697066"), new DateTime(2024, 8, 26, 22, 43, 54, 569, DateTimeKind.Local).AddTicks(4230), "06.7.1.50", "Google\\/5.0 (Windows ZT 11.2; Win64; x64) AppleWebKit\\/537.36 (EHTML, like Gecko) Chrome\\/127.0.0.0 explorer\\/537.36" },
                    { new Guid("952608cb-1759-45fe-a3e4-34cb8d6bcefa"), new DateTime(2024, 8, 26, 22, 43, 54, 569, DateTimeKind.Local).AddTicks(4245), "07.7.1.50", "Google\\/5.0 (Windows ZT 11.2; Win64; x64) AppleWebKit\\/537.36 (EHTML, like Gecko) Chrome\\/127.0.0.0 explorer\\/537.36" },
                    { new Guid("9c870919-b283-4faf-862e-bd82ed5bbd3a"), new DateTime(2024, 8, 26, 22, 43, 54, 569, DateTimeKind.Local).AddTicks(4134), "03.7.1.50", "Google\\/5.0 (Windows ZT 11.2; Win64; x64) AppleWebKit\\/537.36 (EHTML, like Gecko) Chrome\\/127.0.0.0 explorer\\/537.36" },
                    { new Guid("f06f82e6-fe23-4277-a691-d89f39892d9a"), new DateTime(2024, 8, 26, 22, 43, 54, 569, DateTimeKind.Local).AddTicks(4272), "09.7.1.50", "Google\\/5.0 (Windows ZT 11.2; Win64; x64) AppleWebKit\\/537.36 (EHTML, like Gecko) Chrome\\/127.0.0.0 explorer\\/537.36" }
                });
        }
    }
}
