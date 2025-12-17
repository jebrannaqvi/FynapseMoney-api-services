using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moneymanager.Services.TransactionAPI.Migrations
{
    /// <inheritdoc />
    public partial class addBalanceUpdateFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BalanceUpdated",
                table: "AccountTransactions",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalanceUpdated",
                table: "AccountTransactions");
        }
    }
}
