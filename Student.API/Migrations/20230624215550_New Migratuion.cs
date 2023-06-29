using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.API.Migrations
{
    public partial class NewMigratuion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Schools_schoolId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Schools_Colleges_CollegeId",
                table: "Schools");

            migrationBuilder.RenameColumn(
                name: "CollegeId",
                table: "Schools",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Schools_CollegeId",
                table: "Schools",
                newName: "IX_Schools_DepartmentId");

            migrationBuilder.RenameColumn(
                name: "schoolId",
                table: "Departments",
                newName: "CollegeId");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_schoolId",
                table: "Departments",
                newName: "IX_Departments_CollegeId");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Courses",
                newName: "SchoolId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_DepartmentId",
                table: "Courses",
                newName: "IX_Courses_SchoolId");

            migrationBuilder.AddColumn<string>(
                name: "StudentName",
                table: "StudentCourses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LectureId",
                table: "Courses",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_LectureId",
                table: "Courses",
                column: "LectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Lectures_LectureId",
                table: "Courses",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Schools_SchoolId",
                table: "Courses",
                column: "SchoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Colleges_CollegeId",
                table: "Departments",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Departments_DepartmentId",
                table: "Schools",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Lectures_LectureId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Schools_SchoolId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Colleges_CollegeId",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Schools_Departments_DepartmentId",
                table: "Schools");

            migrationBuilder.DropIndex(
                name: "IX_Courses_LectureId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StudentName",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "LectureId",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Schools",
                newName: "CollegeId");

            migrationBuilder.RenameIndex(
                name: "IX_Schools_DepartmentId",
                table: "Schools",
                newName: "IX_Schools_CollegeId");

            migrationBuilder.RenameColumn(
                name: "CollegeId",
                table: "Departments",
                newName: "schoolId");

            migrationBuilder.RenameIndex(
                name: "IX_Departments_CollegeId",
                table: "Departments",
                newName: "IX_Departments_schoolId");

            migrationBuilder.RenameColumn(
                name: "SchoolId",
                table: "Courses",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Courses_SchoolId",
                table: "Courses",
                newName: "IX_Courses_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Departments_DepartmentId",
                table: "Courses",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Schools_schoolId",
                table: "Departments",
                column: "schoolId",
                principalTable: "Schools",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schools_Colleges_CollegeId",
                table: "Schools",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
