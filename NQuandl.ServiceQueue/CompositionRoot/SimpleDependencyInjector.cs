using System;
using Hangfire;
using Hangfire.Redis.StackExchange;
using SimpleInjector;

namespace NQuandl.ServiceQueue.CompositionRoot
{
    public class SimpleDependencyInjector : IServiceProvider
    {
        public readonly Container Container;

        public SimpleDependencyInjector()
        {
            Container = new Container();

            GlobalConfiguration.Configuration.UseRedisStorage(
                @"server=SHIVA9.;initial catalog=RebusInputQueue;integrated security=sspi");
      
       
            //Rebus.CompositionRoot.ConfigureBus(Container);
            Container.ComposeRoot();
            Container.Verify();
        }

        public object GetService(Type serviceType)
        {
            return ((IServiceProvider) Container).GetService(serviceType);
        }
    }
}