namespace Application.Exceptions;

/// <summary>
/// Транзакции не существует
/// </summary>
public sealed class TransactionNotFoundException : Exception
{
    /// <summary>
    /// Идентификатор транзакции
    /// </summary>
    public int TransactionId { get; }

    public TransactionNotFoundException(int transactionId) : base($"Транзакции c идентификатором '{transactionId}' не сущесвует")
    {
        TransactionId = transactionId;
        Data[nameof(TransactionId)] = transactionId;
    }
}