using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NQuandl.ServiceQueue.Api;

namespace NQuandl.ServiceQueue.Commands
{
    public class EnqueueJob : IDefineCommand
    {
        public EnqueueJob(Expression<Action> jobAction)
        {
            JobAction = jobAction;
        }
        public Expression<Action> JobAction { get; private set; }
    }

    public class HandleEnqueueJob : IHandleCommand<EnqueueJob>
    {
        private readonly IJobStorage _jobStorage;

        public HandleEnqueueJob(IJobStorage jobStorage)
        {
            if (jobStorage == null) throw new ArgumentNullException("jobStorage");
            _jobStorage = jobStorage;
        }

        public Task Handle(EnqueueJob command)
        {
            _jobStorage.Enqueue(command.JobAction);
            return Task.FromResult(0);
        }
    }
}