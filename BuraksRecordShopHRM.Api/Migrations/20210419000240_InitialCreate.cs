using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BuraksRecordShopHRM.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "JobCategories",
                columns: table => new
                {
                    JobCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategories", x => x.JobCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobCategoryId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExitDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_JobCategories_JobCategoryId",
                        column: x => x.JobCategoryId,
                        principalTable: "JobCategories",
                        principalColumn: "JobCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, "Germany" },
                    { 2, "Englane" },
                    { 3, "Turkey" },
                    { 4, "Portugal" },
                    { 5, "Spain" }
                });

            migrationBuilder.InsertData(
                table: "JobCategories",
                columns: new[] { "JobCategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Reseach Lab" },
                    { 2, "Finance" },
                    { 3, "IT" },
                    { 4, "Shop Assistant" },
                    { 5, "Store Staff" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "BirthDate", "CountryId", "Email", "ExitDate", "FirstName", "JobCategoryId", "JoinedDate", "LastName", "Latitude", "Longitude" },
                values: new object[,]
                {
                    { 1, new DateTime(1967, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "junger.clup@buraksrecords.com", null, "Junger", 1, new DateTime(1990, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Klöp", 0.0, 0.0 },
                    { 3, new DateTime(1976, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "burak.selim@buraksrecords.com", null, "Burak", 2, new DateTime(2001, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Selim", 0.0, 0.0 },
                    { 2, new DateTime(1974, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "aleksa.broger@buraksrecords.com", null, "Aleksa", 3, new DateTime(2000, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bröger", 0.0, 0.0 },
                    { 4, new DateTime(1985, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "camelia.veazques@buraksrecords.com", null, "Camelia Oscar De La", 4, new DateTime(2010, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Fuante Garcia Velazques", 0.0, 0.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CountryId",
                table: "Employees",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_JobCategoryId",
                table: "Employees",
                column: "JobCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "JobCategories");
        }
    }
}
