using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class MedicalRecordRestructingfixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryRequestLists_Patients_PatientId1",
                table: "LaboratoryRequestLists");

            migrationBuilder.DropIndex(
                name: "IX_Payments_PatientID",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecords_PatientId",
                table: "MedicalRecords");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryRequests_PatientId",
                table: "LaboratoryRequests");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryRequestLists_PatientId1",
                table: "LaboratoryRequestLists");

            migrationBuilder.RenameColumn(
                name: "PatientId1",
                table: "LaboratoryRequestLists",
                newName: "MedicalRecoredId");

            migrationBuilder.AddColumn<int>(
                name: "MedicalRecordId",
                table: "LaboratoryRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MedicalRecordMedical_RecordID",
                table: "LaboratoryRequestLists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SatusCounter",
                table: "LaboratoryRequestLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PatientID",
                table: "Payments",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_PatientId",
                table: "MedicalRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequests_MedicalRecordId",
                table: "LaboratoryRequests",
                column: "MedicalRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequests_PatientId",
                table: "LaboratoryRequests",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequestLists_MedicalRecordMedical_RecordID",
                table: "LaboratoryRequestLists",
                column: "MedicalRecordMedical_RecordID");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryRequestLists_MedicalRecords_Id",
                table: "LaboratoryRequestLists",
                column: "Id",
                principalTable: "MedicalRecords",
                principalColumn: "Medical_RecordID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryRequestLists_MedicalRecords_MedicalRecordMedical_RecordID",
                table: "LaboratoryRequestLists",
                column: "MedicalRecordMedical_RecordID",
                principalTable: "MedicalRecords",
                principalColumn: "Medical_RecordID");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryRequests_MedicalRecords_Id",
                table: "LaboratoryRequests",
                column: "Id",
                principalTable: "MedicalRecords",
                principalColumn: "Medical_RecordID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryRequests_MedicalRecords_MedicalRecordId",
                table: "LaboratoryRequests",
                column: "MedicalRecordId",
                principalTable: "MedicalRecords",
                principalColumn: "Medical_RecordID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_MedicalRecords_Id",
                table: "Payments",
                column: "Id",
                principalTable: "MedicalRecords",
                principalColumn: "Medical_RecordID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryRequestLists_MedicalRecords_Id",
                table: "LaboratoryRequestLists");

            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryRequestLists_MedicalRecords_MedicalRecordMedical_RecordID",
                table: "LaboratoryRequestLists");

            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryRequests_MedicalRecords_Id",
                table: "LaboratoryRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryRequests_MedicalRecords_MedicalRecordId",
                table: "LaboratoryRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_MedicalRecords_Id",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_PatientID",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecords_PatientId",
                table: "MedicalRecords");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryRequests_MedicalRecordId",
                table: "LaboratoryRequests");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryRequests_PatientId",
                table: "LaboratoryRequests");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryRequestLists_MedicalRecordMedical_RecordID",
                table: "LaboratoryRequestLists");

            migrationBuilder.DropColumn(
                name: "MedicalRecordId",
                table: "LaboratoryRequests");

            migrationBuilder.DropColumn(
                name: "MedicalRecordMedical_RecordID",
                table: "LaboratoryRequestLists");

            migrationBuilder.DropColumn(
                name: "SatusCounter",
                table: "LaboratoryRequestLists");

            migrationBuilder.RenameColumn(
                name: "MedicalRecoredId",
                table: "LaboratoryRequestLists",
                newName: "PatientId1");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequestLists_PatientId1",
                table: "LaboratoryRequestLists",
                column: "PatientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryRequestLists_Patients_PatientId1",
                table: "LaboratoryRequestLists",
                column: "PatientId1",
                principalTable: "Patients",
                principalColumn: "PatientId");
        }
    }
}
