using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PositionKeeping.Migrations
{
    /// <inheritdoc />
    public partial class Vtora : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransactionType",
                table: "PostingEntries");

            migrationBuilder.AddColumn<int>(
                name: "TransactionTypeID",
                table: "PostingEntries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PostingEntries_TransactionTypeID",
                table: "PostingEntries",
                column: "TransactionTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_PostingEntries_ClassificationValue_TransactionTypeID",
                table: "PostingEntries",
                column: "TransactionTypeID",
                principalTable: "ClassificationValue",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostingEntries_ClassificationValue_TransactionTypeID",
                table: "PostingEntries");

            migrationBuilder.DropIndex(
                name: "IX_PostingEntries_TransactionTypeID",
                table: "PostingEntries");

            migrationBuilder.DropColumn(
                name: "TransactionTypeID",
                table: "PostingEntries");

            migrationBuilder.AddColumn<int>(
                name: "TransactionType",
                table: "PostingEntries",
                type: "int",
                maxLength: 10,
                nullable: false,
                defaultValue: 0);
        }
    }
}
