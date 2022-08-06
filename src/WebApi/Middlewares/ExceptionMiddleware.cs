using Application.Exceptions;
using WebApi.Dto;

namespace WebApi.Middlewares;

internal class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            var response = new ErrorDto
            {
                Message = exception.Message,
                Details = exception.ToString(),
                Type = exception.GetType().Name,
                Data = exception.Data
            };

            context.Response.StatusCode = exception switch
            {
                TransactionNotFoundException => 404,
                ArgumentException => 400,
                _ => 500
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}

/*
  ErrorResponse response;
            if (context.Exception is ValidationException exception)
            {
                response = new ErrorResponse
                {
                    Message = exception.Errors.First().ErrorMessage,
                    StackTrace = exception.StackTrace,
                    Type = exception.GetType().Name,
                    Data = exception.Errors.GroupBy(k => new {k.PropertyName, k.AttemptedValue}, v => v.ErrorMessage)
                        .Select(r => new
                        {
                            r.Key.PropertyName,
                            r.Key.AttemptedValue,
                            ErrorMessage = r.ToArray()
                        })
                        .ToDictionary(e => e.PropertyName,
                            e => new {e.AttemptedValue, e.ErrorMessage})
                };
            }
            else
            {
                response = new ErrorResponse
                {
                    Message = context.Exception.Message,
                    StackTrace = context.Exception.StackTrace,
                    Type = context.Exception.GetType().Name,
                    Data = context.Exception.Data
                };
            }

            var result = new ContentResult
            {
                StatusCode = context.Exception switch
                {
                    ValidationException _ => 400,
                    ConflictException _ => 400,
                    ArgumentException _ => 400,
                    ForbiddenException _ => 403,
                    NotFoundException _ => 404,
                    _ => 500
                },
                Content = JsonConvert.SerializeObject(response),
                ContentType = "application/json",
            };

            context.Result = result;

            _logger.LogError(context.Exception, context.HttpContext.Request.Path.ToString(), context.Exception.Data);
 */