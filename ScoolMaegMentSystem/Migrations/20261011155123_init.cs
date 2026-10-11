using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ScoolMaegMentSystem.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "studentProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParentPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmergencyContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentProfiles_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "courses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreditHours = table.Column<int>(type: "int", nullable: false),
                    TeatcherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_courses_teachers_TeatcherId",
                        column: x => x.TeatcherId,
                        principalTable: "teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "enrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourceId = table.Column<int>(type: "int", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_enrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_enrollments_courses_CourceId",
                        column: x => x.CourceId,
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_enrollments_students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "Id", "BirthDate", "Email", "FullName", "Gender", "Phone" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rofa@gmail.com", "Rofaida Hamada", "Femal", "01005605262" },
                    { 2, new DateTime(2027, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Retaa@gmail.com", "Retaj Hany", "Femal", "0107545262" }
                });

            migrationBuilder.InsertData(
                table: "teachers",
                columns: new[] { "Id", "Email", "FullName", "HireDate", "Phone" },
                values: new object[,]
                {
                    { 1, "Dena@gmail.com", "Dina El-Sayed", new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "0100567892" },
                    { 2, "Fady@gmail.com", "Fady El-Hosseny", new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "096657892" }
                });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "Id", "CreditHours", "TeatcherId", "Title" },
                values: new object[,]
                {
                    { 1, 6, 1, "Cs" },
                    { 2, 5, 2, "Es" }
                });

            migrationBuilder.InsertData(
                table: "studentProfiles",
                columns: new[] { "Id", "Address", "EmergencyContact", "ParentPhone", "StudentId" },
                values: new object[,]
                {
                    { 1, "Ciyro", "65356788", "265764764", 1 },
                    { 2, "Giza", "55556788", "7777764764", 2 }
                });

            migrationBuilder.InsertData(
                table: "enrollments",
                columns: new[] { "Id", "CourceId", "EnrollmentDate", "Grade", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 90.120000000000005, 1 },
                    { 2, 2, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_courses_TeatcherId",
                table: "courses",
                column: "TeatcherId");

            migrationBuilder.CreateIndex(
                name: "IX_enrollments_CourceId",
                table: "enrollments",
                column: "CourceId");

            migrationBuilder.CreateIndex(
                name: "IX_enrollments_StudentId_CourceId",
                table: "enrollments",
                columns: new[] { "StudentId", "CourceId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_studentProfiles_StudentId",
                table: "studentProfiles",
                column: "StudentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_students_Email",
                table: "students",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_teachers_Email",
                table: "teachers",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "enrollments");

            migrationBuilder.DropTable(
                name: "studentProfiles");

            migrationBuilder.DropTable(
                name: "courses");

            migrationBuilder.DropTable(
                name: "students");

            migrationBuilder.DropTable(
                name: "teachers");
        }
    }
}
