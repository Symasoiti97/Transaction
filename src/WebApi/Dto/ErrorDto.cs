using System.Collections;

namespace WebApi.Dto;

/// <summary>
/// Ошибка
/// </summary>
public class ErrorDto
{
    /// <summary>
    /// Сообщение об ошибке
    /// </summary>
    /// <example>Транзакции c идентификатором '{transactionId}' не сущесвует</example>
    public string Message { get; set; } = null!;

    /// <summary>
    /// Детальная информация об ошибке
    /// </summary>
    /// <example>StackTrace</example>
    public string? Details { get; set; }

    /// <summary>
    /// Тип ошибки
    /// </summary>
    public string Type { get; set; } = null!;

    /// <summary>
    /// Дополнительные данные ошибки
    /// </summary>
    /// <example></example>
    public IDictionary? Data { get; set; }
}