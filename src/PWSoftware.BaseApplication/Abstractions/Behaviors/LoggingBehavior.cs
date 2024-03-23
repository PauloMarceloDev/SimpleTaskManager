using MediatR;
using Microsoft.Extensions.Logging;
using PWSoftware.BaseDomain.Abstractions;
using Serilog.Context;

namespace PWSoftware.BaseApplication.Abstractions.Behaviors;

internal sealed class LoggingBehavior<TRequest, TResponse>(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IBaseRequest
    where TResponse : Result
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        string requestName = request.GetType().Name;

        try
        {
            logger.LogInformation("Executing request {RequestName}", requestName);

            TResponse result = await next();

            if (result.IsSuccess)
            {
                logger.LogInformation("Request {RequestName} processed successfully", requestName);
            }
            else
            {
                using (LogContext.PushProperty("Error", result.Error, true))
                {
                    logger.LogError("Request {RequestName} processed with error", requestName);
                }
            }

            return result;
        }
#pragma warning disable S2139
        catch (Exception exception)
#pragma warning restore S2139
        {
            logger.LogError(exception, "Request {RequestName} processing failed", requestName);

            throw;
        }
    }
}
