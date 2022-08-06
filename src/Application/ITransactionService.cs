using Domain;

namespace Application;

/// <summary>
/// Сервис для управления с транзакциями
/// </summary>
public interface ITransactionService
{
    /// <summary>
    /// Создать транзакцию
    /// </summary>
    /// <param name="transaction">Транзакция</param>
    Task CreateAsync(int transactionId, DateTime transactionDate, decimal amount);

    /// <summary>
    /// Получить транзакцию по идентификатору
    /// </summary>
    /// <param name="transactionId">Идентификатор транзакции</param>
    /// <returns>Транзакция</returns>
    Task<Transaction> GetAsync(int transactionId);
}