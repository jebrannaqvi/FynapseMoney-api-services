using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moneymanager.Services.BudgetAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUserID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Budget",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Budget");
        }
    }
}
