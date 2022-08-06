using System.Text;
using Application.Exceptions;
using CommandLine;
using ConsoleApp.Commands;
using DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp;

internal static class Program
{
    private static async Task Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        var service = new ServiceCollection();
        service.AddTransactionServices();
        await using var serviceProvider = service.BuildServiceProvider();

        int mapResult;
        do
        {
            Console.WriteLine("Введите команду");
            var args = Console.ReadLine()!.Split(' ');

            mapResult = await Parser.Default.ParseArguments<CreateTransactionCommand, GetTransactionCommand, ExitCommand>(args)
                .MapResult(
                    async (CreateTransactionCommand command) => await ScopeCommand(serviceProvider, CreateTransactionCommand.Action, command),
                    async (GetTransactionCommand command) => await ScopeCommand(serviceProvider, GetTransactionCommand.Action, command),
                    (ExitCommand command) => ExitCommand(command),
                    errors =>
                    {
                        Console.WriteLine("Errors: " + string.Join(", ", errors));
                        return Task.FromResult(1);
                    });
        } while (mapResult != 1);
    }

    private static async Task<int> ScopeCommand<TCommand>(IServiceProvider serviceProvider, Func<TCommand, IServiceProvider, Task> commandAction,
        TCommand command)
    {
        try
        {
            await using var serviceScope = serviceProvider.CreateAsyncScope();
            await commandAction(command, serviceScope.ServiceProvider);

            Console.WriteLine("[OK]");
        }
        catch (TransactionNotFoundException exception)
        {
            Console.WriteLine(exception.Message);
        }
        catch (ArgumentException exception)
        {
            Console.WriteLine(exception.Message);
        }

        return 0;
    }

    private static Task<int> ExitCommand(ExitCommand command)
    {
        return Task.FromResult(1);
    }
}