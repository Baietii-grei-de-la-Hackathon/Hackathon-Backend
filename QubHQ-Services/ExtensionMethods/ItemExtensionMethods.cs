using QubHq_Repo.Models;
using QubHQ_Services.Dtos;

namespace QubHQ_Services.ExtensionMethods;

public static class ItemExtensions
{
    public static ItemDto ToDto(this Item item)
    {
        if (item == null) return null;

        return new ItemDto
        {
            Id = item.Id,
            TransactionId = item.TransactionId,
            Name = item.Name,
            UserName = item.UserName,
            Price = item.Price
        };
    }

    public static Item ToEntity(this ItemDto dto)
    {
        if (dto == null) return null;

        return new Item
        {
            Id = dto.Id,
            TransactionId = dto.TransactionId,
            Name = dto.Name,
            UserName = dto.UserName,
            Price = dto.Price
        };
    }

    public static void UpdateFromDto(this Item entity, ItemDto dto)
    {
        entity.Name = dto.Name;
        entity.UserName = dto.UserName;
        entity.Price = dto.Price;
    }
    
    public static List<ItemDto> ToDtoList(this IEnumerable<Item> items)
    {
        return items?.Select(i => i.ToDto()).ToList() ?? new List<ItemDto>();
    }

    public static List<Item> ToEntityList(this IEnumerable<ItemDto> dtos, Guid transactionId)
    {
        return dtos?.Select(dto => dto.ToEntity()).ToList() ?? new List<Item>();
    }
}