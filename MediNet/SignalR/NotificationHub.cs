using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace MediNet.SignalR
{
    public class NotificationHub : Hub
    {
        private static readonly ConcurrentDictionary<int, string> ConnectedUsers = new();
        public async Task SendMessage(int userId, string message)
        {
            string recipientConnectionId = ConnectedUsers.FirstOrDefault(x => x.Key == userId).Value;

            if (recipientConnectionId != null)
            {
                await Clients.Client(recipientConnectionId).SendAsync("ReceiveMessage", message);
            }
            else
            {
                await Console.Out.WriteLineAsync("User Not Found");
            }
        }

        public override Task OnConnectedAsync()
        {
            ConnectedUsers.TryAdd(int.Parse(Context.User.FindFirst("id").Value), Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            ConnectedUsers.TryRemove(int.Parse(Context.User.FindFirst("id").Value), out _);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
