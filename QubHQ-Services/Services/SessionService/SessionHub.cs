using Microsoft.AspNetCore.SignalR;

namespace QubHQ_Services.Services.SessionService;

public class SessionHub : Hub
{
    public async Task JoinSession(Guid sessionId)
    {
        var session = SessionStore.GetOrCreate(sessionId);
        await Groups.AddToGroupAsync(Context.ConnectionId, sessionId.ToString());

        await Clients.Caller.SendAsync("SessionJoined", session.Items);
    }

    public async Task TakeItem(Guid sessionId, Guid itemId, Guid userId)
    {
        var item = SessionStore.TakeItem(sessionId, itemId, userId);
        if (item == null)
        {
            await Clients.Caller.SendAsync("ItemUnavailable", itemId);
            return;
        }

        await Clients.Group(sessionId.ToString()).SendAsync("ItemTaken", new
        {
            item.Id,
            item.TakenByUserId,
            item.IsAvailable
        });
    }
}