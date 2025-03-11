using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication4.Migrations
{
    /// <inheritdoc />
    public partial class AddDepartmentToOffering : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "Offering",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Offering_DepartmentID",
                table: "Offering",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Offering_Department_DepartmentID",
                table: "Offering",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "DepartmentID",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offering_Department_DepartmentID",
                table: "Offering");

            migrationBuilder.DropIndex(
                name: "IX_Offering_DepartmentID",
                table: "Offering");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "Offering");
        }
    }
}
