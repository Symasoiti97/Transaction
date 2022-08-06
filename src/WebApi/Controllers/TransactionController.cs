using Application;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;

namespace WebApi.Controllers;

/// <summary>
/// АПИ для управлением транзакциями
/// </summary>
/// <response code="400">Запрос построен неверно</response>
/// <response code="404">Ресурс не найден</response>
[ApiController]
[Route("[controller]")]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status404NotFound)]
[ProducesResponseType(typeof(ErrorDto), StatusCodes.Status400BadRequest)]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    /// <summary>
    /// Получить транзакцию по идентификатору
    /// </summary>
    /// <param name="transactionId" example="1">Идентификатор транзакции</param>
    /// <response code="200">Транзакция</response>
    [ProducesResponseType(typeof(TransactionDto), StatusCodes.Status200OK)]
    [HttpGet("{transactionId:int}")]
    public async Task<IActionResult> GetAsync([FromRoute] int transactionId)
    {
        var transaction = await _transactionService.GetAsync(transactionId);

        return Ok(new TransactionDto
        {
            Id = transaction.Id,
            Amount = transaction.Amount,
            TransactionDate = transaction.TransactionDate
        });
    }

    /// <summary>
    /// Создать транзакцию
    /// </summary>
    /// <param name="transaction">Новая транзакция</param>
    /// <response code="201">Транзакция создана</response>
    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] TransactionDto transaction)
    {
        await _transactionService.CreateAsync(transaction.Id, transaction.TransactionDate, transaction.Amount);
        return StatusCode(StatusCodes.Status201Created);
    }
}