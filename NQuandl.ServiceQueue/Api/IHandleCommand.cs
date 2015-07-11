using System.Threading.Tasks;

namespace NQuandl.ServiceQueue.Api
{
    public interface IHandleCommand<in TCommand> where TCommand : IDefineCommand
    {
        Task Handle(TCommand command);
    }
}