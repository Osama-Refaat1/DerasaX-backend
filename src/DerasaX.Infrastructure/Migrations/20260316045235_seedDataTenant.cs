using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DerasaX.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedDataTenant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "tenants",
                columns: new[] { "Id", "Address", "Domain", "LogoUrl", "Name", "Phone", "SubscriptionPlan", "Type" },
                values: new object[] { "tenant-1", "Cairo, Egypt", "alnour.derasax.com", null, "Al Nour School", "0201000000001", "Pro", "Egyptian" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tenants",
                keyColumn: "Id",
                keyValue: "tenant-1");
        }
    }
}
