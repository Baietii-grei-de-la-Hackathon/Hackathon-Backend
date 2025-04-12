using QubHQ_Services.Dtos;

namespace QubHQ_Services.Services.TransactionService;

public interface ITransactionService
{
    Task<TransactionDto> GetTransactionByIdAsync(Guid id);
    Task<Guid> CreateTransactionAsync(TransactionDto transactionDto);
    Task<bool> UpdateTransactionAsync(TransactionDto transactionDto);
    Task<bool> DeleteTransactionAsync(Guid id);
    
}