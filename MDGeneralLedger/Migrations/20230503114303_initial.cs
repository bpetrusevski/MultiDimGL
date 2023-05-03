using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MDGeneralLedger.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcctDim",
                columns: table => new
                {
                    SchemaId = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ParentSchemaId = table.Column<string>(type: "varchar(15)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcctDim", x => x.SchemaId);
                    table.ForeignKey(
                        name: "FK_AcctDim_AcctDim_ParentSchemaId",
                        column: x => x.ParentSchemaId,
                        principalTable: "AcctDim",
                        principalColumn: "SchemaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AcctDimValue",
                columns: table => new
                {
                    ID = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SchemaId = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    ParentId = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcctDimValue", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AcctDimValue_AcctDimValue_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AcctDimValue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Account = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<string>(type: "varchar(10)", nullable: true),
                    CurrencyId = table.Column<string>(type: "varchar(10)", nullable: true),
                    OUId = table.Column<string>(type: "varchar(10)", nullable: true),
                    ProductId = table.Column<string>(type: "varchar(10)", nullable: true),
                    ResidencyId = table.Column<string>(type: "varchar(10)", nullable: true),
                    TenureId = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Account);
                    table.ForeignKey(
                        name: "FK_Accounts_AcctDimValue_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AcctDimValue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_AcctDimValue_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "AcctDimValue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_AcctDimValue_OUId",
                        column: x => x.OUId,
                        principalTable: "AcctDimValue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_AcctDimValue_ProductId",
                        column: x => x.ProductId,
                        principalTable: "AcctDimValue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_AcctDimValue_ResidencyId",
                        column: x => x.ResidencyId,
                        principalTable: "AcctDimValue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_AcctDimValue_TenureId",
                        column: x => x.TenureId,
                        principalTable: "AcctDimValue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostingEntry",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GLAccountAccount = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Debit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Credit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FDebit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    FCredit = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    BookingDate = table.Column<DateTime>(type: "Date", nullable: false),
                    CurrencyID = table.Column<string>(type: "varchar(10)", nullable: false),
                    JournalID = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostingEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostingEntry_Accounts_GLAccountAccount",
                        column: x => x.GLAccountAccount,
                        principalTable: "Accounts",
                        principalColumn: "Account",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostingEntry_AcctDimValue_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "AcctDimValue",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CategoryId",
                table: "Accounts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CurrencyId",
                table: "Accounts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_OUId",
                table: "Accounts",
                column: "OUId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ProductId",
                table: "Accounts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ResidencyId",
                table: "Accounts",
                column: "ResidencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_TenureId",
                table: "Accounts",
                column: "TenureId");

            migrationBuilder.CreateIndex(
                name: "IX_AcctDim_ParentSchemaId",
                table: "AcctDim",
                column: "ParentSchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_AcctDimValue_ParentId",
                table: "AcctDimValue",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_PostingEntry_CurrencyID",
                table: "PostingEntry",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_PostingEntry_GLAccountAccount",
                table: "PostingEntry",
                column: "GLAccountAccount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcctDim");

            migrationBuilder.DropTable(
                name: "PostingEntry");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "AcctDimValue");
        }
    }
}
