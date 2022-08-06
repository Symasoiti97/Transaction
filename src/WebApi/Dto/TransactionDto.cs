namespace WebApi.Dto;

/// <summary>
/// Транзакция
/// </summary>
public class TransactionDto
{
    /// <summary>
    /// Идентификатор транзакции
    /// </summary>
    /// <example>12</example>
    public int Id { get; set; }

    /// <summary>
    /// Дата транзакции
    /// </summary>
    /// <example>2019-04-02T13:10:20.0263632+03:00</example>
    public DateTime TransactionDate { get; set; }

    /// <summary>
    /// Сумма
    /// </summary>
    /// <example>23.05</example>
    public decimal Amount { get; set; }
}