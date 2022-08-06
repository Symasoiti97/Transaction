using Domain;

namespace Application;

internal class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public Task CreateAsync(int transactionId, DateTime transactionDate, decimal amount)
    {
        var newTransaction = new Transaction(transactionId, transactionDate, amount);

        return _transactionRepository.CreateAsync(newTransaction);
    }

    public Task<Transaction> GetAsync(int transactionId)
    {
        return _transactionRepository.GetAsync(transactionId);
    }
}