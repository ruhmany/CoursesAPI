using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RahmanyCourses.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedCoursesToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2025, 1, 6, 14, 2, 45, 398, DateTimeKind.Utc).AddTicks(3614));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2025, 1, 6, 14, 2, 45, 398, DateTimeKind.Utc).AddTicks(3623));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2025, 1, 6, 14, 2, 45, 398, DateTimeKind.Utc).AddTicks(3625));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2025, 1, 6, 14, 2, 45, 398, DateTimeKind.Utc).AddTicks(3628));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 1,
                column: "CreationDate",
                value: new DateTime(2024, 2, 5, 22, 55, 3, 486, DateTimeKind.Utc).AddTicks(8696));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 2,
                column: "CreationDate",
                value: new DateTime(2024, 2, 5, 22, 55, 3, 486, DateTimeKind.Utc).AddTicks(8704));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 3,
                column: "CreationDate",
                value: new DateTime(2024, 2, 5, 22, 55, 3, 486, DateTimeKind.Utc).AddTicks(8706));

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 4,
                column: "CreationDate",
                value: new DateTime(2024, 2, 5, 22, 55, 3, 486, DateTimeKind.Utc).AddTicks(8709));
        }
    }
}
