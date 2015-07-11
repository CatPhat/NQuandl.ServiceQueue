using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using NQuandl.ServiceQueue.Api;

namespace NQuandl.ServiceQueue.Commands
{
    public class EnqueueRequestToRateGate : IDefineCommand
    {
        public Expression<Action> Request { get; private set; }

        public EnqueueRequestToRateGate(Expression<Action> request)
        {
            Request = request;
        }
    }

    public class HandleEnqueueRequestToRateGate : IHandleCommand<EnqueueRequestToRateGate>
    {
        public Task Handle(EnqueueRequestToRateGate command)
        {
            throw new NotImplementedException();
        }
    }
}
