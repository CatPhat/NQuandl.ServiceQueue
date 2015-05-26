using System;
using SimpleInjector;

namespace NQuandl.ServiceQueue.CompositionRoot
{
    //https://github.com/rebus-org/Rebus/issues/260
    public class SimpleDependencyInjector : IServiceProvider
    {
        public readonly Container Container;

        public SimpleDependencyInjector()
        {
            Container = Bootstrap();
        }

        public object GetService(Type serviceType)
        {
            return ((IServiceProvider) Container).GetService(serviceType);
        }

        internal Container Bootstrap()
        {
            var container = new Container();
            container.ComposeRoot();
            container.Verify();
            return container;
        }
    }
}