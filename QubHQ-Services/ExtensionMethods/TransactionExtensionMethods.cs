using QubHq_Repo.Models;
using QubHQ_Services.Dtos;

namespace QubHQ_Services.ExtensionMethods;

public static class TransactionExtensionMethods
{
    public static Transaction ToModel(this TransactionDto transactionDto)
    {
        var transaction = new Transaction()
        {
            Date = transactionDto.Date,
            Users = transactionDto.UserDtos.ToModelList(),
            TransactionStatusId = transactionDto.TransactionStatusId,
            PaidToRestaurant = transactionDto.PaidToRestaurant,
            Passcode = transactionDto.Passcode
        };
        
        if(transactionDto.Description is not null)
            transaction.Description = transactionDto.Description;
        
        return transaction;
    }
    
    public static TransactionDto ToDto(this Transaction transaction)
    {
        var transactionDto = new TransactionDto()
        {
            Id = transaction.Id!,
            Date = transaction.Date,
            UserDtos = transaction.Users.ToDtoList(),
            TransactionStatusId = transaction.TransactionStatusId,
            Status = transaction.Status.Name,
            PaidToRestaurant = transaction.PaidToRestaurant,
            Passcode = transaction.Passcode,
        };
        
        if(transactionDto.Description is not null)
            transactionDto.Description = transactionDto.Description;
        
        return transactionDto;
    }

    public static Transaction UpdateModel(this Transaction transaction, TransactionDto transactionDto)
    {
        transaction.Date = transactionDto.Date;
        transaction.Users = transactionDto.UserDtos.ToModelList();
        transaction.Description = transactionDto.Description;
        
        return transaction;
    }
    
    public static List<TransactionDto> ToDtoList(this IEnumerable<Transaction> transactions)
    {
        var transactionsDtos = new List<TransactionDto>();
        foreach (var transaction in transactions)
        {
            transactionsDtos.Add(transaction.ToDto());
        }

        return transactionsDtos;
    }  
    
    public static List<Transaction> ToDtoList(this IEnumerable<TransactionDto> transactionDtos)
    {
        var transactions = new List<Transaction>();
        foreach (var transactionDto in transactionDtos)
        {
            transactions.Add(transactionDto.ToModel());
        }

        return transactions;
    }
}