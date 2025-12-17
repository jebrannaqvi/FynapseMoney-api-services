using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moneymanager.Services.NetworthAPI.Migrations
{
    /// <inheritdoc />
    public partial class addAccountIDToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "Liabilities",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "Assets",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "Liabilities");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "Assets");
        }
    }
}
