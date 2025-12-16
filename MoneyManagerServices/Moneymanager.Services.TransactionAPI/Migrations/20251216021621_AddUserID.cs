using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moneymanager.Services.TransactionAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddUserID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserID",
                table: "AccountTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4177));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4180));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4182));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4184));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4186));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4188));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4190));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4191));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4193));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4195));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4197));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4199));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4201));

            migrationBuilder.UpdateData(
                table: "CategoryTypes",
                keyColumn: "CategoryTypeID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4014));

            migrationBuilder.UpdateData(
                table: "CategoryTypes",
                keyColumn: "CategoryTypeID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4060));

            migrationBuilder.UpdateData(
                table: "CategoryTypes",
                keyColumn: "CategoryTypeID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4062));

            migrationBuilder.UpdateData(
                table: "CategoryTypes",
                keyColumn: "CategoryTypeID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4064));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4237));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4239));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4242));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4244));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4246));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4248));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4250));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4252));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4255));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4257));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4259));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4261));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4263));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4265));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4268));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4270));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4272));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4274));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4276));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4278));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4280));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4282));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4284));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4286));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4291));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4293));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4295));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4297));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4299));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4301));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4303));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4305));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 33,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4307));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 34,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4309));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 35,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4311));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 36,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4313));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 37,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4315));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 38,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4317));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 39,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4319));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 40,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4322));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 41,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4324));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 42,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4326));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 43,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4328));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 44,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4330));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 45,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4332));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 46,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4334));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 47,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4336));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 48,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4338));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 49,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4340));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 50,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4342));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 51,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4345));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 52,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4347));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 53,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4349));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 54,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4351));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 55,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4353));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 56,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4355));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 57,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4357));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 58,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4359));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 59,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4361));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 60,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4363));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 61,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4365));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 62,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4367));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 63,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4369));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 64,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4372));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 65,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4374));

            migrationBuilder.UpdateData(
                table: "TransacationTypes",
                keyColumn: "TransactionTypeID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4470));

            migrationBuilder.UpdateData(
                table: "TransacationTypes",
                keyColumn: "TransactionTypeID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 15, 21, 16, 20, 558, DateTimeKind.Local).AddTicks(4472));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserID",
                table: "AccountTransactions");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7370));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7373));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7375));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7378));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7380));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7383));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7386));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7388));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7391));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7393));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7395));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7398));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7400));

            migrationBuilder.UpdateData(
                table: "CategoryTypes",
                keyColumn: "CategoryTypeID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7153));

            migrationBuilder.UpdateData(
                table: "CategoryTypes",
                keyColumn: "CategoryTypeID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7212));

            migrationBuilder.UpdateData(
                table: "CategoryTypes",
                keyColumn: "CategoryTypeID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7216));

            migrationBuilder.UpdateData(
                table: "CategoryTypes",
                keyColumn: "CategoryTypeID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7218));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7442));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7446));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7449));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7452));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7455));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7457));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7460));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7463));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7466));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7469));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7471));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7474));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7477));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7480));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7482));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7485));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7488));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 18,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7490));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 19,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7493));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 20,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7496));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 21,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7499));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 22,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7502));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 23,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7505));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 24,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7508));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 25,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7510));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 26,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7513));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 27,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7516));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 28,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7519));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 29,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7521));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 30,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7524));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 31,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7527));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 32,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7529));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 33,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7532));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 34,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 35,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7538));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 36,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 37,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7543));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 38,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7545));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 39,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7548));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 40,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7551));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 41,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7555));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 42,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7557));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 43,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7561));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 44,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7563));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 45,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7566));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 46,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7569));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 47,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7572));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 48,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7574));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 49,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7577));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 50,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7580));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 51,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7636));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 52,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7639));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 53,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7641));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 54,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7644));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 55,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7647));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 56,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7649));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 57,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7652));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 58,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7655));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 59,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7658));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 60,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7662));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 61,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7665));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 62,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7669));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 63,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7671));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 64,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7674));

            migrationBuilder.UpdateData(
                table: "Subcategories",
                keyColumn: "SubcategoryID",
                keyValue: 65,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7678));

            migrationBuilder.UpdateData(
                table: "TransacationTypes",
                keyColumn: "TransactionTypeID",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7751));

            migrationBuilder.UpdateData(
                table: "TransacationTypes",
                keyColumn: "TransactionTypeID",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 12, 14, 19, 9, 49, 605, DateTimeKind.Local).AddTicks(7755));
        }
    }
}
