using QubHq_Repo.Models;

namespace QubHQ_Services.Services.SessionService;

public static class SessionStore
{
    private static readonly Dictionary<Guid, Session> Sessions = new();

    public static Session? GetSession(Guid sessionId)
        => Sessions.TryGetValue(sessionId, out var session) ? session : null;

    public static Session  GetOrCreate(Guid  sessionId)
    {
        if (!Sessions.ContainsKey(sessionId))
        {
            Sessions[sessionId] = new Session
            {
                Id = sessionId,
                Items = GenerateMockItems()
            };
        }
        return Sessions[sessionId];
    }

    public static Item? TakeItem(Guid sessionId, Guid itemId, Guid userId)
    {
        var session = GetSession(sessionId);
        if (session == null) return null;

        var item = session.Items.FirstOrDefault(i => i.Id == itemId);
        if (item == null || !item.IsAvailable) return null;

        item.IsAvailable = false;
        item.TakenByUserId = userId;

        return item;
    }

    private static List<Item> GenerateMockItems() => Enumerable.Range(1, 10)
        .Select(i => new Item { Name = $"Item {i}" })
        .ToList();
}