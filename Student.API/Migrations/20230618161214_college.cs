using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Student.API.Migrations
{
    public partial class college : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_College_CollegeId",
                table: "School");

            migrationBuilder.DropPrimaryKey(
                name: "PK_College",
                table: "College");

            migrationBuilder.RenameTable(
                name: "College",
                newName: "Colleges");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colleges",
                table: "Colleges",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_School_Colleges_CollegeId",
                table: "School",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_School_Colleges_CollegeId",
                table: "School");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colleges",
                table: "Colleges");

            migrationBuilder.RenameTable(
                name: "Colleges",
                newName: "College");

            migrationBuilder.AddPrimaryKey(
                name: "PK_College",
                table: "College",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_School_College_CollegeId",
                table: "School",
                column: "CollegeId",
                principalTable: "College",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
