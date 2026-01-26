using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DerasaX.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addtable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_AspNetUsers_Post_UserId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_AspNetUsers_SupportRequest_UserId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_AspNetUsers_UserId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_GradeId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_LessonId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_QuestionId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_QuizGeneration_QuizId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_QuizId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_QuizSubmissionId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_QuizSubmission_QuizId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_Quiz_LessonId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_SelectedOptionId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_StudentLessonProgress_LessonId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_SubjectId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_SubmissionAnswer_QuestionId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_UnitId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_BaseEntity_Unit_SubjectId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_Student_StudentId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_Student_StudentInsight_StudentId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_BaseEntity_Student_StudentLessonProgress_StudentId",
                table: "BaseEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_Student_BaseEntity_GradeId",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BaseEntity",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_GradeId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_LessonId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_Post_UserId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_QuestionId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_Quiz_LessonId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_QuizGeneration_QuizId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_QuizId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_QuizSubmission_QuizId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_QuizSubmissionId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_SelectedOptionId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_StudentId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_StudentInsight_StudentId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_StudentLessonProgress_LessonId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_StudentLessonProgress_StudentId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_SubmissionAnswer_QuestionId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_SupportRequest_UserId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_Unit_SubjectId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_UnitId",
                table: "BaseEntity");

            migrationBuilder.DropIndex(
                name: "IX_BaseEntity_UserId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "AchievedScore",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ActionUrl",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Body",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "CommentsCount",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "CompletedAt",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ConfidenceScore",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ExpiresAt",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "GeneratedAt",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "GradeId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "IsCorrect",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "LessonId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "LessonMaterial_Title",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Lesson_Title",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "LikesCount",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Notification_Body",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Notification_TargetAudience",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Notification_Title",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Performance",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "PeriodEnd",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "PeriodStart",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "PointsEarned",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Post_Content",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Post_CreatedAt",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Post_UserId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "PromptUsed",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "QuestionOption_Text",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Question_Type",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "QuizGeneration_QuizId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "QuizSubmissionId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "QuizSubmission_QuizId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Quiz_LessonId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "RespondedAt",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ResponseMessage",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "SelectedOptionId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "StudentInsight_GeneratedAt",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "StudentInsight_StudentId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "StudentLessonProgress_LessonId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "StudentLessonProgress_StudentId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "SubmissionAnswer_IsCorrect",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "SubmissionAnswer_QuestionId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "SubmittedAt",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "SupportRequest_CreatedAt",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "SupportRequest_Type",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "SupportRequest_UserId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "TargetAudience",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "TeacherFeedback",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "TimeLimitMinutes",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "TotalScore",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Unit_SubjectId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Unit_Title",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "ViewsCount",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "gradeType",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "notificationCategory",
                table: "BaseEntity");

            migrationBuilder.DropColumn(
                name: "submissionStatus",
                table: "BaseEntity");

            migrationBuilder.RenameTable(
                name: "BaseEntity",
                newName: "units");

            migrationBuilder.RenameIndex(
                name: "IX_BaseEntity_SubjectId",
                table: "units",
                newName: "IX_units_SubjectId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "units",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SubjectId",
                table: "units",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_units",
                table: "units",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "announcements",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    TargetAudience = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_announcements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "grades",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    gradeType = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lessons",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    UnitId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lessons_units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    ActionUrl = table.Column<string>(type: "text", nullable: true),
                    notificationCategory = table.Column<string>(type: "text", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    TargetAudience = table.Column<int>(type: "integer", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notifications_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    PhotoUrl = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: false),
                    LikesCount = table.Column<int>(type: "integer", nullable: false),
                    CommentsCount = table.Column<int>(type: "integer", nullable: false),
                    ViewsCount = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_posts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentInsights",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Performance = table.Column<string>(type: "text", nullable: false),
                    ConfidenceScore = table.Column<double>(type: "double precision", nullable: false),
                    Period = table.Column<string>(type: "text", nullable: false),
                    GeneratedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PeriodStart = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PeriodEnd = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StudentId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentInsights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentInsights_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "supportRequests",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    ResponseMessage = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RespondedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_supportRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_supportRequests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lessonMaterials",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    LessonId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lessonMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lessonMaterials_lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quizzes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Difficulty = table.Column<string>(type: "text", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TimeLimitMinutes = table.Column<int>(type: "integer", nullable: false),
                    LessonId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quizzes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_quizzes_lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "studentLessonProgresses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    StudentId = table.Column<string>(type: "text", nullable: false),
                    LessonId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_studentLessonProgresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_studentLessonProgresses_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_studentLessonProgresses_lessons_LessonId",
                        column: x => x.LessonId,
                        principalTable: "lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "gradeSubjects",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    GradeId = table.Column<string>(type: "text", nullable: false),
                    SubjectId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gradeSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gradeSubjects_grades_GradeId",
                        column: x => x.GradeId,
                        principalTable: "grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_gradeSubjects_subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "questions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    Points = table.Column<int>(type: "integer", nullable: false),
                    QuizId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_questions_quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quizGenerations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    PromptUsed = table.Column<string>(type: "text", nullable: false),
                    GeneratedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    QuizId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quizGenerations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_quizGenerations_quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "quizSubmissions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AchievedScore = table.Column<int>(type: "integer", nullable: false),
                    TotalScore = table.Column<int>(type: "integer", nullable: false),
                    TeacherFeedback = table.Column<string>(type: "text", nullable: true),
                    submissionStatus = table.Column<string>(type: "text", nullable: false),
                    SubmittedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    StudentId = table.Column<string>(type: "text", nullable: false),
                    QuizId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_quizSubmissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_quizSubmissions_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_quizSubmissions_quizzes_QuizId",
                        column: x => x.QuizId,
                        principalTable: "quizzes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "questionOptions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    QuestionId = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_questionOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_questionOptions_questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "submissionAnswers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    IsCorrect = table.Column<bool>(type: "boolean", nullable: false),
                    PointsEarned = table.Column<int>(type: "integer", nullable: false),
                    QuestionId = table.Column<string>(type: "text", nullable: false),
                    QuizSubmissionId = table.Column<string>(type: "text", nullable: false),
                    SelectedOptionId = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_submissionAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_submissionAnswers_questionOptions_SelectedOptionId",
                        column: x => x.SelectedOptionId,
                        principalTable: "questionOptions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_submissionAnswers_questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_submissionAnswers_quizSubmissions_QuizSubmissionId",
                        column: x => x.QuizSubmissionId,
                        principalTable: "quizSubmissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_gradeSubjects_GradeId",
                table: "gradeSubjects",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_gradeSubjects_SubjectId",
                table: "gradeSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_lessonMaterials_LessonId",
                table: "lessonMaterials",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_lessons_UnitId",
                table: "lessons",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_UserId",
                table: "notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_posts_UserId",
                table: "posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_questionOptions_QuestionId",
                table: "questionOptions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_questions_QuizId",
                table: "questions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_quizGenerations_QuizId",
                table: "quizGenerations",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_quizSubmissions_QuizId",
                table: "quizSubmissions",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_quizSubmissions_StudentId",
                table: "quizSubmissions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_quizzes_LessonId",
                table: "quizzes",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_studentInsights_StudentId",
                table: "studentInsights",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_studentLessonProgresses_LessonId",
                table: "studentLessonProgresses",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_studentLessonProgresses_StudentId",
                table: "studentLessonProgresses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_submissionAnswers_QuestionId",
                table: "submissionAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_submissionAnswers_QuizSubmissionId",
                table: "submissionAnswers",
                column: "QuizSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_submissionAnswers_SelectedOptionId",
                table: "submissionAnswers",
                column: "SelectedOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_supportRequests_UserId",
                table: "supportRequests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_grades_GradeId",
                table: "Student",
                column: "GradeId",
                principalTable: "grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_units_subjects_SubjectId",
                table: "units",
                column: "SubjectId",
                principalTable: "subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_grades_GradeId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_units_subjects_SubjectId",
                table: "units");

            migrationBuilder.DropTable(
                name: "announcements");

            migrationBuilder.DropTable(
                name: "gradeSubjects");

            migrationBuilder.DropTable(
                name: "lessonMaterials");

            migrationBuilder.DropTable(
                name: "notifications");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "quizGenerations");

            migrationBuilder.DropTable(
                name: "studentInsights");

            migrationBuilder.DropTable(
                name: "studentLessonProgresses");

            migrationBuilder.DropTable(
                name: "submissionAnswers");

            migrationBuilder.DropTable(
                name: "supportRequests");

            migrationBuilder.DropTable(
                name: "grades");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "questionOptions");

            migrationBuilder.DropTable(
                name: "quizSubmissions");

            migrationBuilder.DropTable(
                name: "questions");

            migrationBuilder.DropTable(
                name: "quizzes");

            migrationBuilder.DropTable(
                name: "lessons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_units",
                table: "units");

            migrationBuilder.RenameTable(
                name: "units",
                newName: "BaseEntity");

            migrationBuilder.RenameIndex(
                name: "IX_units_SubjectId",
                table: "BaseEntity",
                newName: "IX_BaseEntity_SubjectId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "BaseEntity",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "SubjectId",
                table: "BaseEntity",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "AchievedScore",
                table: "BaseEntity",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ActionUrl",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommentsCount",
                table: "BaseEntity",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CompletedAt",
                table: "BaseEntity",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ConfidenceScore",
                table: "BaseEntity",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "BaseEntity",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Difficulty",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "BaseEntity",
                type: "character varying(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "BaseEntity",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiresAt",
                table: "BaseEntity",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "GeneratedAt",
                table: "BaseEntity",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GradeId",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "BaseEntity",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "BaseEntity",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsCorrect",
                table: "BaseEntity",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "BaseEntity",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LessonId",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LessonMaterial_Title",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lesson_Title",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LikesCount",
                table: "BaseEntity",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notification_Body",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Notification_TargetAudience",
                table: "BaseEntity",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notification_Title",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "BaseEntity",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Performance",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Period",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodEnd",
                table: "BaseEntity",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodStart",
                table: "BaseEntity",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "BaseEntity",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PointsEarned",
                table: "BaseEntity",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Post_Content",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Post_CreatedAt",
                table: "BaseEntity",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Post_UserId",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PromptUsed",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionId",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuestionOption_Text",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Question_Type",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuizGeneration_QuizId",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuizId",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuizSubmissionId",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "QuizSubmission_QuizId",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Quiz_LessonId",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RespondedAt",
                table: "BaseEntity",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResponseMessage",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelectedOptionId",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentId",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StudentInsight_GeneratedAt",
                table: "BaseEntity",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentInsight_StudentId",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentLessonProgress_LessonId",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StudentLessonProgress_StudentId",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SubmissionAnswer_IsCorrect",
                table: "BaseEntity",
                type: "boolean",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubmissionAnswer_QuestionId",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SubmittedAt",
                table: "BaseEntity",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "SupportRequest_CreatedAt",
                table: "BaseEntity",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupportRequest_Type",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SupportRequest_UserId",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TargetAudience",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TeacherFeedback",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeLimitMinutes",
                table: "BaseEntity",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalScore",
                table: "BaseEntity",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnitId",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit_SubjectId",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Unit_Title",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ViewsCount",
                table: "BaseEntity",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "gradeType",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "notificationCategory",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "submissionStatus",
                table: "BaseEntity",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BaseEntity",
                table: "BaseEntity",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_GradeId",
                table: "BaseEntity",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_LessonId",
                table: "BaseEntity",
                column: "LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Post_UserId",
                table: "BaseEntity",
                column: "Post_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_QuestionId",
                table: "BaseEntity",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Quiz_LessonId",
                table: "BaseEntity",
                column: "Quiz_LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_QuizGeneration_QuizId",
                table: "BaseEntity",
                column: "QuizGeneration_QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_QuizId",
                table: "BaseEntity",
                column: "QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_QuizSubmission_QuizId",
                table: "BaseEntity",
                column: "QuizSubmission_QuizId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_QuizSubmissionId",
                table: "BaseEntity",
                column: "QuizSubmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_SelectedOptionId",
                table: "BaseEntity",
                column: "SelectedOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_StudentId",
                table: "BaseEntity",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_StudentInsight_StudentId",
                table: "BaseEntity",
                column: "StudentInsight_StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_StudentLessonProgress_LessonId",
                table: "BaseEntity",
                column: "StudentLessonProgress_LessonId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_StudentLessonProgress_StudentId",
                table: "BaseEntity",
                column: "StudentLessonProgress_StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_SubmissionAnswer_QuestionId",
                table: "BaseEntity",
                column: "SubmissionAnswer_QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_SupportRequest_UserId",
                table: "BaseEntity",
                column: "SupportRequest_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_Unit_SubjectId",
                table: "BaseEntity",
                column: "Unit_SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_UnitId",
                table: "BaseEntity",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseEntity_UserId",
                table: "BaseEntity",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_AspNetUsers_Post_UserId",
                table: "BaseEntity",
                column: "Post_UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_AspNetUsers_SupportRequest_UserId",
                table: "BaseEntity",
                column: "SupportRequest_UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_AspNetUsers_UserId",
                table: "BaseEntity",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_GradeId",
                table: "BaseEntity",
                column: "GradeId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_LessonId",
                table: "BaseEntity",
                column: "LessonId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_QuestionId",
                table: "BaseEntity",
                column: "QuestionId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_QuizGeneration_QuizId",
                table: "BaseEntity",
                column: "QuizGeneration_QuizId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_QuizId",
                table: "BaseEntity",
                column: "QuizId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_QuizSubmissionId",
                table: "BaseEntity",
                column: "QuizSubmissionId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_QuizSubmission_QuizId",
                table: "BaseEntity",
                column: "QuizSubmission_QuizId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_Quiz_LessonId",
                table: "BaseEntity",
                column: "Quiz_LessonId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_SelectedOptionId",
                table: "BaseEntity",
                column: "SelectedOptionId",
                principalTable: "BaseEntity",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_StudentLessonProgress_LessonId",
                table: "BaseEntity",
                column: "StudentLessonProgress_LessonId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_SubjectId",
                table: "BaseEntity",
                column: "SubjectId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_SubmissionAnswer_QuestionId",
                table: "BaseEntity",
                column: "SubmissionAnswer_QuestionId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_UnitId",
                table: "BaseEntity",
                column: "UnitId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_BaseEntity_Unit_SubjectId",
                table: "BaseEntity",
                column: "Unit_SubjectId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_Student_StudentId",
                table: "BaseEntity",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_Student_StudentInsight_StudentId",
                table: "BaseEntity",
                column: "StudentInsight_StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BaseEntity_Student_StudentLessonProgress_StudentId",
                table: "BaseEntity",
                column: "StudentLessonProgress_StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Student_BaseEntity_GradeId",
                table: "Student",
                column: "GradeId",
                principalTable: "BaseEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
