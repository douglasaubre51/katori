using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace katori.Migrations
{
    /// <inheritdoc />
    public partial class createdledgersandsetonetomanywithparticulars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LedgerId",
                table: "Particulars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ledgers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ledgers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Particulars_LedgerId",
                table: "Particulars",
                column: "LedgerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ledgers_Title",
                table: "Ledgers",
                column: "Title",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Particulars_Ledgers_LedgerId",
                table: "Particulars",
                column: "LedgerId",
                principalTable: "Ledgers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Particulars_Ledgers_LedgerId",
                table: "Particulars");

            migrationBuilder.DropTable(
                name: "Ledgers");

            migrationBuilder.DropIndex(
                name: "IX_Particulars_LedgerId",
                table: "Particulars");

            migrationBuilder.DropColumn(
                name: "LedgerId",
                table: "Particulars");
        }
    }
}
