namespace N5API.Domain.Abstractions.Service
{
    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }
}
