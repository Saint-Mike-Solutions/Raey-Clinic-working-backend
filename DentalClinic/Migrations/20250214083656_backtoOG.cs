using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class backtoOG : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryRequests_MedicalRecords_MedicalRecordMedical_RecordID",
                table: "LaboratoryRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_LaboratoryRequestLists_LaboratoryRequestsListId",
                table: "MedicalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_LaboratoryRequestLists_Medical_RecordID",
                table: "MedicalRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_LaboratoryRequests_Medical_RecordID",
                table: "MedicalRecords");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecords_LaboratoryRequestsListId",
                table: "MedicalRecords");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryRequests_MedicalRecordMedical_RecordID",
                table: "LaboratoryRequests");

            migrationBuilder.DropColumn(
                name: "LaboratoryRequestsListId",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "MedicalRecordMedical_RecordID",
                table: "LaboratoryRequests");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Medical_RecordID",
            //    table: "MedicalRecords",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "LaboratoryRequests",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Id",
            //    table: "LaboratoryRequestLists",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MedicalRecordMedical_RecordID",
                table: "LaboratoryRequestLists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequests_MedicalRecordId",
                table: "LaboratoryRequests",
                column: "MedicalRecordId");

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

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryRequests_MedicalRecordId",
                table: "LaboratoryRequests");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryRequestLists_MedicalRecordMedical_RecordID",
                table: "LaboratoryRequestLists");

            migrationBuilder.DropColumn(
                name: "MedicalRecordMedical_RecordID",
                table: "LaboratoryRequestLists");

            migrationBuilder.AlterColumn<int>(
                name: "Medical_RecordID",
                table: "MedicalRecords",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "LaboratoryRequestsListId",
                table: "MedicalRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "LaboratoryRequests",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MedicalRecordMedical_RecordID",
                table: "LaboratoryRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "LaboratoryRequestLists",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_LaboratoryRequestsListId",
                table: "MedicalRecords",
                column: "LaboratoryRequestsListId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequests_MedicalRecordMedical_RecordID",
                table: "LaboratoryRequests",
                column: "MedicalRecordMedical_RecordID",
                unique: true,
                filter: "[MedicalRecordMedical_RecordID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryRequests_MedicalRecords_MedicalRecordMedical_RecordID",
                table: "LaboratoryRequests",
                column: "MedicalRecordMedical_RecordID",
                principalTable: "MedicalRecords",
                principalColumn: "Medical_RecordID");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_LaboratoryRequestLists_LaboratoryRequestsListId",
                table: "MedicalRecords",
                column: "LaboratoryRequestsListId",
                principalTable: "LaboratoryRequestLists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_LaboratoryRequestLists_Medical_RecordID",
                table: "MedicalRecords",
                column: "Medical_RecordID",
                principalTable: "LaboratoryRequestLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_LaboratoryRequests_Medical_RecordID",
                table: "MedicalRecords",
                column: "Medical_RecordID",
                principalTable: "LaboratoryRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
