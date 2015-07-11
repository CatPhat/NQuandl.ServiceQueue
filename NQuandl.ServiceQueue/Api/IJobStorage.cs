using System;
using System.Linq.Expressions;

namespace NQuandl.ServiceQueue.Api
{
    public interface IJobStorage
    {
        void Enqueue(Expression<Action> action);
    }
}