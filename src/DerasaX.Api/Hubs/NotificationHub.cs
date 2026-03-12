using DerasaX.Application.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace DerasaX.Api.Hubs
{
    [Authorize]
    public class NotificationHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            var userId = Context.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            var tenantId = Context.User?.FindFirstValue("tenantId");
            var roles = Context.User?.FindAll(ClaimTypes.Role).Select(c => c.Value) ?? Enumerable.Empty<string>();

            if (!string.IsNullOrEmpty(userId))
                await Groups.AddToGroupAsync(Context.ConnectionId, RealtimeGroups.User(userId));

            if (!string.IsNullOrEmpty(tenantId))
            {
                foreach (var role in roles)
                    await Groups.AddToGroupAsync(Context.ConnectionId, RealtimeGroups.TenantRole(tenantId, role));

                // Add to tenant-wide group for announcements
                await Groups.AddToGroupAsync(Context.ConnectionId, RealtimeGroups.TenantAll(tenantId));
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}
