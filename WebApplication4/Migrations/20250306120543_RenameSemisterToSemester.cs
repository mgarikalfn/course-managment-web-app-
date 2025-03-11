using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class RenameSemisterToSemester : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Semester_SemisterSemesterId",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "SemisterSemesterId",
                table: "Course",
                newName: "SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Course_SemisterSemesterId",
                table: "Course",
                newName: "IX_Course_SemesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Semester_SemesterId",
                table: "Course",
                column: "SemesterId",
                principalTable: "Semester",
                principalColumn: "SemesterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Semester_SemesterId",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "SemesterId",
                table: "Course",
                newName: "SemisterSemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_Course_SemesterId",
                table: "Course",
                newName: "IX_Course_SemisterSemesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Semester_SemisterSemesterId",
                table: "Course",
                column: "SemisterSemesterId",
                principalTable: "Semester",
                principalColumn: "SemesterId");
        }
    }
}
