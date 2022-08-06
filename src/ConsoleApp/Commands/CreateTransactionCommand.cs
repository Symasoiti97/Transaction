using Application;
using CommandLine;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp.Commands;

[Verb("add", HelpText = "Создать транзакцию")]
public class CreateTransactionCommand
{
    public static async Task Action(CreateTransactionCommand command, IServiceProvider serviceProvider)
    {
        var transactionService = serviceProvider.GetRequiredService<ITransactionService>();
        Console.Write("Введите идентификатор транзакции: ");
        var transactionId = int.Parse(Console.ReadLine()!);

        Console.Write("Введите дату транзакции: ");
        var transactionDate = DateTime.Parse(Console.ReadLine()!);

        Console.Write("Введите сумму транзакции: ");
        var transactionAmount = decimal.Parse(Console.ReadLine()!);

        await transactionService.CreateAsync(transactionId, transactionDate, transactionAmount);
    }
}