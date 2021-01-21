using MediatR;
using Sharedkernel.Guards;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }

    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
    {
    }

    public interface IQueryBus
    {
        Task<TResponse> Send<TResponse>(IQuery<TResponse> request, CancellationToken cancellationToken = default);
    }

    public class QueryBus : IQueryBus
    {
        readonly IMediator _mediator;
        public QueryBus(IMediator mediator)
        {
            Guard.AgainstNull(mediator, "MediatR is not configured");

            _mediator = mediator;
        }

        public virtual async Task<TResponse> Send<TResponse>(IQuery<TResponse> request, CancellationToken cancellationToken = default)
        {
            Guard.AgainstNull(request, "Query cannot be null");

            var result = await _mediator.Send(request);

            return result;
        }
    }
}
