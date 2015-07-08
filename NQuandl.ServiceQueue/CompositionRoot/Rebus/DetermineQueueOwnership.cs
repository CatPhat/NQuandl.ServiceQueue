using System;
using NQuandl.ServiceQueue.Messages;
using Rebus;

namespace NQuandl.ServiceQueue.CompositionRoot.Rebus
{
    public class DetermineQueueOwnership : IDetermineMessageOwnership
    {
        public string GetEndpointFor(Type messageType)
        {
            if (messageType == typeof (QuandlQueryRequest<>))
            {
                return "my-app.input";
            }
            throw new Exception("no endpoint for message type");
        }
    }
}