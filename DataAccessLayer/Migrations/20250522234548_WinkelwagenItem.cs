using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class WinkelwagenItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KlantId",
                table: "WinkelwagenItems");

            migrationBuilder.RenameColumn(
                name: "SessieId",
                table: "WinkelwagenItems",
                newName: "TotaalBedrag");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotaalBedrag",
                table: "WinkelwagenItems",
                newName: "SessieId");

            migrationBuilder.AddColumn<int>(
                name: "KlantId",
                table: "WinkelwagenItems",
                type: "INTEGER",
                nullable: true);
        }
    }
}
