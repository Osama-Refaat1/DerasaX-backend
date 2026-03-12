using DerasaX.Application.Common;
using DerasaX.Application.Dto.NotificationDto;
using DerasaX.Application.Services.Abstractions.Notification;
using DerasaX.Api.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace DerasaX.Api.Realtime
{
    public class SignalRSender : IRealtimeSender
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public SignalRSender(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public Task SendToUserAsync(string userId, NotificationDto dto)
            => _hubContext.Clients.Group(RealtimeGroups.User(userId)).SendAsync("ReceiveNotification", dto);

        public Task SendToGroupAsync(string groupName, NotificationDto dto)
            => _hubContext.Clients.Group(groupName).SendAsync("ReceiveNotification", dto);
    }
}
