using System.Collections.Generic;
using NQuandl.Client.Interfaces;

namespace NQuandl.ServiceQueue.Messages
{
    public class QuandlQueryRequest
    {
        public IQuandlRequest Request { get; set; }
    }
}