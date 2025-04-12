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
    [Route("create-transaction")]
    public async Task<IActionResult> CreateTransaction([FromBody] TransactionDto transactionDto)
    {
        return Ok(await _transactionService.CreateTransactionAsync(transactionDto));
    }
}