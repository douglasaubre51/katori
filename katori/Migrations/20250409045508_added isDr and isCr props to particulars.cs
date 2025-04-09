using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace katori.Migrations
{
    /// <inheritdoc />
    public partial class addedisDrandisCrpropstoparticulars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCr",
                table: "Particulars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDr",
                table: "Particulars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCr",
                table: "Particulars");

            migrationBuilder.DropColumn(
                name: "IsDr",
                table: "Particulars");
        }
    }
}
