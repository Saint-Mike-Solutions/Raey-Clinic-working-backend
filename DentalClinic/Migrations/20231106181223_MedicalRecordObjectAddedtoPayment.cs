using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class MedicalRecordObjectAddedtoPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicalRecordMedical_RecordID",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_MedicalRecordMedical_RecordID",
                table: "Payments",
                column: "MedicalRecordMedical_RecordID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_MedicalRecords_MedicalRecordMedical_RecordID",
                table: "Payments",
                column: "MedicalRecordMedical_RecordID",
                principalTable: "MedicalRecords",
                principalColumn: "Medical_RecordID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_MedicalRecords_MedicalRecordMedical_RecordID",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_MedicalRecordMedical_RecordID",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "MedicalRecordMedical_RecordID",
                table: "Payments");
        }
    }
}
