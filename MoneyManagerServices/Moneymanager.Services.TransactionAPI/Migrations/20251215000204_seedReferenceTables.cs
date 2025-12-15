using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Moneymanager.Services.TransactionAPI.Migrations
{
    /// <inheritdoc />
    public partial class seedReferenceTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "CreatedDate" },
                values: new object[,]
                {
                    { 1, "Income", new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(7976) },
                    { 2, "Auto & Transport", new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(7980) },
                    { 3, "Housing", new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(7984) },
                    { 4, "Bills & Utilities", new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(7988) },
                    { 5, "Food & Dining", new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(7992) },
                    { 6, "Shopping", new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(7996) },
                    { 7, "Gifts & Donations", new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(7999) },
                    { 8, "Financial", new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8003) },
                    { 9, "Children", new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8007) },
                    { 10, "Health & Fitness", new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8010) },
                    { 11, "Travel & Fun", new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8014) },
                    { 12, "Business Expenses", new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8017) },
                    { 13, "Other", new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8022) }
                });

            migrationBuilder.InsertData(
                table: "CategoryTypes",
                columns: new[] { "CategoryTypeID", "CategoryTypeName", "CreatedDate" },
                values: new object[,]
                {
                    { 1, "Income", new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(7688) },
                    { 2, "Variable", new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(7758) },
                    { 3, "Fixed", new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(7763) },
                    { 4, "Other", new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(7767) }
                });

            migrationBuilder.InsertData(
                table: "Subcategories",
                columns: new[] { "SubcategoryID", "CategoryId", "CategoryTypeId", "CreatedDate", "SubcategoryName" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8088), "Freelance" },
                    { 2, 1, 1, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8094), "Rental Income" },
                    { 3, 1, 1, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8098), "Investment Income" },
                    { 4, 1, 1, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8102), "Bonus" },
                    { 5, 1, 1, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8106), "Interest" },
                    { 6, 1, 1, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8111), "Other Income" },
                    { 7, 2, 3, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8115), "Auto Payment" },
                    { 8, 2, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8119), "Public Transportation" },
                    { 9, 2, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8123), "Fuel & Gasoline" },
                    { 10, 2, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8127), "Ridesharing & Taxis" },
                    { 11, 2, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8131), "Vehicle Maintenance & Repairs" },
                    { 12, 2, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8135), "Parking & Tolls" },
                    { 13, 3, 3, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8139), "Mortgage" },
                    { 14, 3, 3, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8143), "Rent" },
                    { 15, 3, 3, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8147), "Property Tax" },
                    { 16, 3, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8151), "Home Improvements" },
                    { 17, 3, 3, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8155), "Home Security" },
                    { 18, 4, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8159), "Home Gas" },
                    { 19, 4, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8163), "Home Electricity" },
                    { 20, 4, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8167), "Internet & Streaming" },
                    { 21, 4, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8171), "Water" },
                    { 22, 4, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8175), "Home Rental Equipment" },
                    { 23, 4, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8179), "Phone" },
                    { 24, 5, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8183), "Groceries" },
                    { 25, 5, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8188), "Coffee Shops" },
                    { 26, 5, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8192), "Fast Food" },
                    { 27, 5, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8196), "Restaurants" },
                    { 28, 6, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8200), "Shopping" },
                    { 29, 6, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8204), "Clothing & Accessories" },
                    { 30, 6, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8208), "Furniture & Home Decor" },
                    { 31, 6, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8211), "Appliances & Electronics" },
                    { 32, 7, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8215), "Gifts" },
                    { 33, 7, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8219), "Charity" },
                    { 34, 8, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8223), "Student Loans & Repayments" },
                    { 35, 8, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8227), "Financial Fees" },
                    { 36, 8, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8231), "Taxes" },
                    { 37, 8, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8235), "Cash & Withdrawals" },
                    { 38, 8, 3, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8239), "Car Insurance" },
                    { 39, 8, 3, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8243), "Home Insurance" },
                    { 40, 8, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8247), "Other Insurance" },
                    { 41, 8, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8251), "Savings" },
                    { 42, 8, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8254), "Investments" },
                    { 43, 9, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8258), "Childcare Expenses" },
                    { 44, 9, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8262), "Child Activities" },
                    { 45, 10, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8266), "Medical" },
                    { 46, 10, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8270), "Dentist" },
                    { 47, 10, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8274), "Fitness" },
                    { 48, 11, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8278), "Travel & Vacations" },
                    { 49, 11, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8281), "Entertainment & Leisure" },
                    { 50, 11, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8285), "Hobbies & Crafts" },
                    { 51, 11, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8289), "Pets" },
                    { 52, 11, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8293), "Fun Money" },
                    { 53, 11, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8297), "Personal Care" },
                    { 54, 11, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8301), "Subscriptions & Memberships" },
                    { 55, 12, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8305), "Advertising & Marketing" },
                    { 56, 12, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8309), "Office Supplies" },
                    { 57, 12, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8313), "Software & Tools" },
                    { 58, 12, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8317), "Business Utilities" },
                    { 59, 12, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8321), "Employee Salaries" },
                    { 60, 12, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8325), "Business Travel" },
                    { 61, 12, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8328), "Business Insurance" },
                    { 62, 12, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8332), "Business Rent" },
                    { 63, 12, 2, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8336), "Other Business Expenses" },
                    { 64, 13, 4, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8340), "Uncategorized" },
                    { 65, 13, 4, new DateTime(2025, 12, 14, 19, 2, 4, 19, DateTimeKind.Local).AddTicks(8344), "Miscellaneous Expenses" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "CategoryTypes",
                keyColumn: "CategoryTypeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoryTypes",
                keyColumn: "CategoryTypeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CategoryTypes",
                keyColumn: "CategoryTypeID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CategoryTypes",
                keyColumn: "CategoryTypeID",
                keyValue: 4);
        }
    }
}
