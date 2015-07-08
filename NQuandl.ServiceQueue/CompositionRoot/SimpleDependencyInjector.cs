using System;
using SimpleInjector;

namespace NQuandl.ServiceQueue.CompositionRoot
{
    public class SimpleDependencyInjector : IServiceProvider
    {
        public readonly Container Container;

        public SimpleDependencyInjector()
        {
            Container = new Container();
            
            Rebus.CompositionRoot.ConfigureBus(Container);
            Container.ComposeRoot();
            Container.Verify();
        }

        public object GetService(Type serviceType)
        {
            return ((IServiceProvider) Container).GetService(serviceType);
        }
    }
}