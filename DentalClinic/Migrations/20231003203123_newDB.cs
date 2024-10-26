using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class newDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Referals");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Referals",
                columns: table => new
                {
                    ReferalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalRecordeID = table.Column<int>(type: "int", nullable: false),
                    ReferingDoctor = table.Column<int>(type: "int", nullable: false),
                    ReasonForReferal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferalDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReferedDoctor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Referals", x => x.ReferalID);
                    table.ForeignKey(
                        name: "FK_Referals_Employees_ReferingDoctor",
                        column: x => x.ReferingDoctor,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Referals_MedicalRecords_MedicalRecordeID",
                        column: x => x.MedicalRecordeID,
                        principalTable: "MedicalRecords",
                        principalColumn: "Medical_RecordID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Referals_MedicalRecordeID",
                table: "Referals",
                column: "MedicalRecordeID");

            migrationBuilder.CreateIndex(
                name: "IX_Referals_ReferingDoctor",
                table: "Referals",
                column: "ReferingDoctor");
        }
    }
}
