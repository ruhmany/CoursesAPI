using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RahmanyCourses.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "courseCategories",
                columns: new[] { "ID", "CategoryName", "IsDeleted" },
                values: new object[,]
                {
                    { 1, "Programming", false },
                    { 2, "Database", false },
                    { 3, "Software Engnireeing", false },
                    { 4, "Project Managment", false }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "ID", "CategoryID", "CreationDate", "Description", "InstructorID", "IsDeleted", "Price", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 12, 17, 13, 31, 54, 766, DateTimeKind.Utc).AddTicks(1871), "Taking your from zero level to the dargon level in php within two weeks", 5, false, 1250m, "PHP Fundamentals" },
                    { 2, 1, new DateTime(2023, 12, 17, 13, 31, 54, 766, DateTimeKind.Utc).AddTicks(1879), "Taking your from zero level to the dargon level in C# within two weeks", 6, false, 2500m, "C# Fundamentals" },
                    { 3, 2, new DateTime(2023, 12, 17, 13, 31, 54, 766, DateTimeKind.Utc).AddTicks(1881), "Taking your from zero level to the dargon level in php within two weeks", 6, false, 1500m, "SQL Fundamentals" },
                    { 4, 3, new DateTime(2023, 12, 17, 13, 31, 54, 766, DateTimeKind.Utc).AddTicks(1884), "Taking your from zero level to the dargon level in full-stack web development using php within two weeks", 5, false, 1200m, "Full-Stack Web Development Using PHO" }
                });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "CourseID", "UserID", "EnrollmentDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseID", "UserID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseID", "UserID" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseID", "UserID" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseID", "UserID" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseID", "UserID" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseID", "UserID" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseID", "UserID" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "Enrollments",
                keyColumns: new[] { "CourseID", "UserID" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "courseCategories",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "courseCategories",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "courseCategories",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "courseCategories",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
