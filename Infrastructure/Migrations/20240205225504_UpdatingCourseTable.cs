using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RahmanyCourses.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingCourseTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ThumbnailUri",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "CreationDate", "ThumbnailUri" },
                values: new object[] { new DateTime(2024, 2, 5, 22, 55, 3, 486, DateTimeKind.Utc).AddTicks(8696), "" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CreationDate", "ThumbnailUri" },
                values: new object[] { new DateTime(2024, 2, 5, 22, 55, 3, 486, DateTimeKind.Utc).AddTicks(8704), "" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CreationDate", "ThumbnailUri" },
                values: new object[] { new DateTime(2024, 2, 5, 22, 55, 3, 486, DateTimeKind.Utc).AddTicks(8706), "" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "CreationDate", "ThumbnailUri" },
                values: new object[] { new DateTime(2024, 2, 5, 22, 55, 3, 486, DateTimeKind.Utc).AddTicks(8709), "" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ThumbnailUri",
                table: "Courses");

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
    }
}
