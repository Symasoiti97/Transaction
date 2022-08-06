using Application;
using CommandLine;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp.Commands;

[Verb("get", HelpText = "Получить транзакцию")]
public class GetTransactionCommand
{
    public static async Task Action(GetTransactionCommand command, IServiceProvider serviceProvider)
    {
        var transactionService = serviceProvider.GetRequiredService<ITransactionService>();
        Console.WriteLine("Введите идентификатор транзакции:");
        var transactionId = int.Parse(Console.ReadLine()!);

        var transaction = await transactionService.GetAsync(transactionId);
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(transaction));
    }
}