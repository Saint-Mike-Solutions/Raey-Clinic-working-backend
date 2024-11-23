using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class LabrequestPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LaboratoryRequestsId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_LaboratoryRequestsId",
                table: "Payments",
                column: "LaboratoryRequestsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_LaboratoryRequests_LaboratoryRequestsId",
                table: "Payments",
                column: "LaboratoryRequestsId",
                principalTable: "LaboratoryRequests",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_LaboratoryRequests_LaboratoryRequestsId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_LaboratoryRequestsId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "LaboratoryRequestsId",
                table: "Payments");
        }
    }
}
