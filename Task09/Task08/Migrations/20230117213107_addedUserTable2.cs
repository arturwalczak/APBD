using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task08.Migrations
{
    /// <inheritdoc />
    public partial class addedUserTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(1998, 1, 17, 22, 31, 7, 675, DateTimeKind.Local).AddTicks(349));

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2002, 1, 17, 22, 31, 7, 675, DateTimeKind.Local).AddTicks(401));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 1, 17, 22, 31, 7, 676, DateTimeKind.Local).AddTicks(6479), new DateTime(2023, 4, 17, 22, 31, 7, 676, DateTimeKind.Local).AddTicks(6493) });

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 1, 17, 22, 31, 7, 676, DateTimeKind.Local).AddTicks(6502), new DateTime(2023, 4, 17, 22, 31, 7, 676, DateTimeKind.Local).AddTicks(6505) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(1998, 1, 17, 22, 5, 23, 153, DateTimeKind.Local).AddTicks(5044));

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2002, 1, 17, 22, 5, 23, 153, DateTimeKind.Local).AddTicks(5106));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 1, 17, 22, 5, 23, 155, DateTimeKind.Local).AddTicks(8034), new DateTime(2023, 4, 17, 22, 5, 23, 155, DateTimeKind.Local).AddTicks(8058) });

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 1, 17, 22, 5, 23, 155, DateTimeKind.Local).AddTicks(8070), new DateTime(2023, 4, 17, 22, 5, 23, 155, DateTimeKind.Local).AddTicks(8074) });
        }
    }
}
