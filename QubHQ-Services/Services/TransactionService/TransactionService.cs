using Microsoft.EntityFrameworkCore;
using QubHq_Repo.Models;
using QubHq_Repo.UnitOfWork;
using QubHQ_Services.Dtos;
using QubHQ_Services.ExtensionMethods;

namespace QubHQ_Services.Services.TransactionService;

public class TransactionService : ITransactionService
{
    private readonly IUnitOfWork _unitOfWork;

    public TransactionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TransactionDto> GetTransactionByIdAsync(Guid id)
    {
        var transactionRepo = _unitOfWork.GetRepository<Transaction>();
        var transaction = await transactionRepo.GetAll().Where(t => t.Id == id).Include(t => t.Users)
            .FirstOrDefaultAsync();

        if (transaction is null)
            throw new Exception("Transaction not found");

        return transaction.ToDto();
    }

    public async Task<Guid> CreateTransactionAsync(TransactionDto transactionDto)
    {
        var transactionRepo = _unitOfWork.GetRepository<Transaction>();
        var transaction = transactionDto.ToModel();

        await transactionRepo.AddAsync(transaction);
        _unitOfWork.Commit();

        return transaction.Id;
    }

    public async Task<bool> UpdateTransactionAsync(TransactionDto transactionDto)
    {
        var transactionRepo = _unitOfWork.GetRepository<Transaction>();
        var transaction = await transactionRepo.GetAll().Where(t => t.Id == transactionDto.Id)
            .Include(t => t.Users).FirstOrDefaultAsync();

        if (transaction != null) transaction.UpdateModel(transactionDto);
        var state = transactionRepo.Update(transaction);
        _unitOfWork.Commit();

        if (state == EntityState.Modified)
            return true;

        return false;
    }

    public async Task<bool> DeleteTransactionAsync(Guid id)
    {
        var transactionRepo = _unitOfWork.GetRepository<Transaction>();

        var transaction = await transactionRepo.GetAll().Where(t => t.Id == id).Include(t => t.Users)
            .FirstOrDefaultAsync();

        if (transaction != null)
        {
            var status = transactionRepo.Delete(transaction);
            _unitOfWork.Commit();

            if (status == EntityState.Deleted)
                return true;
        }

        return false;
    }
}