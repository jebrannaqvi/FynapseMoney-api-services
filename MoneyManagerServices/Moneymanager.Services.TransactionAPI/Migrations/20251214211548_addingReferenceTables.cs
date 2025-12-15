using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Moneymanager.Services.TransactionAPI.Migrations
{
    /// <inheritdoc />
    public partial class addingReferenceTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AccountTransactions",
                keyColumn: "TransactionID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AccountTransactions",
                keyColumn: "TransactionID",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Category",
                table: "AccountTransactions");

            migrationBuilder.DropColumn(
                name: "CategoryType",
                table: "AccountTransactions");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "AccountTransactions");

            migrationBuilder.AddColumn<int>(
                name: "SubcategoryID",
                table: "AccountTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TransactionTypeID",
                table: "AccountTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "CategoryTypes",
                columns: table => new
                {
                    CategoryTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryTypes", x => x.CategoryTypeID);
                });

            migrationBuilder.CreateTable(
                name: "TransacationTypes",
                columns: table => new
                {
                    TransactionTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransacationTypes", x => x.TransactionTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Subcategories",
                columns: table => new
                {
                    SubcategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubcategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CategoryTypeId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategories", x => x.SubcategoryID);
                    table.ForeignKey(
                        name: "FK_Subcategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subcategories_CategoryTypes_CategoryTypeId",
                        column: x => x.CategoryTypeId,
                        principalTable: "CategoryTypes",
                        principalColumn: "CategoryTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransactions_SubcategoryID",
                table: "AccountTransactions",
                column: "SubcategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransactions_TransactionTypeID",
                table: "AccountTransactions",
                column: "TransactionTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_CategoryId",
                table: "Subcategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Subcategories_CategoryTypeId",
                table: "Subcategories",
                column: "CategoryTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransactions_Subcategories_SubcategoryID",
                table: "AccountTransactions",
                column: "SubcategoryID",
                principalTable: "Subcategories",
                principalColumn: "SubcategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTransactions_TransacationTypes_TransactionTypeID",
                table: "AccountTransactions",
                column: "TransactionTypeID",
                principalTable: "TransacationTypes",
                principalColumn: "TransactionTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransactions_Subcategories_SubcategoryID",
                table: "AccountTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_AccountTransactions_TransacationTypes_TransactionTypeID",
                table: "AccountTransactions");

            migrationBuilder.DropTable(
                name: "Subcategories");

            migrationBuilder.DropTable(
                name: "TransacationTypes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CategoryTypes");

            migrationBuilder.DropIndex(
                name: "IX_AccountTransactions_SubcategoryID",
                table: "AccountTransactions");

            migrationBuilder.DropIndex(
                name: "IX_AccountTransactions_TransactionTypeID",
                table: "AccountTransactions");

            migrationBuilder.DropColumn(
                name: "SubcategoryID",
                table: "AccountTransactions");

            migrationBuilder.DropColumn(
                name: "TransactionTypeID",
                table: "AccountTransactions");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "AccountTransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CategoryType",
                table: "AccountTransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "AccountTransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AccountTransactions",
                columns: new[] { "TransactionID", "Amount", "BankAccountID", "Category", "CategoryType", "Description", "TransactionDate", "Type" },
                values: new object[,]
                {
                    { 1, 1000.0, 1, "Income", "Income", "Salary Deposit", new DateTime(2025, 12, 5, 19, 51, 48, 877, DateTimeKind.Local).AddTicks(7496), "Credit" },
                    { 2, 100.0, 1, "Groceries", "Variable", "No Frills", new DateTime(2025, 12, 4, 19, 51, 48, 877, DateTimeKind.Local).AddTicks(7574), "Debit" }
                });
        }
    }
}
