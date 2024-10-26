using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class MedicalRecordUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "MedicalRecords");

            migrationBuilder.RenameColumn(
                name: "TreatmentDetails",
                table: "MedicalRecords",
                newName: "ReferalList");

            migrationBuilder.RenameColumn(
                name: "PrescribedMedicines",
                table: "MedicalRecords",
                newName: "PrescribedMedicinesandNotes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReferalList",
                table: "MedicalRecords",
                newName: "TreatmentDetails");

            migrationBuilder.RenameColumn(
                name: "PrescribedMedicinesandNotes",
                table: "MedicalRecords",
                newName: "PrescribedMedicines");

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "MedicalRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
