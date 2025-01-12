using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class paymentpatient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payments_PatientID",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "isPaid",
                table: "Payments",
                newName: "IsPaid");

            migrationBuilder.AlterColumn<bool>(
                name: "IsPaid",
                table: "Payments",
                type: "bit",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PatientID",
                table: "Payments",
                column: "PatientID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Payments_PatientID",
                table: "Payments");

            migrationBuilder.RenameColumn(
                name: "IsPaid",
                table: "Payments",
                newName: "isPaid");

            migrationBuilder.AlterColumn<int>(
                name: "isPaid",
                table: "Payments",
                type: "int",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_PatientID",
                table: "Payments",
                column: "PatientID");
        }
    }
}
