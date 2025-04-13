using QubHq_Repo.Models;
using QubHQ_Services.Dtos;

namespace QubHQ_Services.ExtensionMethods;

public static class VeryfiItemsExtensionMethods
{
    public static List<Item> MapVeryfiItemsToItemDtos(this VeryfiItem veryfiItems, Guid transactionId)
    {
        var itemDtos = new List<Item>();

        foreach (var item in veryfiItems.line_items)
        {
                itemDtos.Add(new Item
                {
                    Name = item.full_description,
                    TransactionId = transactionId,
                    Price = item.quantity > 0 ? item.total / item.quantity : 0
                });
        }

        return itemDtos;
    }
}