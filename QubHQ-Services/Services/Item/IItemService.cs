using QubHQ_Services.Dtos;

namespace QubHQ_Services.Services.Item;

public interface IItemService
{
    Task<List<ItemDto>> GetItemsAsync(Guid transactionId);
    Task<bool> UpdateItemsAsync(List<ItemDto> itemsDto);
    Task<bool> DeleteItemsByTransactionId(Guid transactionId);
}