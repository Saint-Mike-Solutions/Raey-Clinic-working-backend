using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DentalClinic.Migrations
{
    /// <inheritdoc />
    public partial class LaboratoryRequestAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diff",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    N = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    E = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    B = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    L = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    M = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HemaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diff", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaboratoryRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    RequestedById = table.Column<int>(type: "int", nullable: true),
                    ReportedById = table.Column<int>(type: "int", nullable: true),
                    ReportedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: true),
                    PatientId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaboratoryRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LaboratoryRequests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_LaboratoryRequests_Employees_ReportedById",
                        column: x => x.ReportedById,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LaboratoryRequests_Employees_RequestedById",
                        column: x => x.RequestedById,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LaboratoryRequests_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "PatientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LaboratoryRequests_Patients_PatientId1",
                        column: x => x.PatientId1,
                        principalTable: "Patients",
                        principalColumn: "PatientId");
                });

            migrationBuilder.CreateTable(
                name: "Chemistries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FbsRbs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sgot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sgpt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlkalinePhosphates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BilirubinTotal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BilirubinDirect = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Urea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bun = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creatine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UricAcid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAcid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalProtein = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Triglycerides = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cholesterol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hdl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ldl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaboratoryRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chemistries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chemistries_LaboratoryRequests_LaboratoryRequestId",
                        column: x => x.LaboratoryRequestId,
                        principalTable: "LaboratoryRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hematologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hgb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Esr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Platletes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodGroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodFilm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiffId = table.Column<int>(type: "int", nullable: true),
                    LaboratoryRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hematologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hematologies_Diff_DiffId",
                        column: x => x.DiffId,
                        principalTable: "Diff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hematologies_LaboratoryRequests_LaboratoryRequestId",
                        column: x => x.LaboratoryRequestId,
                        principalTable: "LaboratoryRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Microscopies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EpitCells = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wbc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rbc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    casts = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    crystals = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bacteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hcg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaboratoryRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Microscopies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Microscopies_LaboratoryRequests_LaboratoryRequestId",
                        column: x => x.LaboratoryRequestId,
                        principalTable: "LaboratoryRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Serologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vdlr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WidalH = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeilFelix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HbsAg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HcvAb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HPyloryAg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HPyloryAb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaboratoryRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Serologies_LaboratoryRequests_LaboratoryRequestId",
                        column: x => x.LaboratoryRequestId,
                        principalTable: "LaboratoryRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoolExaminations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Consistency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Concentration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OccultBlood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaboratoryRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoolExaminations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoolExaminations_LaboratoryRequests_LaboratoryRequestId",
                        column: x => x.LaboratoryRequestId,
                        principalTable: "LaboratoryRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Urinalyses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Appearance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ph = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Protein = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Glucose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Leukocyte = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ketone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bilirubin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Urobilingen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Blood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaboratoryRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urinalyses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urinalyses_LaboratoryRequests_LaboratoryRequestId",
                        column: x => x.LaboratoryRequestId,
                        principalTable: "LaboratoryRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AFBs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    One = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Two = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Three = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BacterologyId = table.Column<int>(type: "int", nullable: true),
                    BacterologyId2 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AFBs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bacterologies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sample = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Koh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GramStain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WetFilm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AFBId = table.Column<int>(type: "int", nullable: true),
                    Culture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaboratoryRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bacterologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bacterologies_AFBs_AFBId",
                        column: x => x.AFBId,
                        principalTable: "AFBs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bacterologies_LaboratoryRequests_LaboratoryRequestId",
                        column: x => x.LaboratoryRequestId,
                        principalTable: "LaboratoryRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AFBs_BacterologyId2",
                table: "AFBs",
                column: "BacterologyId2");

            migrationBuilder.CreateIndex(
                name: "IX_Bacterologies_AFBId",
                table: "Bacterologies",
                column: "AFBId",
                unique: true,
                filter: "[AFBId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bacterologies_LaboratoryRequestId",
                table: "Bacterologies",
                column: "LaboratoryRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chemistries_LaboratoryRequestId",
                table: "Chemistries",
                column: "LaboratoryRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Hematologies_DiffId",
                table: "Hematologies",
                column: "DiffId",
                unique: true,
                filter: "[DiffId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Hematologies_LaboratoryRequestId",
                table: "Hematologies",
                column: "LaboratoryRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequests_EmployeeId",
                table: "LaboratoryRequests",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequests_PatientId",
                table: "LaboratoryRequests",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequests_PatientId1",
                table: "LaboratoryRequests",
                column: "PatientId1");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequests_ReportedById",
                table: "LaboratoryRequests",
                column: "ReportedById");

            migrationBuilder.CreateIndex(
                name: "IX_LaboratoryRequests_RequestedById",
                table: "LaboratoryRequests",
                column: "RequestedById");

            migrationBuilder.CreateIndex(
                name: "IX_Microscopies_LaboratoryRequestId",
                table: "Microscopies",
                column: "LaboratoryRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Serologies_LaboratoryRequestId",
                table: "Serologies",
                column: "LaboratoryRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoolExaminations_LaboratoryRequestId",
                table: "StoolExaminations",
                column: "LaboratoryRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Urinalyses_LaboratoryRequestId",
                table: "Urinalyses",
                column: "LaboratoryRequestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AFBs_Bacterologies_BacterologyId2",
                table: "AFBs",
                column: "BacterologyId2",
                principalTable: "Bacterologies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AFBs_Bacterologies_BacterologyId2",
                table: "AFBs");

            migrationBuilder.DropTable(
                name: "Chemistries");

            migrationBuilder.DropTable(
                name: "Hematologies");

            migrationBuilder.DropTable(
                name: "Microscopies");

            migrationBuilder.DropTable(
                name: "Serologies");

            migrationBuilder.DropTable(
                name: "StoolExaminations");

            migrationBuilder.DropTable(
                name: "Urinalyses");

            migrationBuilder.DropTable(
                name: "Diff");

            migrationBuilder.DropTable(
                name: "Bacterologies");

            migrationBuilder.DropTable(
                name: "AFBs");

            migrationBuilder.DropTable(
                name: "LaboratoryRequests");
        }
    }
}
