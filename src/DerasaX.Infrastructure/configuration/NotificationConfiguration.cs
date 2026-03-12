using DerasaX.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DerasaX.Infrastructure.configuration
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasIndex(x => x.UserId);
            builder.HasIndex(x => x.IsRead);
            builder.HasIndex(x => x.CreatedAt);
            builder.HasIndex(x => new { x.UserId, x.IsRead });
        }
    }
}
