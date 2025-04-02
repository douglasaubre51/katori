using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace katori.Migrations
{
    /// <inheritdoc />
    public partial class updatedjournalsandledgers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JournalId",
                table: "Particulars",
                newName: "LedgerType");

            migrationBuilder.AddColumn<int>(
                name: "LedgerType",
                table: "Ledgers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalCredit",
                table: "Ledgers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalDebit",
                table: "Ledgers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LedgerType",
                table: "Ledgers");

            migrationBuilder.DropColumn(
                name: "TotalCredit",
                table: "Ledgers");

            migrationBuilder.DropColumn(
                name: "TotalDebit",
                table: "Ledgers");

            migrationBuilder.RenameColumn(
                name: "LedgerType",
                table: "Particulars",
                newName: "JournalId");
        }
    }
}
