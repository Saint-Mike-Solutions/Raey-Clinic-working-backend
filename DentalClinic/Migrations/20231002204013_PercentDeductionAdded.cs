using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class PercentDeductionAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProcedureQuantity");

            migrationBuilder.AddColumn<int>(
                name: "DiscountPercent",
                table: "MedicalRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "MedicalRecords",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "MedicalRecords");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "MedicalRecords");

            migrationBuilder.CreateTable(
                name: "ProcedureQuantity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicalRecordID = table.Column<int>(type: "int", nullable: false),
                    ProcedureId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureQuantity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProcedureQuantity_MedicalRecords_MedicalRecordID",
                        column: x => x.MedicalRecordID,
                        principalTable: "MedicalRecords",
                        principalColumn: "Medical_RecordID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcedureQuantity_Procedures_ProcedureId",
                        column: x => x.ProcedureId,
                        principalTable: "Procedures",
                        principalColumn: "ProcedureID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureQuantity_MedicalRecordID",
                table: "ProcedureQuantity",
                column: "MedicalRecordID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureQuantity_ProcedureId",
                table: "ProcedureQuantity",
                column: "ProcedureId");
        }
    }
}
