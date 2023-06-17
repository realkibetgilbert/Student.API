using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.API.Migrations
{
    public partial class student : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Students_StudenttId",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_StudenttId",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "StudenttId",
                table: "StudentCourses");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Students_StudentId",
                table: "StudentCourses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Students_StudentId",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses");

            migrationBuilder.AddColumn<long>(
                name: "StudenttId",
                table: "StudentCourses",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudenttId",
                table: "StudentCourses",
                column: "StudenttId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Students_StudenttId",
                table: "StudentCourses",
                column: "StudenttId",
                principalTable: "Students",
                principalColumn: "Id");
        }
    }
}
