using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Moneymanager.Services.TransactionAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedAccounTransactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AccountTransactions",
                columns: new[] { "TransactionID", "Amount", "BankAccountID", "Category", "CategoryType", "Description", "TransactionDate", "Type" },
                values: new object[,]
                {
                    { 1, 1000.0, 1, "Income", "Income", "Salary Deposit", new DateTime(2025, 12, 5, 19, 51, 48, 877, DateTimeKind.Local).AddTicks(7496), "Credit" },
                    { 2, 100.0, 1, "Groceries", "Variable", "No Frills", new DateTime(2025, 12, 4, 19, 51, 48, 877, DateTimeKind.Local).AddTicks(7574), "Debit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountTransactions",
                keyColumn: "TransactionID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccountTransactions",
                keyColumn: "TransactionID",
                keyValue: 2);
        }
    }
}
