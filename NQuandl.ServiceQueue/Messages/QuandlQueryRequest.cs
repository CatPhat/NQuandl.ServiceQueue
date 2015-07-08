using System;
using NQuandl.Client.Api;
using NQuandl.Client.Domain.RequestParameters;

namespace NQuandl.ServiceQueue.Messages
{
    public class QuandlQueryRequest<TEntity> where TEntity : QuandlEntity
    {
        public RequestParametersV1 RequestParameters { get; set; }
    }
}