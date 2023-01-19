using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task08.Migrations
{
    /// <inheritdoc />
    public partial class addedUserTableFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    RerfreshTokenExpiration = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("User_PK", x => x.IdUser);
                });

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(1998, 1, 17, 22, 35, 37, 666, DateTimeKind.Local).AddTicks(6222));

            migrationBuilder.UpdateData(
                table: "Patient",
                keyColumn: "IdPatient",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(2002, 1, 17, 22, 35, 37, 666, DateTimeKind.Local).AddTicks(6279));

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 1,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 1, 17, 22, 35, 37, 668, DateTimeKind.Local).AddTicks(2817), new DateTime(2023, 4, 17, 22, 35, 37, 668, DateTimeKind.Local).AddTicks(2831) });

            migrationBuilder.UpdateData(
                table: "Prescription",
                keyColumn: "IdPrescription",
                keyValue: 2,
                columns: new[] { "Date", "DueDate" },
                values: new object[] { new DateTime(2023, 1, 17, 22, 35, 37, 668, DateTimeKind.Local).AddTicks(2841), new DateTime(2023, 4, 17, 22, 35, 37, 668, DateTimeKind.Local).AddTicks(2845) });

            migrationBuilder.CreateIndex(
                name: "IX_User_Login",
                table: "User",
                column: "Login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

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
    }
}
