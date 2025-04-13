using Microsoft.EntityFrameworkCore;
using QubHq_Repo.UnitOfWork;
using QubHQ_Services.Dtos;
using QubHQ_Services.ExtensionMethods;

namespace QubHQ_Services.Services.Item;

public class ItemService : IItemService
{
    private readonly IUnitOfWork _unitOfWork;

    public ItemService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<ItemDto>> GetItemsAsync(Guid transactionId)
    {
        var itemRepo = _unitOfWork.GetRepository<QubHq_Repo.Models.Item>();
        var items = await itemRepo.GetAll().Where(i => i.TransactionId == transactionId).ToListAsync();

        return items.ToDtoList();
    }

    public async Task<bool> UpdateItemsAsync(List<ItemDto> itemsDto)
    {
        var itemRepo = _unitOfWork.GetRepository<QubHq_Repo.Models.Item>();
        var transactionId = itemsDto.First().TransactionId;
        var itemList = await itemRepo.GetAll().Where(i => i.TransactionId == transactionId).ToListAsync();

        for (int i = 0; i < itemList.Count(); i++)
        {
            itemList[i].UpdateFromDto(itemsDto[i]);
            itemRepo.Update(itemList[i]);
        }

        var changes = _unitOfWork.Commit();

        if (changes > 0)
            return true;
        return false;
    }

    public async Task<bool> DeleteItemsByTransactionId(Guid transactionId)
    {
        var itemRepo = _unitOfWork.GetRepository<QubHq_Repo.Models.Item>();
        var itemList = await itemRepo.GetAll().Where(i => i.TransactionId == transactionId).ToListAsync();
        itemRepo.DeleteRange(itemList);
        var changes = _unitOfWork.Commit();
        if(changes > 0)
            return true;
        return false;
    }
}