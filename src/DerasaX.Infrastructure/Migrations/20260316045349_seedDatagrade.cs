using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DerasaX.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedDatagrade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "grades",
                columns: new[] { "Id", "IsDeleted", "TenantId", "gradeType" },
                values: new object[,]
                {
                    { "grade-1", false, "tenant-1", "Grade8" },
                    { "grade-2", false, "tenant-1", "Grade9" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "grades",
                keyColumn: "Id",
                keyValue: "grade-1");

            migrationBuilder.DeleteData(
                table: "grades",
                keyColumn: "Id",
                keyValue: "grade-2");
        }
    }
}
