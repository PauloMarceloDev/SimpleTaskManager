using MediatR;
using PWSoftware.BaseDomain.Abstractions;

namespace PWSoftware.BaseApplication.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
