using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class MobileBankingPayment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentID",
                table: "MobileBanking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MobileBanking_PaymentID",
                table: "MobileBanking",
                column: "PaymentID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MobileBanking_Payments_PaymentID",
                table: "MobileBanking",
                column: "PaymentID",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MobileBanking_Payments_PaymentID",
                table: "MobileBanking");

            migrationBuilder.DropIndex(
                name: "IX_MobileBanking_PaymentID",
                table: "MobileBanking");

            migrationBuilder.DropColumn(
                name: "PaymentID",
                table: "MobileBanking");
        }
    }
}
