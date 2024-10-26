using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class LaboratoryRequestListAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LaboratoryRequestLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Hematology = table.Column<bool>(type: "bit", nullable: false),
                    Chemistry = table.Column<bool>(type: "bit", nullable: false),
                    Serology = table.Column<bool>(type: "bit", nullable: false),
                    Urinalysis = table.Column<bool>(type: "bit", nullable: false),
                    Bacterology = table.Column<bool>(type: "bit", nullable: false),
                    Microscopy = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId1 = table.Column<int>(type: "int", nullable: true),
                    PatientId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryRequestLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaboratoryRequestLists_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_LaboratoryRequestLists_Employees_EmployeeId1",
                        column: x => x.EmployeeId1,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_LaboratoryRequestLists_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                    table.ForeignKey(
                        name: "FK_LaboratoryRequestLists_Patients_PatientId1",
                        column: x => x.PatientId1,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequestLists_EmployeeId",
                table: "LaboratoryRequestLists",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequestLists_EmployeeId1",
                table: "LaboratoryRequestLists",
                column: "EmployeeId1");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequestLists_PatientId",
                table: "LaboratoryRequestLists",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequestLists_PatientId1",
                table: "LaboratoryRequestLists",
                column: "PatientId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LaboratoryRequestLists");
        }
    }
}
