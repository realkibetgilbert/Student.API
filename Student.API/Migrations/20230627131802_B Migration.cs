using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.API.Migrations
{
    public partial class BMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DepartmentId",
                table: "Lectures",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Lectures_DepartmentId",
                table: "Lectures",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Lectures_Departments_DepartmentId",
                table: "Lectures",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lectures_Departments_DepartmentId",
                table: "Lectures");

            migrationBuilder.DropIndex(
                name: "IX_Lectures_DepartmentId",
                table: "Lectures");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Lectures");
        }
    }
}
