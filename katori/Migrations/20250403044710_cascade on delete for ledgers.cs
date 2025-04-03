using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace katori.Migrations
{
    /// <inheritdoc />
    public partial class cascadeondeleteforledgers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Particulars_Ledgers_LedgerId",
                table: "Particulars");

            migrationBuilder.AddForeignKey(
                name: "FK_Particulars_Ledgers_LedgerId",
                table: "Particulars",
                column: "LedgerId",
                principalTable: "Ledgers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Particulars_Ledgers_LedgerId",
                table: "Particulars");

            migrationBuilder.AddForeignKey(
                name: "FK_Particulars_Ledgers_LedgerId",
                table: "Particulars",
                column: "LedgerId",
                principalTable: "Ledgers",
                principalColumn: "Id");
        }
    }
}
