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
    public async Task<IActionResult> GetTransaction(Guid id)
    {
        return Ok(await _transactionService.GetTransactionByIdAsync(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateTransaction([FromBody] TransactionDto transactionDto)
    {
        return Ok(await _transactionService.CreateTransactionAsync(transactionDto));
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTransaction([FromBody] TransactionDto transactionDto)
    {
        return Ok(await _transactionService.UpdateTransactionAsync(transactionDto));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTransaction(Guid id)
    {
        return Ok(await _transactionService.DeleteTransactionAsync(id));
    }
}