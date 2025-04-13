using Microsoft.AspNetCore.Mvc;
using QubHQ_Services.Dtos;
using QubHQ_Services.Services.Item;

namespace Hackathon_Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemService)
    {
        _itemService = itemService;
    }
    
    [HttpGet("{id}")]
    public async Task<List<ItemDto>> GetItemsByTransactionId(Guid transactionId)
    {
        return await _itemService.GetItemsAsync(transactionId);
    }
    
    [HttpPut]
    public async Task<bool> UpdateItems(List<ItemDto> items)
    {
        return await _itemService.UpdateItemsAsync(items);
    }
    
    [HttpPost("{transactionId}")]
    public async Task<bool> DeleteItemsByTransactionId(Guid transactionId)
    {
        return await _itemService.DeleteItemsByTransactionId(transactionId);
    }
}