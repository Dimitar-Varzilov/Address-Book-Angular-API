using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AddressBookAPI.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressComments_Address_AddressTypeAddressIdAddressId",
                table: "AddressComments");

            migrationBuilder.DropIndex(
                name: "IX_AddressComments_AddressTypeAddressIdAddressId",
                table: "AddressComments");

            migrationBuilder.DropColumn(
                name: "AddressTypeAddressIdAddressId",
                table: "AddressComments");

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "AddressComments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AddressComments_AddressId",
                table: "AddressComments",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressComments_Address_AddressId",
                table: "AddressComments",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "AddressId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AddressComments_Address_AddressId",
                table: "AddressComments");

            migrationBuilder.DropIndex(
                name: "IX_AddressComments_AddressId",
                table: "AddressComments");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "AddressComments");

            migrationBuilder.AddColumn<int>(
                name: "AddressTypeAddressIdAddressId",
                table: "AddressComments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AddressComments_AddressTypeAddressIdAddressId",
                table: "AddressComments",
                column: "AddressTypeAddressIdAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_AddressComments_Address_AddressTypeAddressIdAddressId",
                table: "AddressComments",
                column: "AddressTypeAddressIdAddressId",
                principalTable: "Address",
                principalColumn: "AddressId");
        }
    }
}
