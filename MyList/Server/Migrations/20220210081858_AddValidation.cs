using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyList.Server.Migrations
{
    public partial class AddValidation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Addresses",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateMeasurment", "DateMontage", "WorkersName" },
                values: new object[] { new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Local), "Александр" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateMeasurment", "DateMontage", "WorkersName" },
                values: new object[] { new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Local), "Броня" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateMeasurment", "DateMontage", "WorkersName" },
                values: new object[] { new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Local), "Дима" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateMeasurment", "DateMontage", "WorkersName" },
                values: new object[] { new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), "" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateMeasurment", "DateMontage", "WorkersName" },
                values: new object[] { new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), "" });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateMeasurment", "DateMontage", "WorkersName" },
                values: new object[] { new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), "" });
        }
    }
}
