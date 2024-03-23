using MediatR;
using PWSoftware.BaseDomain.Abstractions;

namespace PWSoftware.BaseApplication.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}
