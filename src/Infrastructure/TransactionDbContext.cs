using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class TransactionDbContext : DbContext
{
    public TransactionDbContext(DbContextOptions<TransactionDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>(builder =>
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TransactionDate);
            builder.Property(x => x.Amount);
        });

        base.OnModelCreating(modelBuilder);
    }
}