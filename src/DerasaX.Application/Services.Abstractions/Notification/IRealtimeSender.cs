using DerasaX.Application.Dto.NotificationDto;

namespace DerasaX.Application.Services.Abstractions.Notification
{
    /// <summary>
    /// Abstraction over the real-time transport (SignalR).
    /// Keeps the Application layer independent from the API layer.
    /// </summary>
    public interface IRealtimeSender
    {
        Task SendToUserAsync(string userId, NotificationDto dto);
        Task SendToGroupAsync(string groupName, NotificationDto dto);
    }
}
