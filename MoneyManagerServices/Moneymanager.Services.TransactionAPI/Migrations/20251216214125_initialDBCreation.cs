using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Moneymanager.Services.TransactionAPI.Migrations
{
    /// <inheritdoc />
    public partial class initialDBCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "AccountTransactions",
                columns: table => new
                {
                    TransactionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    SubcategoryID = table.Column<int>(type: "int", nullable: false),
                    TransactionTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTransactions", x => x.TransactionID);
                    table.ForeignKey(
                        name: "FK_AccountTransactions_Subcategories_SubcategoryID",
                        column: x => x.SubcategoryID,
                        principalTable: "Subcategories",
                        principalColumn: "SubcategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountTransactions_TransacationTypes_TransactionTypeID",
                        column: x => x.TransactionTypeID,
                        principalTable: "TransacationTypes",
                        principalColumn: "TransactionTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "CreatedDate" },
                values: new object[,]
                {
                    { 1, "Income", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, "Auto & Transport", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, "Housing", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, "Bills & Utilities", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 5, "Food & Dining", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 6, "Shopping", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 7, "Gifts & Donations", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 8, "Financial", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 9, "Children", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 10, "Health & Fitness", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 11, "Travel & Fun", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 12, "Business Expenses", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 13, "Other", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "CategoryTypes",
                columns: new[] { "CategoryTypeID", "CategoryTypeName", "CreatedDate" },
                values: new object[,]
                {
                    { 1, "Income", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 2, "Variable", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 3, "Fixed", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local) },
                    { 4, "Other", new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local) }
                });

            migrationBuilder.InsertData(
                table: "TransacationTypes",
                columns: new[] { "TransactionTypeID", "CreatedDate", "TransactionTypeName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Credit" },
                    { 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Debit" }
                });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "SubcategoryID", "CategoryId", "CategoryTypeId", "CreatedDate", "SubcategoryName" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Freelance" },
                    { 2, 1, 1, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Rental Income" },
                    { 3, 1, 1, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Investment Income" },
                    { 4, 1, 1, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Bonus" },
                    { 5, 1, 1, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Interest" },
                    { 6, 1, 1, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Other Income" },
                    { 7, 2, 3, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Auto Payment" },
                    { 8, 2, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Public Transportation" },
                    { 9, 2, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Fuel & Gasoline" },
                    { 10, 2, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Ridesharing & Taxis" },
                    { 11, 2, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Vehicle Maintenance & Repairs" },
                    { 12, 2, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Parking & Tolls" },
                    { 13, 3, 3, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Mortgage" },
                    { 14, 3, 3, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Rent" },
                    { 15, 3, 3, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Property Tax" },
                    { 16, 3, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Home Improvements" },
                    { 17, 3, 3, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Home Security" },
                    { 18, 4, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Home Gas" },
                    { 19, 4, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Home Electricity" },
                    { 20, 4, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Internet & Streaming" },
                    { 21, 4, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Water" },
                    { 22, 4, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Home Rental Equipment" },
                    { 23, 4, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Phone" },
                    { 24, 5, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Groceries" },
                    { 25, 5, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Coffee Shops" },
                    { 26, 5, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Fast Food" },
                    { 27, 5, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Restaurants" },
                    { 28, 6, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Shopping" },
                    { 29, 6, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Clothing & Accessories" },
                    { 30, 6, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Furniture & Home Decor" },
                    { 31, 6, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Appliances & Electronics" },
                    { 32, 7, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Gifts" },
                    { 33, 7, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Charity" },
                    { 34, 8, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Student Loans & Repayments" },
                    { 35, 8, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Financial Fees" },
                    { 36, 8, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Taxes" },
                    { 37, 8, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Cash & Withdrawals" },
                    { 38, 8, 3, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Car Insurance" },
                    { 39, 8, 3, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Home Insurance" },
                    { 40, 8, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Other Insurance" },
                    { 41, 8, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Savings" },
                    { 42, 8, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Investments" },
                    { 43, 9, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Childcare Expenses" },
                    { 44, 9, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Child Activities" },
                    { 45, 10, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Medical" },
                    { 46, 10, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Dentist" },
                    { 47, 10, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Fitness" },
                    { 48, 11, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Travel & Vacations" },
                    { 49, 11, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Entertainment & Leisure" },
                    { 50, 11, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Hobbies & Crafts" },
                    { 51, 11, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Pets" },
                    { 52, 11, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Fun Money" },
                    { 53, 11, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Personal Care" },
                    { 54, 11, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Subscriptions & Memberships" },
                    { 55, 12, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Advertising & Marketing" },
                    { 56, 12, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Office Supplies" },
                    { 57, 12, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Software & Tools" },
                    { 58, 12, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Business Utilities" },
                    { 59, 12, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Employee Salaries" },
                    { 60, 12, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Business Travel" },
                    { 61, 12, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Business Insurance" },
                    { 62, 12, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Business Rent" },
                    { 63, 12, 2, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Other Business Expenses" },
                    { 64, 13, 4, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Uncategorized" },
                    { 65, 13, 4, new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Local), "Miscellaneous Expenses" }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTransactions");

            migrationBuilder.DropTable(
                name: "Subcategories");

            migrationBuilder.DropTable(
                name: "TransacationTypes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CategoryTypes");
        }
    }
}
