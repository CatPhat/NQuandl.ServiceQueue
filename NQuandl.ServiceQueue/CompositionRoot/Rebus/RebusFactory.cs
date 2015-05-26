using System;
using Rebus;

namespace NQuandl.ServiceQueue.CompositionRoot.Rebus
{
    public class RebusFactory
    {
        private readonly IServiceProvider _provider;

        public RebusFactory(IServiceProvider provider)
        {
            _provider = provider;
        }

        public IBus GetBus()
        {
            return _provider.GetService(typeof (IBus)) as IBus;
        }
       
    }
}