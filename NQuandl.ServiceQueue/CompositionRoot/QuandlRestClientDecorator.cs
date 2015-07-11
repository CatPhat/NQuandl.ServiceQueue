using System;
using System.Threading.Tasks;
using NQuandl.Client.Api;
using NQuandl.Client.Domain.RequestParameters;
using NQuandl.ServiceQueue.Api;

namespace NQuandl.ServiceQueue.CompositionRoot
{
    public class QuandlRestClientDecorator : IQuandlRestClient
    {
        private readonly IQuandlRestClient _client;
        private readonly IRateGate _rateGate;

        public QuandlRestClientDecorator(IRateGate rateGate, IQuandlRestClient client)
        {
            if (rateGate == null) throw new ArgumentNullException("rateGate");
            if (client == null) throw new ArgumentNullException("client");
            _rateGate = rateGate;
            _client = client;
        }

        public async Task<string> DoGetRequestAsync(QuandlRestClientRequestParameters parameters)
        {
            var requestId = string.Format("{0}-{1}", parameters.QueryParameters["source_code"],
                parameters.QueryParameters["page"]);
            Console.WriteLine("Request {0} waiting to be executed.", requestId);
            _rateGate.WaitToProceed();
            Console.WriteLine("Executing Request: {0}", requestId);
            return await _client.DoGetRequestAsync(parameters);
        }
    }
}