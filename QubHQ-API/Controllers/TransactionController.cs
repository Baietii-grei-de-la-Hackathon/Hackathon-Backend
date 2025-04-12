using Microsoft.AspNetCore.Mvc;
using QubHQ_Services.Dtos;
using QubHQ_Services.Services.TransactionService;

namespace Hackathon_Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpGet("{id}")]
    public async Task<TransactionDto> GetTransaction(Guid id)
    {
        var transaction = await _transactionService.GetTransactionByIdAsync(id);
        return transaction;
    }

    [HttpPost]
    public async Task<Guid> CreateTransaction([FromBody] TransactionDto transactionDto)
    {
        return await _transactionService.CreateTransactionAsync(transactionDto);
    }

    [HttpPut("{id}")]
    public async Task<bool> UpdateTransaction([FromBody] TransactionDto transactionDto)
    {
        return await _transactionService.UpdateTransactionAsync(transactionDto);
    }

    [HttpDelete("{id}")]
    public async Task<bool> DeleteTransaction(Guid id)
    {
        return await _transactionService.DeleteTransactionAsync(id);
    }
}