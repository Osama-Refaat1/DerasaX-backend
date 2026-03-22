using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DerasaX.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedDataStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FullName", "Gender", "ImageUrl", "IsDeleted", "LockoutEnabled", "LockoutEnd", "LoginCode", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityAnswerHash", "SecurityQuestionId", "SecurityStamp", "TenantId", "TwoFactorEnabled", "UserName" },
                values: new object[] { "user-student-1", 0, "5320a98a-7afe-45a9-8360-08d445bde989", "malak@alnour.derasax.com", true, "Malak Khaled", 1, null, false, false, null, "STU-0001", "Malak@ALNOUR.DERASAX.COM", "Malak", "AQAAAAIAAYagAAAAECtTLtnI0A/IQMaAEGX0ayVjc8gteIZBGLNhjbiWuPgsv28qN3CX22c9sGQS5lO+Aw==", null, false, "AQAAAAIAAYagAAAAEB7Tn4WGM5jh+cf7QXiLoE2Batu/WfsLKAR7me6Ec0OE4H7j0/i8iYm01ftUhycFEg==", 5, "4bcc031f-a9bd-45a2-a769-eb263fec1a64", "tenant-1", false, "malak" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "GradeId" },
                values: new object[] { "user-student-1", "grade-1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: "user-student-1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "user-student-1");
        }
    }
}
