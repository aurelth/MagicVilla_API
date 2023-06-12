using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicVilla_Api.Migrations
{
    /// <inheritdoc />
    public partial class VillaNumberDbUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VilaNo",
                table: "VillaNumbers",
                newName: "VillaNo");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 7, 16, 10, 54, 326, DateTimeKind.Local).AddTicks(2106));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 7, 16, 10, 54, 326, DateTimeKind.Local).AddTicks(2121));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 7, 16, 10, 54, 326, DateTimeKind.Local).AddTicks(2123));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 7, 16, 10, 54, 326, DateTimeKind.Local).AddTicks(2125));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 7, 16, 10, 54, 326, DateTimeKind.Local).AddTicks(2127));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VillaNo",
                table: "VillaNumbers",
                newName: "VilaNo");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 6, 20, 16, 32, 830, DateTimeKind.Local).AddTicks(4094));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 6, 20, 16, 32, 830, DateTimeKind.Local).AddTicks(4109));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 6, 20, 16, 32, 830, DateTimeKind.Local).AddTicks(4111));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 6, 20, 16, 32, 830, DateTimeKind.Local).AddTicks(4116));

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 6, 6, 20, 16, 32, 830, DateTimeKind.Local).AddTicks(4117));
        }
    }
}
