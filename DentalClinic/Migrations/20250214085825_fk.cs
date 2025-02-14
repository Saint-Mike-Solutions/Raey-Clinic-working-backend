using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class fk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryRequestLists_MedicalRecords_Id",
                table: "LaboratoryRequestLists");

            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryRequests_MedicalRecords_Id",
                table: "LaboratoryRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryRequests_MedicalRecords_MedicalRecordId",
                table: "LaboratoryRequests");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryRequests_MedicalRecordId",
                table: "LaboratoryRequests");

            // Remove AlterColumn operations
            // migrationBuilder.AlterColumn<int>(
            //     name: "Id",
            //     table: "LaboratoryRequests",
            //     type: "int",
            //     nullable: false,
            //     oldClrType: typeof(int),
            //     oldType: "int")
            //     .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MedicalRecordMedical_RecordID",
                table: "LaboratoryRequests",
                type: "int",
                nullable: true);

            // Remove AlterColumn operation for LaboratoryRequestLists
            // migrationBuilder.AlterColumn<int>(
            //     name: "Id",
            //     table: "LaboratoryRequestLists",
            //     type: "int",
            //     nullable: false,
            //     oldClrType: typeof(int),
            //     oldType: "int")
            //     .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequests_MedicalRecordId",
                table: "LaboratoryRequests",
                column: "MedicalRecordId",
                unique: true,
                filter: "[MedicalRecordId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequests_MedicalRecordMedical_RecordID",
                table: "LaboratoryRequests",
                column: "MedicalRecordMedical_RecordID");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequestLists_MedicalRecoredId",
                table: "LaboratoryRequestLists",
                column: "MedicalRecoredId",
                unique: true,
                filter: "[MedicalRecoredId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryRequestLists_MedicalRecords_MedicalRecoredId",
                table: "LaboratoryRequestLists",
                column: "MedicalRecoredId",
                principalTable: "MedicalRecords",
                principalColumn: "Medical_RecordID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryRequests_MedicalRecords_MedicalRecordId",
                table: "LaboratoryRequests",
                column: "MedicalRecordId",
                principalTable: "MedicalRecords",
                principalColumn: "Medical_RecordID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryRequests_MedicalRecords_MedicalRecordMedical_RecordID",
                table: "LaboratoryRequests",
                column: "MedicalRecordMedical_RecordID",
                principalTable: "MedicalRecords",
                principalColumn: "Medical_RecordID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryRequestLists_MedicalRecords_MedicalRecoredId",
                table: "LaboratoryRequestLists");

            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryRequests_MedicalRecords_MedicalRecordId",
                table: "LaboratoryRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryRequests_MedicalRecords_MedicalRecordMedical_RecordID",
                table: "LaboratoryRequests");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryRequests_MedicalRecordId",
                table: "LaboratoryRequests");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryRequests_MedicalRecordMedical_RecordID",
                table: "LaboratoryRequests");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryRequestLists_MedicalRecoredId",
                table: "LaboratoryRequestLists");

            migrationBuilder.DropColumn(
                name: "MedicalRecordMedical_RecordID",
                table: "LaboratoryRequests");

            // Remove AlterColumn operations in Down migration as well
            // migrationBuilder.AlterColumn<int>(
            //     name: "Id",
            //     table: "LaboratoryRequests",
            //     type: "int",
            //     nullable: false,
            //     oldClrType: typeof(int),
            //     oldType: "int")
            //     .OldAnnotation("SqlServer:Identity", "1, 1");

            // migrationBuilder.AlterColumn<int>(
            //     name: "Id",
            //     table: "LaboratoryRequestLists",
            //     type: "int",
            //     nullable: false,
            //     oldClrType: typeof(int),
            //     oldType: "int")
            //     .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequests_MedicalRecordId",
                table: "LaboratoryRequests",
                column: "MedicalRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryRequestLists_MedicalRecords_Id",
                table: "LaboratoryRequestLists",
                column: "Id",
                principalTable: "MedicalRecords",
                principalColumn: "Medical_RecordID",
                onDelete: ReferentialAction.Restrict);

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
        }
    }
}
