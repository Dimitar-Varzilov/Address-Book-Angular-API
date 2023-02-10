using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddressBookAPI.Migrations
{
    /// <inheritdoc />
    public partial class MoreColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TelNumber",
                table: "Address",
                newName: "LastUpdatedBy");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Address",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Address",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Address",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "Address",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Address",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telephone",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserAddress",
                table: "Address",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "LastUpdatedOn",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "Telephone",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "UserAddress",
                table: "Address");

            migrationBuilder.RenameColumn(
                name: "LastUpdatedBy",
                table: "Address",
                newName: "TelNumber");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Address",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Address",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);
        }
    }
}
