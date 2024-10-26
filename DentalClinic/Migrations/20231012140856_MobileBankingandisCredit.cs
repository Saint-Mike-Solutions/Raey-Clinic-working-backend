using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class MobileBankingandisCredit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_paymentTypes_PaymentTypeID",
                table: "Payments");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentTypeID",
                table: "Payments",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "IsCredit",
                table: "Payments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "MobileBanking",
                columns: table => new
                {
                    MobileBankingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MobileBankingName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileBanking", x => x.MobileBankingID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_paymentTypes_PaymentTypeID",
                table: "Payments",
                column: "PaymentTypeID",
                principalTable: "paymentTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_paymentTypes_PaymentTypeID",
                table: "Payments");

            migrationBuilder.DropTable(
                name: "MobileBanking");

            migrationBuilder.DropColumn(
                name: "IsCredit",
                table: "Payments");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentTypeID",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_paymentTypes_PaymentTypeID",
                table: "Payments",
                column: "PaymentTypeID",
                principalTable: "paymentTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
