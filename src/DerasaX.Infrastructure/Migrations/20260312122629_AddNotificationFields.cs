using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DerasaX.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNotificationFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TargetAudience",
                table: "notifications");

            migrationBuilder.RenameColumn(
                name: "notificationCategory",
                table: "notifications",
                newName: "NotificationCategory");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "notifications",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MetadataJson",
                table: "notifications",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NotificationType",
                table: "notifications",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_CreatedAt",
                table: "notifications",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_IsRead",
                table: "notifications",
                column: "IsRead");

            migrationBuilder.CreateIndex(
                name: "IX_notifications_UserId_IsRead",
                table: "notifications",
                columns: new[] { "UserId", "IsRead" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_notifications_CreatedAt",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "IX_notifications_IsRead",
                table: "notifications");

            migrationBuilder.DropIndex(
                name: "IX_notifications_UserId_IsRead",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "MetadataJson",
                table: "notifications");

            migrationBuilder.DropColumn(
                name: "NotificationType",
                table: "notifications");

            migrationBuilder.RenameColumn(
                name: "NotificationCategory",
                table: "notifications",
                newName: "notificationCategory");

            migrationBuilder.AddColumn<int>(
                name: "TargetAudience",
                table: "notifications",
                type: "integer",
                nullable: true);
        }
    }
}
