using Application;
using Application.Exceptions;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

internal class TransactionRepository : ITransactionRepository
{
    private readonly TransactionDbContext _transactionDbContext;

    public TransactionRepository(TransactionDbContext transactionDbContext)
    {
        _transactionDbContext = transactionDbContext;
    }

    public async Task CreateAsync(Transaction transaction)
    {
        _transactionDbContext.Add(transaction);
        await _transactionDbContext.SaveChangesAsync();
    }

    public async Task<Transaction> GetAsync(int transactionId)
    {
        var transaction = await _transactionDbContext.Set<Transaction>().AsNoTracking().SingleOrDefaultAsync(x => x.Id == transactionId);
        if (transaction == null)
        {
            throw new TransactionNotFoundException(transactionId);
        }

        return transaction;
    }
}