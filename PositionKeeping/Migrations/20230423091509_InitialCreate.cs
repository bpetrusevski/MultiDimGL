using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PositionKeeping.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountingUnitTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingUnitTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassificationSchemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Code = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificationSchemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassificationValue",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Schema = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassificationValue", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChartOfAccounts",
                columns: table => new
                {
                    AccountNumber = table.Column<string>(type: "VARCHAR(15)", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AL = table.Column<short>(type: "smallint", nullable: false),
                    AccountingCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartOfAccounts", x => x.AccountNumber);
                    table.ForeignKey(
                        name: "FK_ChartOfAccounts_ClassificationValue_AccountingCategoryID",
                        column: x => x.AccountingCategoryID,
                        principalTable: "ClassificationValue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountUnits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    Currency = table.Column<string>(type: "VARCHAR(3)", maxLength: 3, nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    AccruedInterest = table.Column<decimal>(type: "decimal(18,4)", precision: 18, scale: 4, nullable: false),
                    GLAccountNumber = table.Column<string>(type: "VARCHAR(15)", nullable: false),
                    OUID = table.Column<int>(type: "int", nullable: false),
                    MaturitySegmentID = table.Column<int>(type: "int", nullable: false),
                    CustomerTypeID = table.Column<int>(type: "int", nullable: false),
                    ProductFamilyID = table.Column<int>(type: "int", nullable: false),
                    AccountUnitId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountUnits_AccountUnits_AccountUnitId",
                        column: x => x.AccountUnitId,
                        principalTable: "AccountUnits",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AccountUnits_AccountingUnitTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "AccountingUnitTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountUnits_ChartOfAccounts_GLAccountNumber",
                        column: x => x.GLAccountNumber,
                        principalTable: "ChartOfAccounts",
                        principalColumn: "AccountNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountUnits_ClassificationValue_CustomerTypeID",
                        column: x => x.CustomerTypeID,
                        principalTable: "ClassificationValue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountUnits_ClassificationValue_MaturitySegmentID",
                        column: x => x.MaturitySegmentID,
                        principalTable: "ClassificationValue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountUnits_ClassificationValue_OUID",
                        column: x => x.OUID,
                        principalTable: "ClassificationValue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccountUnits_ClassificationValue_ProductFamilyID",
                        column: x => x.ProductFamilyID,
                        principalTable: "ClassificationValue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostingEntries",
                columns: table => new
                {
                    PostingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountUnitId = table.Column<long>(type: "bigint", nullable: false),
                    DC = table.Column<short>(type: "smallint", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    TransactionType = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ValueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    InstructionRef = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostingEntries", x => x.PostingId);
                    table.ForeignKey(
                        name: "FK_PostingEntries_AccountUnits_AccountUnitId",
                        column: x => x.AccountUnitId,
                        principalTable: "AccountUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountUnits_AccountUnitId",
                table: "AccountUnits",
                column: "AccountUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountUnits_CustomerTypeID",
                table: "AccountUnits",
                column: "CustomerTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountUnits_GLAccountNumber",
                table: "AccountUnits",
                column: "GLAccountNumber");

            migrationBuilder.CreateIndex(
                name: "IX_AccountUnits_MaturitySegmentID",
                table: "AccountUnits",
                column: "MaturitySegmentID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountUnits_OUID",
                table: "AccountUnits",
                column: "OUID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountUnits_ProductFamilyID",
                table: "AccountUnits",
                column: "ProductFamilyID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountUnits_TypeId",
                table: "AccountUnits",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChartOfAccounts_AccountingCategoryID",
                table: "ChartOfAccounts",
                column: "AccountingCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PostingEntries_AccountUnitId",
                table: "PostingEntries",
                column: "AccountUnitId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassificationSchemas");

            migrationBuilder.DropTable(
                name: "PostingEntries");

            migrationBuilder.DropTable(
                name: "AccountUnits");

            migrationBuilder.DropTable(
                name: "AccountingUnitTypes");

            migrationBuilder.DropTable(
                name: "ChartOfAccounts");

            migrationBuilder.DropTable(
                name: "ClassificationValue");
        }
    }
}
