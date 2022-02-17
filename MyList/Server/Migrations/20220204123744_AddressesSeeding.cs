using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyList.Server.Migrations
{
    public partial class AddressesSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "DateMeasurment", "DateMontage", "Name", "Sum", "WorkersName" },
                values: new object[] { 1, new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), "str. Nova 99", 11500, "" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "DateMeasurment", "DateMontage", "Name", "Sum", "WorkersName" },
                values: new object[] { 2, new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), "str. Dobor 1", 9300, "" });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "DateMeasurment", "DateMontage", "Name", "Sum", "WorkersName" },
                values: new object[] { 3, new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), "str. Znaniya 12", 8200, "" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
