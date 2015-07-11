using System.Threading.Tasks;

namespace NQuandl.ServiceQueue.Api
{
    public interface IProcessCommands
    {
        Task Execute(IDefineCommand command);
    }
}