using MediatR;
using Sharedkernel.Guards;
using System.Threading;
using System.Threading.Tasks;

namespace Application
{
    /// <summary>
    /// Command should not return value
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ICommand : IRequest
    {
    }

    /// <summary>
    /// Command handler
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand> where TCommand : ICommand
    {
    }

    /// <summary>
    /// Command bus
    /// </summary>
    public interface ICommandBus
    {
        public Task Send<TRequest>(ICommand command, CancellationToken cancellationToken = default);
    }

    public class CommandBus : ICommandBus
    {
        readonly IMediator _mediator;
        public CommandBus(IMediator mediator)
        {
            Guard.AgainstNull(mediator, "Mediator not configured");

            _mediator = mediator;
        }

        public async Task Send<TRequest>(ICommand command, CancellationToken cancellationToken = default)
        {
            Guard.AgainstNull(command, "Command cannot be null");

            await _mediator.Send(command);
        }
    }
}
