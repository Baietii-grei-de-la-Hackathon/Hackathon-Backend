using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using QubHQ_Services.Services.SessionService;

namespace Hackathon_Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SessionController : Controller
{
    private readonly IHubContext<SessionHub> _hubContext;

    public SessionController(IHubContext<SessionHub> hubContext)
    {
        _hubContext = hubContext;
    }

    [HttpPost("create")]
    public IActionResult CreateSession()
    {
        var sessionId = Guid.NewGuid();
        var session = SessionStore.GetOrCreate(sessionId);
        return Ok(new { sessionId, items = session.Items });
    }

    [HttpPost("{sessionId}/take")]
    public async Task<IActionResult> TakeItem(Guid sessionId, [FromQuery] Guid itemId, [FromQuery] Guid userId)
    {
        var item = SessionStore.TakeItem(sessionId, itemId, userId);
        if (item == null)
            return BadRequest("Item is already taken or doesn't exist.");

        await _hubContext.Clients.Group(sessionId.ToString()).SendAsync("ItemTaken", new
        {
            item.Id,
            item.TakenByUserId,
            item.IsAvailable
        });

        return Ok(item);
    }
}