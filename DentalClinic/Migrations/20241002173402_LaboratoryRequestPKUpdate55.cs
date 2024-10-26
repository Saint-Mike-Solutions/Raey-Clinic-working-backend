using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class LaboratoryRequestPKUpdate55 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AFBs_Bacterologies_BacterologyId2",
                table: "AFBs");

            migrationBuilder.DropForeignKey(
                name: "FK_Bacterologies_LaboratoryRequests_LaboratoryRequestId",
                table: "Bacterologies");

            migrationBuilder.DropForeignKey(
                name: "FK_Chemistries_LaboratoryRequests_LaboratoryRequestId",
                table: "Chemistries");

            migrationBuilder.DropForeignKey(
                name: "FK_Hematologies_LaboratoryRequests_LaboratoryRequestId",
                table: "Hematologies");

            migrationBuilder.DropForeignKey(
                name: "FK_Serologies_LaboratoryRequests_LaboratoryRequestId",
                table: "Serologies");

            migrationBuilder.DropForeignKey(
                name: "FK_StoolExaminations_LaboratoryRequests_LaboratoryRequestId",
                table: "StoolExaminations");

            migrationBuilder.DropForeignKey(
                name: "FK_Urinalyses_LaboratoryRequests_LaboratoryRequestId",
                table: "Urinalyses");

            migrationBuilder.DropIndex(
                name: "IX_Urinalyses_LaboratoryRequestId",
                table: "Urinalyses");

            migrationBuilder.DropIndex(
                name: "IX_StoolExaminations_LaboratoryRequestId",
                table: "StoolExaminations");

            migrationBuilder.DropIndex(
                name: "IX_Serologies_LaboratoryRequestId",
                table: "Serologies");

            migrationBuilder.DropIndex(
                name: "IX_Hematologies_LaboratoryRequestId",
                table: "Hematologies");

            migrationBuilder.DropIndex(
                name: "IX_Chemistries_LaboratoryRequestId",
                table: "Chemistries");

            migrationBuilder.DropIndex(
                name: "IX_Bacterologies_LaboratoryRequestId",
                table: "Bacterologies");

            migrationBuilder.DropIndex(
                name: "IX_AFBs_BacterologyId2",
                table: "AFBs");

            migrationBuilder.DropColumn(
                name: "LaboratoryRequestId",
                table: "Urinalyses");

            migrationBuilder.DropColumn(
                name: "LaboratoryRequestId",
                table: "StoolExaminations");

            migrationBuilder.DropColumn(
                name: "LaboratoryRequestId",
                table: "Serologies");

            migrationBuilder.DropColumn(
                name: "LaboratoryRequestId",
                table: "Hematologies");

            migrationBuilder.DropColumn(
                name: "HemaId",
                table: "Diff");

            migrationBuilder.DropColumn(
                name: "LaboratoryRequestId",
                table: "Chemistries");

            migrationBuilder.DropColumn(
                name: "LaboratoryRequestId",
                table: "Bacterologies");

            migrationBuilder.DropColumn(
                name: "BacterologyId",
                table: "AFBs");

            migrationBuilder.DropColumn(
                name: "BacterologyId2",
                table: "AFBs");

            migrationBuilder.AddColumn<int>(
                name: "BacterologyId",
                table: "LaboratoryRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChemistryId",
                table: "LaboratoryRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HematologyId",
                table: "LaboratoryRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SerologyId",
                table: "LaboratoryRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StoolExaminationId",
                table: "LaboratoryRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UrinalysisId",
                table: "LaboratoryRequests",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequests_BacterologyId",
                table: "LaboratoryRequests",
                column: "BacterologyId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequests_ChemistryId",
                table: "LaboratoryRequests",
                column: "ChemistryId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequests_HematologyId",
                table: "LaboratoryRequests",
                column: "HematologyId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequests_SerologyId",
                table: "LaboratoryRequests",
                column: "SerologyId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequests_StoolExaminationId",
                table: "LaboratoryRequests",
                column: "StoolExaminationId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequests_UrinalysisId",
                table: "LaboratoryRequests",
                column: "UrinalysisId");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryRequests_Bacterologies_BacterologyId",
                table: "LaboratoryRequests",
                column: "BacterologyId",
                principalTable: "Bacterologies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryRequests_Chemistries_ChemistryId",
                table: "LaboratoryRequests",
                column: "ChemistryId",
                principalTable: "Chemistries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryRequests_Hematologies_HematologyId",
                table: "LaboratoryRequests",
                column: "HematologyId",
                principalTable: "Hematologies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryRequests_Serologies_SerologyId",
                table: "LaboratoryRequests",
                column: "SerologyId",
                principalTable: "Serologies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryRequests_StoolExaminations_StoolExaminationId",
                table: "LaboratoryRequests",
                column: "StoolExaminationId",
                principalTable: "StoolExaminations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LaboratoryRequests_Urinalyses_UrinalysisId",
                table: "LaboratoryRequests",
                column: "UrinalysisId",
                principalTable: "Urinalyses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryRequests_Bacterologies_BacterologyId",
                table: "LaboratoryRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryRequests_Chemistries_ChemistryId",
                table: "LaboratoryRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryRequests_Hematologies_HematologyId",
                table: "LaboratoryRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryRequests_Serologies_SerologyId",
                table: "LaboratoryRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryRequests_StoolExaminations_StoolExaminationId",
                table: "LaboratoryRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_LaboratoryRequests_Urinalyses_UrinalysisId",
                table: "LaboratoryRequests");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryRequests_BacterologyId",
                table: "LaboratoryRequests");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryRequests_ChemistryId",
                table: "LaboratoryRequests");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryRequests_HematologyId",
                table: "LaboratoryRequests");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryRequests_SerologyId",
                table: "LaboratoryRequests");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryRequests_StoolExaminationId",
                table: "LaboratoryRequests");

            migrationBuilder.DropIndex(
                name: "IX_LaboratoryRequests_UrinalysisId",
                table: "LaboratoryRequests");

            migrationBuilder.DropColumn(
                name: "BacterologyId",
                table: "LaboratoryRequests");

            migrationBuilder.DropColumn(
                name: "ChemistryId",
                table: "LaboratoryRequests");

            migrationBuilder.DropColumn(
                name: "HematologyId",
                table: "LaboratoryRequests");

            migrationBuilder.DropColumn(
                name: "SerologyId",
                table: "LaboratoryRequests");

            migrationBuilder.DropColumn(
                name: "StoolExaminationId",
                table: "LaboratoryRequests");

            migrationBuilder.DropColumn(
                name: "UrinalysisId",
                table: "LaboratoryRequests");

            migrationBuilder.AddColumn<int>(
                name: "LaboratoryRequestId",
                table: "Urinalyses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LaboratoryRequestId",
                table: "StoolExaminations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LaboratoryRequestId",
                table: "Serologies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LaboratoryRequestId",
                table: "Hematologies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HemaId",
                table: "Diff",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LaboratoryRequestId",
                table: "Chemistries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LaboratoryRequestId",
                table: "Bacterologies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BacterologyId",
                table: "AFBs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BacterologyId2",
                table: "AFBs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Urinalyses_LaboratoryRequestId",
                table: "Urinalyses",
                column: "LaboratoryRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoolExaminations_LaboratoryRequestId",
                table: "StoolExaminations",
                column: "LaboratoryRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Serologies_LaboratoryRequestId",
                table: "Serologies",
                column: "LaboratoryRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hematologies_LaboratoryRequestId",
                table: "Hematologies",
                column: "LaboratoryRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chemistries_LaboratoryRequestId",
                table: "Chemistries",
                column: "LaboratoryRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bacterologies_LaboratoryRequestId",
                table: "Bacterologies",
                column: "LaboratoryRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AFBs_BacterologyId2",
                table: "AFBs",
                column: "BacterologyId2");

            migrationBuilder.AddForeignKey(
                name: "FK_AFBs_Bacterologies_BacterologyId2",
                table: "AFBs",
                column: "BacterologyId2",
                principalTable: "Bacterologies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bacterologies_LaboratoryRequests_LaboratoryRequestId",
                table: "Bacterologies",
                column: "LaboratoryRequestId",
                principalTable: "LaboratoryRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chemistries_LaboratoryRequests_LaboratoryRequestId",
                table: "Chemistries",
                column: "LaboratoryRequestId",
                principalTable: "LaboratoryRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hematologies_LaboratoryRequests_LaboratoryRequestId",
                table: "Hematologies",
                column: "LaboratoryRequestId",
                principalTable: "LaboratoryRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Serologies_LaboratoryRequests_LaboratoryRequestId",
                table: "Serologies",
                column: "LaboratoryRequestId",
                principalTable: "LaboratoryRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StoolExaminations_LaboratoryRequests_LaboratoryRequestId",
                table: "StoolExaminations",
                column: "LaboratoryRequestId",
                principalTable: "LaboratoryRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Urinalyses_LaboratoryRequests_LaboratoryRequestId",
                table: "Urinalyses",
                column: "LaboratoryRequestId",
                principalTable: "LaboratoryRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
