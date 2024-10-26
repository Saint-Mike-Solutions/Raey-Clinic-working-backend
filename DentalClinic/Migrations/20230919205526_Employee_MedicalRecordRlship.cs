using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class Employee_MedicalRecordRlship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TreatedById",
                table: "MedicalRecords",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalRecords_TreatedById",
                table: "MedicalRecords",
                column: "TreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalRecords_Employees_TreatedById",
                table: "MedicalRecords",
                column: "TreatedById",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalRecords_Employees_TreatedById",
                table: "MedicalRecords");

            migrationBuilder.DropIndex(
                name: "IX_MedicalRecords_TreatedById",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "TreatedById",
                table: "MedicalRecords");
        }
    }
}
