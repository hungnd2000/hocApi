using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreBt23.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Gender = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Status = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Tbl_Student_Pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Name = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Status = table.Column<bool>(type: "NUMBER(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Tbl_Subject_Pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mark",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    StudentId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SubjectId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Scores = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_mark_student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_mark_subject_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_mark_StudentId",
                table: "mark",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_mark_SubjectId",
                table: "mark",
                column: "SubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "mark");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "subject");
        }
    }
}
