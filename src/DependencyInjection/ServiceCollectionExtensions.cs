using Application;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Регистрация сервисов для сервиса "Транзакции"
    /// <list type="bullet">
    ///     <item>Регестрирует <see cref="ITransactionService"/> как Transient</item>
    /// </list>
    /// </summary>
    /// <param name="services">Коллекция сервисов</param>
    /// <returns>Коллекция сервисов</returns>
    public static IServiceCollection AddTransactionServices(this IServiceCollection services)
    {
        services.AddDbContext<TransactionDbContext>(builder => builder.UseInMemoryDatabase("Transaction"));

        services.AddTransient<ITransactionRepository, TransactionRepository>();
        services.AddTransient<ITransactionService, TransactionService>();

        return services;
    }
}