using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class patientLabrequestupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryRequests_Patients_PatientId",
                table: "LaboratoryRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryRequests_Patients_PatientId1",
                table: "LaboratoryRequests");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryRequests_PatientId",
                table: "LaboratoryRequests");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryRequests_PatientId1",
                table: "LaboratoryRequests");

            migrationBuilder.DropColumn(
                name: "PatientId1",
                table: "LaboratoryRequests");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequests_PatientId",
                table: "LaboratoryRequests",
                column: "PatientId",
                unique: true,
                filter: "[PatientId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryRequests_Patients_PatientId",
                table: "LaboratoryRequests",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryRequests_Patients_PatientId",
                table: "LaboratoryRequests");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryRequests_PatientId",
                table: "LaboratoryRequests");

            migrationBuilder.AddColumn<int>(
                name: "PatientId1",
                table: "LaboratoryRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequests_PatientId",
                table: "LaboratoryRequests",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequests_PatientId1",
                table: "LaboratoryRequests",
                column: "PatientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryRequests_Patients_PatientId",
                table: "LaboratoryRequests",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "PatientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryRequests_Patients_PatientId1",
                table: "LaboratoryRequests",
                column: "PatientId1",
                principalTable: "Patients",
                principalColumn: "PatientId");
        }
    }
}
