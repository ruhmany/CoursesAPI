using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RahmanyCourses.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addingIsWatchedToCOntentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsWatched",
                table: "Contents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 11, 59, 51, 746, DateTimeKind.Utc).AddTicks(9503));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 11, 59, 51, 746, DateTimeKind.Utc).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 11, 59, 51, 746, DateTimeKind.Utc).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 1, 28, 11, 59, 51, 746, DateTimeKind.Utc).AddTicks(9511));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsWatched",
                table: "Contents");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2023, 12, 17, 13, 31, 54, 766, DateTimeKind.Utc).AddTicks(1871));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2023, 12, 17, 13, 31, 54, 766, DateTimeKind.Utc).AddTicks(1879));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2023, 12, 17, 13, 31, 54, 766, DateTimeKind.Utc).AddTicks(1881));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2023, 12, 17, 13, 31, 54, 766, DateTimeKind.Utc).AddTicks(1884));
        }
    }
}
