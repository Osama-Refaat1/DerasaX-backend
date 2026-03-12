using DerasaX.Domain.Entities.Models;

namespace DerasaX.Domain.Specification
{
    public class NotificationByUserSpecification : BaseSpecification<Notification, string>
    {
        public NotificationByUserSpecification(string userId, int page, int pageSize)
            : base(n => n.UserId == userId && !n.IsDeleted)
        {
            AddOrderByDescending(n => n.CreatedAt);
            ApplyPaging((page - 1) * pageSize, pageSize);
        }
    }

    /// <summary>Used internally when all records are needed (e.g. mark-all-read).</summary>
    public class AllNotificationsByUserSpecification : BaseSpecification<Notification, string>
    {
        public AllNotificationsByUserSpecification(string userId)
            : base(n => n.UserId == userId && !n.IsDeleted)
        {
        }
    }

    public class UnreadNotificationCountSpecification : BaseSpecification<Notification, string>
    {
        public UnreadNotificationCountSpecification(string userId)
            : base(n => n.UserId == userId && !n.IsRead && !n.IsDeleted)
        {
        }
    }
}
