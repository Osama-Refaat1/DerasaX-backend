using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DerasaX.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateTenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConnectionString",
                table: "tenants");

            migrationBuilder.CreateIndex(
                name: "IX_units_TenantId",
                table: "units",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_supportRequests_TenantId",
                table: "supportRequests",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_submissionAnswers_TenantId",
                table: "submissionAnswers",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_subjects_TenantId",
                table: "subjects",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_studentLessonProgresses_TenantId",
                table: "studentLessonProgresses",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_studentInsights_TenantId",
                table: "studentInsights",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_quizzes_TenantId",
                table: "quizzes",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_quizSubmissions_TenantId",
                table: "quizSubmissions",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_quizGenerations_TenantId",
                table: "quizGenerations",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_questions_TenantId",
                table: "questions",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_questionOptions_TenantId",
                table: "questionOptions",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_posts_TenantId",
                table: "posts",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_TenantId",
                table: "notifications",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_lessons_TenantId",
                table: "lessons",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_lessonMaterials_TenantId",
                table: "lessonMaterials",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_gradeSubjects_TenantId",
                table: "gradeSubjects",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_grades_TenantId",
                table: "grades",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_announcements_TenantId",
                table: "announcements",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_units_TenantId",
                table: "units");

            migrationBuilder.DropIndex(
                name: "IX_supportRequests_TenantId",
                table: "supportRequests");

            migrationBuilder.DropIndex(
                name: "IX_submissionAnswers_TenantId",
                table: "submissionAnswers");

            migrationBuilder.DropIndex(
                name: "IX_subjects_TenantId",
                table: "subjects");

            migrationBuilder.DropIndex(
                name: "IX_studentLessonProgresses_TenantId",
                table: "studentLessonProgresses");

            migrationBuilder.DropIndex(
                name: "IX_studentInsights_TenantId",
                table: "studentInsights");

            migrationBuilder.DropIndex(
                name: "IX_quizzes_TenantId",
                table: "quizzes");

            migrationBuilder.DropIndex(
                name: "IX_quizSubmissions_TenantId",
                table: "quizSubmissions");

            migrationBuilder.DropIndex(
                name: "IX_quizGenerations_TenantId",
                table: "quizGenerations");

            migrationBuilder.DropIndex(
                name: "IX_questions_TenantId",
                table: "questions");

            migrationBuilder.DropIndex(
                name: "IX_questionOptions_TenantId",
                table: "questionOptions");

            migrationBuilder.DropIndex(
                name: "IX_posts_TenantId",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_notifications_TenantId",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "IX_lessons_TenantId",
                table: "lessons");

            migrationBuilder.DropIndex(
                name: "IX_lessonMaterials_TenantId",
                table: "lessonMaterials");

            migrationBuilder.DropIndex(
                name: "IX_gradeSubjects_TenantId",
                table: "gradeSubjects");

            migrationBuilder.DropIndex(
                name: "IX_grades_TenantId",
                table: "grades");

            migrationBuilder.DropIndex(
                name: "IX_announcements_TenantId",
                table: "announcements");

            migrationBuilder.AddColumn<string>(
                name: "ConnectionString",
                table: "tenants",
                type: "text",
                nullable: true);
        }
    }
}
