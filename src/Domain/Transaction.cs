namespace Domain;

/// <summary>
/// Транзакция
/// </summary>
public class Transaction
{
    public Transaction(int id, DateTime transactionDate, decimal amount)
    {
        Id = id;
        TransactionDate = transactionDate;
        Amount = amount;
    }

    /// <summary>
    /// Идентификатор транзакции
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Дата транзакции
    /// </summary>
    public DateTime TransactionDate { get; }

    /// <summary>
    /// Сумма
    /// </summary>
    public decimal Amount { get; }
}