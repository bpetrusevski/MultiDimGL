using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                name: "GLAccounts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CategoryId = table.Column<string>(type: "varchar(10)", nullable: true),
                    CurrencyId = table.Column<string>(type: "varchar(10)", nullable: true),
                    OUId = table.Column<string>(type: "varchar(10)", nullable: true),
                    ProductId = table.Column<string>(type: "varchar(10)", nullable: true),
                    ResidencyId = table.Column<string>(type: "varchar(10)", nullable: true),
                    TenureId = table.Column<string>(type: "varchar(10)", nullable: true),
                    SubAccountId = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GLAccounts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_GLAccounts_AcctDimValue_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "AcctDimValue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GLAccounts_AcctDimValue_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "AcctDimValue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GLAccounts_AcctDimValue_OUId",
                        column: x => x.OUId,
                        principalTable: "AcctDimValue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GLAccounts_AcctDimValue_ProductId",
                        column: x => x.ProductId,
                        principalTable: "AcctDimValue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GLAccounts_AcctDimValue_ResidencyId",
                        column: x => x.ResidencyId,
                        principalTable: "AcctDimValue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GLAccounts_AcctDimValue_SubAccountId",
                        column: x => x.SubAccountId,
                        principalTable: "AcctDimValue",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GLAccounts_AcctDimValue_TenureId",
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
                    GlAccountID = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_PostingEntry_AcctDimValue_CurrencyID",
                        column: x => x.CurrencyID,
                        principalTable: "AcctDimValue",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_PostingEntry_GLAccounts_GlAccountID",
                        column: x => x.GlAccountID,
                        principalTable: "GLAccounts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AcctDim",
                columns: new[] { "SchemaId", "Name", "ParentSchemaId" },
                values: new object[,]
                {
                    { "Category", "Accounting Categories", null },
                    { "Currency", "Currencies", null },
                    { "OU", "OUs", null },
                    { "Product", "Products", null },
                    { "Residency", "Residencies", null },
                    { "SubAccount", "SubAccounts", null },
                    { "Tenure", "Tenures", null }
                });

            migrationBuilder.InsertData(
                table: "AcctDimValue",
                columns: new[] { "ID", "Name", "ParentId", "SchemaId" },
                values: new object[,]
                {
                    { "756", "CHF", null, "Currency" },
                    { "807", "MKD", null, "Currency" },
                    { "840", "USD", null, "Currency" },
                    { "978", "EUR", null, "Currency" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcctDim_ParentSchemaId",
                table: "AcctDim",
                column: "ParentSchemaId");

            migrationBuilder.CreateIndex(
                name: "IX_AcctDimValue_ParentId",
                table: "AcctDimValue",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_GLAccounts_CategoryId",
                table: "GLAccounts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GLAccounts_CurrencyId",
                table: "GLAccounts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_GLAccounts_OUId",
                table: "GLAccounts",
                column: "OUId");

            migrationBuilder.CreateIndex(
                name: "IX_GLAccounts_ProductId",
                table: "GLAccounts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_GLAccounts_ResidencyId",
                table: "GLAccounts",
                column: "ResidencyId");

            migrationBuilder.CreateIndex(
                name: "IX_GLAccounts_SubAccountId",
                table: "GLAccounts",
                column: "SubAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_GLAccounts_TenureId",
                table: "GLAccounts",
                column: "TenureId");

            migrationBuilder.CreateIndex(
                name: "IX_PostingEntry_CurrencyID",
                table: "PostingEntry",
                column: "CurrencyID");

            migrationBuilder.CreateIndex(
                name: "IX_PostingEntry_GlAccountID",
                table: "PostingEntry",
                column: "GlAccountID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcctDim");

            migrationBuilder.DropTable(
                name: "PostingEntry");

            migrationBuilder.DropTable(
                name: "GLAccounts");

            migrationBuilder.DropTable(
                name: "AcctDimValue");
        }
    }
}
