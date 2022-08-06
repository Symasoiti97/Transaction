using Domain;

namespace Application;

/// <summary>
/// Хранилище для управления с транзакциями
/// </summary>
public interface ITransactionRepository
{
    /// <summary>
    /// Создать транзакцию
    /// </summary>
    /// <param name="transaction">Транзакция</param>
    Task CreateAsync(Transaction transaction);

    /// <summary>
    /// Получить транзакцию по идентификатору
    /// </summary>
    /// <param name="transactionId">Идентификатор транзакции</param>
    /// <returns>Транзакция</returns>
    Task<Transaction> GetAsync(int transactionId);
}