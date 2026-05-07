using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DerasaX.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class quizrelatonship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quizzes_lessons_LessonId",
                table: "quizzes");

            migrationBuilder.AlterColumn<string>(
                name: "LessonId",
                table: "quizzes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "SubjectId",
                table: "quizzes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "quizzes",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_quizzes_SubjectId",
                table: "quizzes",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_quizzes_lessons_LessonId",
                table: "quizzes",
                column: "LessonId",
                principalTable: "lessons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_quizzes_subjects_SubjectId",
                table: "quizzes",
                column: "SubjectId",
                principalTable: "subjects",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_quizzes_lessons_LessonId",
                table: "quizzes");

            migrationBuilder.DropForeignKey(
                name: "FK_quizzes_subjects_SubjectId",
                table: "quizzes");

            migrationBuilder.DropIndex(
                name: "IX_quizzes_SubjectId",
                table: "quizzes");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "quizzes");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "quizzes");

            migrationBuilder.AlterColumn<string>(
                name: "LessonId",
                table: "quizzes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_quizzes_lessons_LessonId",
                table: "quizzes",
                column: "LessonId",
                principalTable: "lessons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
