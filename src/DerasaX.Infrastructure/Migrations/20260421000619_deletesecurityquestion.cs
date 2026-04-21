using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DerasaX.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class deletesecurityquestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SecurityQuestions_SecurityQuestionId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SecurityQuestions");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SecurityQuestionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SecurityAnswerHash",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SecurityQuestionId",
                table: "AspNetUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecurityAnswerHash",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecurityQuestionId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SecurityQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    Question = table.Column<string>(type: "text", nullable: false),
                    TenantId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecurityQuestions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SecurityQuestionId",
                table: "AspNetUsers",
                column: "SecurityQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_SecurityQuestions_TenantId",
                table: "SecurityQuestions",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SecurityQuestions_SecurityQuestionId",
                table: "AspNetUsers",
                column: "SecurityQuestionId",
                principalTable: "SecurityQuestions",
                principalColumn: "Id");
        }
    }
}
