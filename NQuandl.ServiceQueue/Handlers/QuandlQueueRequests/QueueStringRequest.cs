using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NQuandl.Client.Interfaces;
using NQuandl.Client.URIs;

namespace NQuandl.ServiceQueue.Handlers.QuandlQueueRequests
{
    public class QueueStringRequest : IQuandlRequest
    {
        public readonly IQuandlRequest Request;
        public QueueStringRequest(IQuandlRequest request)
        {
            Request = request;
        }

        public IQuandlUri Uri
        {
            get { return Request.Uri; }
        }
    }
}
